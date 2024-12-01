-- phpMyAdmin SQL Dump
-- version 5.2.0
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1:3306
-- Generation Time: Nov 21, 2023 at 03:12 PM
-- Server version: 8.0.31
-- PHP Version: 8.0.26

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `payroll`
--

DELIMITER $$
--
-- Procedures
--
DROP PROCEDURE IF EXISTS `ChangeServerStatus`$$
CREATE DEFINER=`root`@`localhost` PROCEDURE `ChangeServerStatus` (IN `p_status` INT)   UPDATE serverstatus
SET status = p_status,
	lastChecked = NOW()$$

DROP PROCEDURE IF EXISTS `CheckAndGeneratePayslip`$$
CREATE DEFINER=`root`@`localhost` PROCEDURE `CheckAndGeneratePayslip` ()   BEGIN
    DECLARE latestEndDate DATE;
    DECLARE newStartDate DATE;

    -- Get the latest endDate
    SELECT endDate INTO latestEndDate
    FROM payslip
    ORDER BY endDate DESC
    LIMIT 1;

    -- Calculate the new startDate as the day after the latest endDate
    SET newStartDate = DATE_ADD(latestEndDate, INTERVAL 1 DAY);

    -- Check if there's an existing Payslip with the calculated startDate and endDate
    IF NOT EXISTS (
        SELECT 1
        FROM payslip
        WHERE CURDATE() BETWEEN startDate AND endDate
    ) THEN
        -- Insert a new Payslip record with the calculated startDate and endDate
        INSERT INTO payslip (startDate, endDate)
        VALUES (newStartDate, DATE_ADD(newStartDate, INTERVAL 6 DAY));
    END IF;
END$$

DROP PROCEDURE IF EXISTS `checkIsEnabled`$$
CREATE DEFINER=`root`@`localhost` PROCEDURE `checkIsEnabled` (IN `p_userID` INT)   SELECT a.isEnabled
FROM account a
WHERE a.userID = p_userID$$

DROP PROCEDURE IF EXISTS `CheckServerStatus`$$
CREATE DEFINER=`root`@`localhost` PROCEDURE `CheckServerStatus` ()   SELECT *
FROM serverstatus$$

DROP PROCEDURE IF EXISTS `CheckUserLoginStatus`$$
CREATE DEFINER=`root`@`localhost` PROCEDURE `CheckUserLoginStatus` (IN `p_userID` INT)   SELECT a.isLoggedIn
FROM account a
WHERE a.userID = p_userID$$

DROP PROCEDURE IF EXISTS `checkUsername`$$
CREATE DEFINER=`root`@`localhost` PROCEDURE `checkUsername` (IN `usn` VARCHAR(50))   SELECT username FROM account WHERE username = usn$$

DROP PROCEDURE IF EXISTS `ClockInOut`$$
CREATE DEFINER=`root`@`localhost` PROCEDURE `ClockInOut` (IN `p_userID` INT, IN `p_clockintime` DATETIME, IN `p_clockedIn` INT, IN `p_clockouttime` DATETIME, IN `p_clockedOut` INT)   UPDATE dtr
    SET dtr.clockintime = p_clockintime,
        dtr.clockedIn = p_clockedIn,
        dtr.clockouttime = p_clockouttime,
        dtr.clockedOut = p_clockedOut
    WHERE userID = p_userID AND dtrDate = CURDATE()$$

DROP PROCEDURE IF EXISTS `DeleteUser`$$
CREATE DEFINER=`root`@`localhost` PROCEDURE `DeleteUser` (IN `p_userID` INT)   DELETE FROM account 
WHERE account.userID = p_userID$$

DROP PROCEDURE IF EXISTS `DTR`$$
CREATE DEFINER=`root`@`localhost` PROCEDURE `DTR` (IN `pUserID` INT, IN `pNthPayslip` INT)   BEGIN
    DECLARE currentDate DATE;
    DECLARE clockinTime DATETIME;
    DECLARE clockoutTime DATETIME;
    DECLARE totalHours DECIMAL(10, 6);
    
    SET currentDate = CURDATE();
    SET clockinTime = NULL;
    SET clockoutTime = NULL;
    SET totalHours = 0;

    IF NOT EXISTS (
        SELECT 1
        FROM dtr
        WHERE dtrDate = currentDate
          AND userID = pUserID
          AND nthPayslip = pNthPayslip
    )
    THEN
        INSERT INTO dtr (nthPayslip, userID, clockinTime, clockoutTime, totalHours, dtrDate)
        VALUES (pNthPayslip, pUserID, clockinTime, clockoutTime, totalHours, currentDate);
    END IF;
END$$

DROP PROCEDURE IF EXISTS `editUserAcc`$$
CREATE DEFINER=`root`@`localhost` PROCEDURE `editUserAcc` (IN `p_staffID` INT, IN `p_firstname` VARCHAR(50), IN `p_lastname` VARCHAR(50), IN `p_sex` VARCHAR(50), IN `p_dOB` DATETIME, IN `p_position` VARCHAR(50), IN `p_salary` DECIMAL, IN `p_allowance` DECIMAL, IN `p_stationNo` VARCHAR(50), IN `p_isEnabled` INT, IN `p_accountLevel` INT, IN `p_sss` VARCHAR(50), IN `p_philhealth` VARCHAR(50), IN `p_pagibig` VARCHAR(50))   UPDATE staff s, account a
SET s.firstName = p_firstname,
	s.lastName = p_lastname,
    s.sex = p_sex,
    s.DOB = p_dOB,
    s.position = p_position,
    s.salary = p_salary,
    s.allowance = p_allowance,
    s.SSS = p_sss,
    s.PhilHealth = p_philhealth,
    s.PagIbig = p_pagibig,
    s.stationNo = p_stationNo,
    a.isEnabled = p_isEnabled,
    a.accountLevel = p_accountLevel
WHERE s.staffID = p_staffID
AND a.staffID = p_staffID$$

DROP PROCEDURE IF EXISTS `EventLog`$$
CREATE DEFINER=`root`@`localhost` PROCEDURE `EventLog` (IN `p_eventDescription` VARCHAR(255), IN `p_userID` INT, IN `p_serverID` INT)   INSERT INTO eventlog (userID, serverID, eventDate, eventTime, eventDescription)
VALUES (p_userID, p_serverID, CURDATE(), CURTIME(), p_eventDescription)$$

DROP PROCEDURE IF EXISTS `FillPayslipDetail`$$
CREATE DEFINER=`root`@`localhost` PROCEDURE `FillPayslipDetail` (IN `p_userID` INT, IN `p_date` DATE)   BEGIN
    DECLARE CONTINUE HANDLER FOR SQLEXCEPTION
    BEGIN
        ROLLBACK;
    END;

    START TRANSACTION;
	
    CALL `UpdatePayrollAllowance`(p_userID, p_date);
    SELECT `CalculateSubTotalHour`(p_userID, p_date);
	SELECT `CalculateTotalHours`(p_userID, p_date);
    SELECT `CalculatPayslipTotalHour`(p_userID, p_date);
	SELECT `CalculatPayslipSubTotal`(p_userID, p_date);
	SELECT `CalculateSSSDeduction`(p_userID, p_date);
    SELECT `CalculateDeduction`(p_userID, p_date);
    SELECT `CalculateTotalSalary`(p_userID, p_date);

    COMMIT;
    
END$$

DROP PROCEDURE IF EXISTS `GenerateDTRTicket`$$
CREATE DEFINER=`root`@`localhost` PROCEDURE `GenerateDTRTicket` (IN `p_dtrID` INT, IN `p_userID` INT, IN `p_description` VARCHAR(255))   INSERT INTO dtrtickets (dtrID, userID, dtrTicketDescription, dtrTicketDateRecieved)
VALUES (p_dtrID, p_userID, p_description, CURDATE())$$

DROP PROCEDURE IF EXISTS `GenerateDTRTotalHours`$$
CREATE DEFINER=`root`@`localhost` PROCEDURE `GenerateDTRTotalHours` ()   BEGIN
    UPDATE dtr
    SET totalHours = CalculateTotalHours(clockouttime, clockintime)
    WHERE DATE(dtrDate) = CURDATE();
END$$

DROP PROCEDURE IF EXISTS `GeneratePayslipDetails`$$
CREATE DEFINER=`root`@`localhost` PROCEDURE `GeneratePayslipDetails` ()   BEGIN
    DECLARE retpayslipID INT;
    DECLARE done INT DEFAULT FALSE;
    DECLARE allUserID INT;
    DECLARE cur_user CURSOR FOR SELECT userID FROM account;
    DECLARE CONTINUE HANDLER FOR NOT FOUND SET done = TRUE;

    START TRANSACTION;

    OPEN cur_user;

    user_loop: LOOP
        FETCH cur_user INTO allUserID;

        IF done THEN
            LEAVE user_loop;
        END IF;

        SELECT payslipID INTO retpayslipID
        FROM payslip
        WHERE CURDATE() BETWEEN startDate AND endDate;

        IF retpayslipID IS NOT NULL THEN
            INSERT IGNORE INTO payslipdetail (payslipID, userID, totalHours, subtotal, allowance, deduction, totalSalary)
            VALUES (retpayslipID, allUserID, 0, 0, 0, 0, 0);
        END IF;
    END LOOP;

    CLOSE cur_user;

    COMMIT;
END$$

DROP PROCEDURE IF EXISTS `getAccDetails`$$
CREATE DEFINER=`root`@`localhost` PROCEDURE `getAccDetails` (IN `p_staffID` INT)   SELECT
	a.*,
	stf.firstName,
	stf.lastName,
	stf.sex,
	stf.DOB,
	stf.position,
	stf.salary,
	stf.allowance,
    stf.SSS,
    stf.PagIbig,
    stf.PhilHealth,
	stf.stationNo,
    dtr.clockintime,
    dtr.clockedIn,
    dtr.clockouttime,
    dtr.clockedOut
FROM account a
JOIN staff stf ON a.staffID = stf.staffID
LEFT JOIN dtr dtr ON a.userID = dtr.userID AND DATE(dtr.dtrDate) = CURDATE()
Where a.staffID = p_staffID$$

DROP PROCEDURE IF EXISTS `getAllUserID`$$
CREATE DEFINER=`root`@`localhost` PROCEDURE `getAllUserID` ()   SELECT a.userID
FROM account a$$

DROP PROCEDURE IF EXISTS `GetDates`$$
CREATE DEFINER=`root`@`localhost` PROCEDURE `GetDates` ()   SELECT DISTINCT(d.dtrDate),
	d.holiday
FROM dtr d$$

DROP PROCEDURE IF EXISTS `GetDTRFromDTRTickets`$$
CREATE DEFINER=`root`@`localhost` PROCEDURE `GetDTRFromDTRTickets` (IN `p_dtrTicketID` INT)   SELECT
	dt.dtrID,
    dt.userID,
    dt.clockintime,
    dt.clockedIn,
    dt.clockouttime,
    dt.clockedOut,
    dt.dtrDate,
    dtrs.dtrTicketID,
    dtrs.resolverName,
	dtrs.dtrTicketDescription,
    dtrs.dtrTicketRemarks,
    dtrs.dtrTicketStatus,
    dtrs.dtrTicketDateRecieved,
    dtrs.dtrTicketDateResolved
FROM dtr dt
JOIN dtrtickets dtrs ON dtrs.dtrID = dt.dtrID
WHERE dtrs.dtrTicketID = p_dtrTicketID$$

DROP PROCEDURE IF EXISTS `GetEventLogs`$$
CREATE DEFINER=`root`@`localhost` PROCEDURE `GetEventLogs` ()   SELECT 
    e.userID,
    e.serverID,
    CONCAT(e.eventDate, ' ', e.eventTime) AS eventDateTime,
    e.eventDescription
FROM eventlog e
WHERE DATE(e.eventDate) BETWEEN CURDATE() - INTERVAL 2 DAY AND NOW()$$

DROP PROCEDURE IF EXISTS `getLogin`$$
CREATE DEFINER=`root`@`localhost` PROCEDURE `getLogin` (IN `usn` VARCHAR(50), IN `pass` VARCHAR(50))   SELECT * FROM account WHERE username = usn AND password = pass$$

DROP PROCEDURE IF EXISTS `getNthPayslip`$$
CREATE DEFINER=`root`@`localhost` PROCEDURE `getNthPayslip` ()   SELECT
    a.userID,
    p.nthPayslip
FROM
    account a
LEFT JOIN
    payslip p
ON p.userID = a.userID
WHERE CURRENT_DATE BETWEEN p.startDate AND p.endDate$$

DROP PROCEDURE IF EXISTS `GetPayslip`$$
CREATE DEFINER=`root`@`localhost` PROCEDURE `GetPayslip` (IN `p_userID` INT)   SELECT 
	CONCAT(ps.payslipID, '-', psd.payslipDetailID) AS combined_column,
	ps.payslipID,
    ps.startDate,
    ps.endDate,
	psd.payslipDetailID,
    psd.userID,
    psd.totalHours,
    psd.subtotal,
    psd.allowance,
    psd.deduction,
    psd.totalSalary
FROM payslip as ps
INNER JOIN payslipdetail as psd on psd.payslipID = ps.payslipID
WHERE CURDATE() > endDate AND psd.userID = p_userID$$

DROP PROCEDURE IF EXISTS `GetPayslipDTR`$$
CREATE DEFINER=`root`@`localhost` PROCEDURE `GetPayslipDTR` (IN `p_userID` INT, IN `p_payslipID` INT)   SELECT 
    d.dtrDate,
    CAST((d.totalHours * (s.salary / 8 / 6)) AS DECIMAL(10, 2)) AS totalHour
FROM dtr d
JOIN account a ON a.userID = d.userID
JOIN staff s ON s.staffID = a.staffID
WHERE d.userID = p_userID AND d.payslipID = p_payslipID$$

DROP PROCEDURE IF EXISTS `GetPayslipInfo`$$
CREATE DEFINER=`root`@`localhost` PROCEDURE `GetPayslipInfo` (IN `p_userID` INT, IN `p_payslipID` INT)   SELECT 
	a.userID,
    s.firstName,
    s.lastName,
    s.position,
    s.salary,
    CAST((s.salary / 6) AS DECIMAL(10, 2))as daily,
    CAST((s.salary / 8 / 6) AS DECIMAL(10,2)) as hourly,
    CAST((psd.subtotal + psd.allowance) AS DECIMAL (10,2))as totalEarnings,
    s.allowance,
    s.stationNo,
    si.SSS,
    si.PagIbig,
    si.PhilHealth,
    ps.startDate,
    ps.endDate,
    psd.totalHours,
    psd.subtotal,
    psd.SSSDeduction,
    psd.deduction,
    psd.totalSalary
	
FROM staff s
LEFT JOIN account a ON a.staffID = s.staffID
LEFT JOIN staffinsurance si ON si.userID = a.userID
LEFT JOIN payslipdetail psd ON psd.userID = a.userID
LEFT JOIN payslip ps ON ps.payslipID = psd.payslipID
WHERE a.userID = p_userID AND ps.payslipID = p_payslipID$$

DROP PROCEDURE IF EXISTS `GetSpecificDTR`$$
CREATE DEFINER=`root`@`localhost` PROCEDURE `GetSpecificDTR` (IN `p_dtrID` INT)   SELECT
	dtrID,
	dtrDate
FROM dtr
WHERE dtrID = p_dtrID$$

DROP PROCEDURE IF EXISTS `GetTotalNumberOfLogs`$$
CREATE DEFINER=`root`@`localhost` PROCEDURE `GetTotalNumberOfLogs` ()   SELECT COUNT(e.logID) AS TotalRows
FROM eventlog e
WHERE e.eventDate BETWEEN DATE_SUB(CURDATE(), INTERVAL 2 DAY) AND CURDATE()$$

DROP PROCEDURE IF EXISTS `getUserAcc`$$
CREATE DEFINER=`root`@`localhost` PROCEDURE `getUserAcc` (IN `p_search` VARCHAR(50))   SELECT
    a.staffID as Staff_ID,
    a.isEnabled as Locked,
    a.accountLevel as Restriction,
    a.username as Username,
    stf.firstName as Firstname,
    stf.lastName as Lastname,
    stf.position as Position,
    stf.stationNo as Station_No
FROM account a
JOIN staff stf ON a.staffID = stf.staffID
WHERE a.username LIKE CONCAT('%', p_search, '%')
OR stf.firstName LIKE CONCAT('%', p_search, '%')
OR stf.lastName LIKE CONCAT('%', p_search, '%')$$

DROP PROCEDURE IF EXISTS `getUserDTR`$$
CREATE DEFINER=`root`@`localhost` PROCEDURE `getUserDTR` (IN `p_userID` INT)   SELECT
	dtr.dtrID,
	dtr.dtrDate,
    dtr.clockintime,
    dtr.clockedIn,
    dtr.clockouttime,
    dtr.clockedOut,
    dtr.totalHours
FROM dtr 
WHERE DATE(dtrDate) <= CURDATE() AND userID = p_userID
ORDER BY dtr.dtrDate ASC$$

DROP PROCEDURE IF EXISTS `LoginServer`$$
CREATE DEFINER=`root`@`localhost` PROCEDURE `LoginServer` (IN `p_username` VARCHAR(50), IN `p_password` VARCHAR(50))   SELECT *
FROM serverstatus st
WHERE st.serverName = p_username AND st.serverPassword = p_password$$

DROP PROCEDURE IF EXISTS `loginStatus`$$
CREATE DEFINER=`root`@`localhost` PROCEDURE `loginStatus` (IN `p_status` INT, IN `p_userID` INT)   UPDATE account
SET account.isLoggedIn = p_status
WHERE account.userID = p_userID$$

DROP PROCEDURE IF EXISTS `ProcessPayrollForAllUsers`$$
CREATE DEFINER=`root`@`localhost` PROCEDURE `ProcessPayrollForAllUsers` ()   BEGIN
    DECLARE done INT DEFAULT FALSE;
    DECLARE allUserID INT;
    DECLARE cur_user CURSOR FOR SELECT userID FROM account;
    
    DECLARE CONTINUE HANDLER FOR SQLEXCEPTION
    BEGIN
        ROLLBACK;
        SIGNAL SQLSTATE '45000' SET MESSAGE_TEXT = 'An error occurred, transaction rolled back';
    END;

    DECLARE EXIT HANDLER FOR NOT FOUND
    BEGIN
        SET done = TRUE;
    END;

    START TRANSACTION;

    OPEN cur_user;

    user_loop: LOOP
        FETCH cur_user INTO allUserID;

        IF done THEN
            LEAVE user_loop;
        END IF;

        CALL `UpdatePayrollAllowance`(allUserID, CURDATE());
        SELECT `CalculateSubTotalHour`(allUserID, CURDATE());
        SELECT `CalculateTotalHours`(allUserID, CURDATE());
        SELECT `CalculatPayslipTotalHour`(allUserID, CURDATE());
        SELECT `CalculatPayslipSubTotal`(allUserID, CURDATE());
        SELECT `CalculateSSSDeduction`(allUserID, CURDATE());
        SELECT `CalculateDeduction`(allUserID, CURDATE());
        SELECT `CalculateTotalSalary`(allUserID, CURDATE());
    END LOOP;

    CLOSE cur_user;

    COMMIT;
END$$

DROP PROCEDURE IF EXISTS `registerAccount`$$
CREATE DEFINER=`root`@`localhost` PROCEDURE `registerAccount` (IN `p_firstName` VARCHAR(50), IN `p_lastName` VARCHAR(50), IN `p_sex` VARCHAR(50), IN `p_DOB` DATETIME, IN `p_position` VARCHAR(50), IN `p_salary` DECIMAL(18,2), IN `p_allowance` DECIMAL(18,2), IN `p_stationNo` VARCHAR(50), IN `p_username` VARCHAR(50), IN `p_password` VARCHAR(50), IN `p_isEnabled` DOUBLE, IN `p_accountLevel` VARCHAR(50))   BEGIN
    DECLARE generatedStaffID INT;

    -- Step 1: Insert data into the "staff" table
    INSERT INTO staff ( firstName, lastName, sex, DOB, position, salary, allowance, stationNo)
    VALUES ( p_firstName, p_lastName, p_sex, p_DOB, p_position, p_salary, p_allowance, p_stationNo);

    -- Retrieve the generated staffID
    SET generatedStaffID = LAST_INSERT_ID();

    -- Step 2: Insert data into the "account" table
    INSERT INTO account (staffID, username, password, isEnabled, accountLevel)
    VALUES (generatedStaffID, p_username, p_password, p_isEnabled, p_accountLevel);

	INSERT INTO staffinsurance(useriD, SSS, PagIbig, PhilHealth)
	VALUES (generatedStaffID, 10, 250, 100);
END$$

DROP PROCEDURE IF EXISTS `ResetDTRClockIn`$$
CREATE DEFINER=`root`@`localhost` PROCEDURE `ResetDTRClockIn` (IN `p_dtrID` INT)   UPDATE dtr dt
SET dt.clockintime = CONCAT(DATE(dt.dtrDate), ' 08:00:00'),
	dt.clockedIn = 1
WHERE dt.dtrID = p_dtrID$$

DROP PROCEDURE IF EXISTS `ResetDTRClockOut`$$
CREATE DEFINER=`root`@`localhost` PROCEDURE `ResetDTRClockOut` (IN `p_dtrID` INT)   UPDATE dtr dt
SET dt.clockouttime = CONCAT(DATE(dt.dtrDate), ' 17:00:00'),
	dt.clockedOut = 1
WHERE dt.dtrID = p_dtrID$$

DROP PROCEDURE IF EXISTS `SetLoginToZero`$$
CREATE DEFINER=`root`@`localhost` PROCEDURE `SetLoginToZero` ()   UPDATE account a
SET a.isLoggedIn = 0$$

DROP PROCEDURE IF EXISTS `ShowDTRTickets`$$
CREATE DEFINER=`root`@`localhost` PROCEDURE `ShowDTRTickets` (IN `p_status` INT, IN `p_userID` INT)   SELECT *
FROM dtrtickets dt
WHERE (p_status = '' OR dt.dtrTicketStatus = p_status)
  AND (p_userID = '' OR dt.userID = p_userID)$$

DROP PROCEDURE IF EXISTS `updateAccountPassword`$$
CREATE DEFINER=`root`@`localhost` PROCEDURE `updateAccountPassword` (IN `p_password` VARCHAR(50), IN `p_staffID` DOUBLE)   UPDATE account
SET account.password = p_password
WHERE account.staffID = p_staffID$$

DROP PROCEDURE IF EXISTS `UpdateDTRHoliday`$$
CREATE DEFINER=`root`@`localhost` PROCEDURE `UpdateDTRHoliday` (IN `p_holidayNum` INT, IN `p_dtrDate` DATE)   UPDATE dtr d
SET d.holiday = p_holidayNum
WHERE d.dtrDate = p_dtrDate$$

DROP PROCEDURE IF EXISTS `UpdateDTRTickets`$$
CREATE DEFINER=`root`@`localhost` PROCEDURE `UpdateDTRTickets` (IN `p_resolverName` VARCHAR(50), IN `p_remarks` VARCHAR(255), IN `p_status` INT, IN `p_ticketID` INT)   UPDATE dtrtickets dts
SET 
	dts.resolverName = p_resolverName,
    dts.dtrTicketRemarks = p_remarks,
    dts.dtrTicketDateResolved = CURDATE(),
    dts.dtrTicketStatus = p_status
WHERE dts.dtrTicketID = p_ticketID$$

DROP PROCEDURE IF EXISTS `UpdateLoginStatus`$$
CREATE DEFINER=`root`@`localhost` PROCEDURE `UpdateLoginStatus` (IN `p_userID` INT)   UPDATE account
SET isLoggedIn = 0
WHERE userID = p_userID$$

DROP PROCEDURE IF EXISTS `UpdatePayrollAllowance`$$
CREATE DEFINER=`root`@`localhost` PROCEDURE `UpdatePayrollAllowance` (IN `p_userID` INT, IN `p_date` DATE)   UPDATE payslipdetail pd
JOIN account a ON a.userID = pd.userID
INNER JOIN staff s ON s.staffID = a.staffID
SET pd.allowance = s.allowance
WHERE pd.userID = p_userID AND pd.payslipID IN (
    SELECT payslipID
    FROM payslip
    WHERE p_date BETWEEN startDate AND endDate
)$$

--
-- Functions
--
DROP FUNCTION IF EXISTS `CalculateDeduction`$$
CREATE DEFINER=`root`@`localhost` FUNCTION `CalculateDeduction` (`p_userID` INT, `p_date` DATE) RETURNS DECIMAL(10,6)  BEGIN
	DECLARE p_payslipID INT;
    DECLARE p_deduction DECIMAL(10, 6);
    
    SELECT payslipID
    INTO p_payslipID
    FROM payslip
    WHERE p_date BETWEEN startDate AND endDate;
    
    SELECT pd.SSSDeduction + si.PagIbig + si.PhilHealth
	INTO p_deduction
    FROM payslipdetail pd
    JOIN account a ON a.userID = pd.userID
    JOIN staff s ON s.staffID = a.staffID
    JOIN staffinsurance si ON si.userID = a.userID
    WHERE pd.userID = p_userID AND pd.payslipID = p_payslipID;

	UPDATE payslipdetail
    SET deduction = p_deduction
    WHERE userID = p_userid AND payslipID = p_payslipID;
    
RETURN p_deduction;
END$$

DROP FUNCTION IF EXISTS `CalculateSSSDeduction`$$
CREATE DEFINER=`root`@`localhost` FUNCTION `CalculateSSSDeduction` (`p_userID` INT, `p_date` DATE) RETURNS DECIMAL(10,6)  BEGIN
	DECLARE p_payslipID INT;
    DECLARE sss_deduction DECIMAL(10, 6);
    
    SELECT payslipID
    INTO p_payslipID
    FROM payslip
    WHERE p_date BETWEEN startDate AND endDate;
    
    SELECT (pd.subtotal * (si.SSS/100))
	INTO sss_deduction
    FROM payslipdetail pd
    JOIN account a ON a.userID = pd.userID
    JOIN staff s ON s.staffID = a.staffID
    JOIN staffinsurance si ON si.userID = a.userID
    WHERE pd.userID = p_userID AND pd.payslipID = p_payslipID;

	UPDATE payslipdetail
    SET SSSDeduction = sss_deduction
    WHERE userID = p_userid AND payslipID = p_payslipID;
    
RETURN sss_deduction;
END$$

DROP FUNCTION IF EXISTS `CalculateSubTotalHour`$$
CREATE DEFINER=`root`@`localhost` FUNCTION `CalculateSubTotalHour` (`p_userID` INT, `p_date` DATE) RETURNS DECIMAL(10,6)  BEGIN
    DECLARE total_seconds INT;
    DECLARE subtotal_hours DECIMAL(10, 6); -- Increase precision
    
    SELECT TIME_TO_SEC(TIMEDIFF(dtr.clockouttime, dtr.clockintime))
    INTO total_seconds
	FROM dtr
	WHERE dtr.userID = p_userID AND DATE(dtr.dtrDate) = p_date;
    
    SET subtotal_hours = total_seconds / 3600.0;
    
    -- Check if total_hours is greater than 5 and subtract 1 if true
    IF subtotal_hours > 5 THEN
        SET subtotal_hours = subtotal_hours - 1;
    END IF;
    
    UPDATE dtr
    SET subtotalHour = subtotal_hours
    WHERE dtr.userID = p_userid AND dtr.dtrDate = p_date;

    RETURN subtotal_hours;
END$$

DROP FUNCTION IF EXISTS `CalculateTotalHours`$$
CREATE DEFINER=`root`@`localhost` FUNCTION `CalculateTotalHours` (`p_userID` INT, `p_date` DATE) RETURNS DECIMAL(10,6)  BEGIN
    DECLARE p_payslipID INT;
    DECLARE new_total DECIMAL(10, 6);

    SELECT payslipID
    INTO p_payslipID
    FROM payslip
    WHERE p_date BETWEEN startDate AND endDate;
    
    SELECT 
        CASE dtr.holiday
            WHEN 1 THEN dtr.subtotalHour + (dtr.subtotalHour * 1.0) -- 100% increase
            WHEN 2 THEN dtr.subtotalHour + (dtr.subtotalHour * 1.5) -- 150% increase
            WHEN 3 THEN dtr.subtotalHour + (dtr.subtotalHour * 1.9) -- 190% increase
            ELSE dtr.subtotalHour -- Default case (including WHEN 0)
        END
        INTO new_total
    FROM dtr
    WHERE dtr.userID = p_userid AND dtr.dtrDate = p_date;
    
    UPDATE dtr
    SET totalHours = new_total
    WHERE dtr.userID = p_userid AND dtr.dtrDate = p_date;

    RETURN new_total;
END$$

DROP FUNCTION IF EXISTS `CalculateTotalSalary`$$
CREATE DEFINER=`root`@`localhost` FUNCTION `CalculateTotalSalary` (`p_userID` INT, `p_date` DATE) RETURNS DECIMAL(10,2)  BEGIN
    DECLARE p_payslipID INT;
    DECLARE total_salary DECIMAL(10, 2);
    DECLARE deducted_subtotal DECIMAL(10,2);

    SELECT payslipID
    INTO p_payslipID
    FROM payslip
    WHERE p_date BETWEEN startDate AND endDate;
	
    SELECT
    	(pd.subtotal - pd.deduction)
    END INTO deducted_subtotal
	FROM payslipdetail pd
	WHERE pd.userID = p_userID AND pd.payslipID = p_payslipID;
    
    SELECT
    	pd.allowance + deducted_subtotal
    END INTO total_salary
	FROM payslipdetail pd
	WHERE pd.userID = p_userID AND pd.payslipID = p_payslipID;

    UPDATE payslipdetail
    SET totalSalary = total_salary
    WHERE userID = p_userid AND payslipID = p_payslipID;

    RETURN total_salary;
END$$

DROP FUNCTION IF EXISTS `CalculatPayslipSubTotal`$$
CREATE DEFINER=`root`@`localhost` FUNCTION `CalculatPayslipSubTotal` (`p_userid` INT, `p_date` DATE) RETURNS DECIMAL(10,6)  BEGIN
    DECLARE p_payslipID INT;
    DECLARE sub_total DECIMAL(10, 6);

    SELECT payslipID
    INTO p_payslipID
    FROM payslip
    WHERE p_date BETWEEN startDate AND endDate;

    SELECT (pd.totalHours * (s.salary / 8 / 6))
    INTO sub_total
    FROM payslipdetail pd
    JOIN account a ON a.userID = pd.userID
    JOIN staff s ON s.staffID = a.staffID
    WHERE pd.userID = p_userid AND pd.payslipID = p_payslipID;

    UPDATE payslipdetail
    SET subtotal = sub_total
    WHERE userID = p_userid AND payslipID = p_payslipID;

    RETURN sub_total;
END$$

DROP FUNCTION IF EXISTS `CalculatPayslipTotalHour`$$
CREATE DEFINER=`root`@`localhost` FUNCTION `CalculatPayslipTotalHour` (`p_userid` INT, `p_date` DATE) RETURNS DECIMAL(10,6)  BEGIN
    DECLARE p_payslipID INT;
    DECLARE new_total DECIMAL(10, 6);

    -- Find the payslipID for the current date
    SELECT payslipID
    INTO p_payslipID
    FROM payslip
    WHERE p_date BETWEEN startDate AND endDate;
    
    SELECT SUM(totalHours)
    INTO new_total
    FROM dtr
    WHERE userID = p_userid AND payslipID = p_payslipID;

    -- Update the payslipdetail table
    UPDATE payslipdetail
    SET totalHours = new_total
    WHERE userID = p_userid AND payslipID = p_payslipID;

    RETURN new_total;
END$$

DELIMITER ;

-- --------------------------------------------------------

--
-- Table structure for table `account`
--

DROP TABLE IF EXISTS `account`;
CREATE TABLE IF NOT EXISTS `account` (
  `userID` int NOT NULL AUTO_INCREMENT,
  `staffID` int NOT NULL,
  `username` varchar(50) NOT NULL,
  `password` varchar(50) NOT NULL,
  `isEnabled` int NOT NULL DEFAULT '1',
  `accountLevel` int NOT NULL DEFAULT '1',
  `isLoggedIn` int NOT NULL,
  PRIMARY KEY (`userID`),
  UNIQUE KEY `userID_Unique` (`userID`) USING BTREE,
  KEY `username_Index` (`username`) USING BTREE,
  KEY `staffID` (`staffID`)
) ENGINE=InnoDB AUTO_INCREMENT=35 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

--
-- Dumping data for table `account`
--

INSERT INTO `account` (`userID`, `staffID`, `username`, `password`, `isEnabled`, `accountLevel`, `isLoggedIn`) VALUES
(1, 1, 'johnrey.silverio', 'berio123', 1, 2, 0),
(2, 2, 'laurence.silverio', 'laurence', 1, 2, 0),
(3, 3, 'username.password', 'password', 1, 1, 0),
(5, 5, 'test.test', 'test1234', 0, 1, 0),
(7, 7, 'johnmatheow.morillo', 'cho12345', 1, 1, 0),
(27, 27, 'kontra.dengue', '7aQxW', 1, 1, 0),
(31, 31, 'donotadjust.theaircon', 'EL628', 1, 1, 0),
(32, 32, 'payroll.system', 'bd4u4', 1, 2, 0),
(33, 33, 'strength.weakness', 'iaiuH', 1, 1, 0);

--
-- Triggers `account`
--
DROP TRIGGER IF EXISTS `DeleteAccountAndRelatedRows`;
DELIMITER $$
CREATE TRIGGER `DeleteAccountAndRelatedRows` AFTER DELETE ON `account` FOR EACH ROW BEGIN
    DELETE FROM staff WHERE staffID = OLD.staffID;
    DELETE FROM dtr WHERE userID = OLD.staffID;
    DELETE FROM payslipdetail WHERE userID = OLD.staffID;
    DELETE FROM staffinsurance WHERE userID = OLD.staffID;
END
$$
DELIMITER ;

-- --------------------------------------------------------

--
-- Table structure for table `dtr`
--

DROP TABLE IF EXISTS `dtr`;
CREATE TABLE IF NOT EXISTS `dtr` (
  `dtrID` int NOT NULL AUTO_INCREMENT,
  `payslipID` int NOT NULL,
  `userID` int NOT NULL,
  `clockintime` datetime DEFAULT NULL,
  `clockedIn` tinyint NOT NULL DEFAULT '0',
  `clockouttime` datetime DEFAULT NULL,
  `clockedOut` tinyint NOT NULL DEFAULT '0',
  `subtotalHour` decimal(10,6) DEFAULT '0.000000',
  `totalHours` decimal(10,6) DEFAULT '0.000000',
  `holiday` int NOT NULL DEFAULT '0',
  `dtrDate` date NOT NULL,
  PRIMARY KEY (`dtrID`),
  UNIQUE KEY `dtrID_Unique` (`dtrID`) USING BTREE,
  KEY `dtrID_Index` (`dtrID`) USING BTREE
) ENGINE=InnoDB AUTO_INCREMENT=474 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

--
-- Dumping data for table `dtr`
--

INSERT INTO `dtr` (`dtrID`, `payslipID`, `userID`, `clockintime`, `clockedIn`, `clockouttime`, `clockedOut`, `subtotalHour`, `totalHours`, `holiday`, `dtrDate`) VALUES
(250, 7, 1, NULL, 0, NULL, 0, NULL, NULL, 0, '2023-10-29'),
(251, 7, 1, NULL, 0, NULL, 0, '0.000000', '0.000000', 0, '2023-10-30'),
(252, 7, 1, NULL, 0, NULL, 0, '0.000000', '0.000000', 0, '2023-10-31'),
(253, 7, 1, '2023-11-01 08:00:00', 1, '2023-11-01 17:00:00', 1, '8.000000', '16.000000', 1, '2023-11-01'),
(254, 7, 1, '2023-11-02 09:15:16', 1, '2023-11-02 15:40:12', 1, '5.415556', '10.831112', 1, '2023-11-02'),
(255, 7, 1, '2023-11-03 08:25:39', 1, '2023-11-03 22:51:38', 1, '13.433056', '13.433056', 0, '2023-11-03'),
(256, 7, 1, '2023-11-04 20:29:33', 1, '2023-11-04 22:16:28', 1, '1.781944', '1.781944', 0, '2023-11-04'),
(257, 7, 2, NULL, 0, NULL, 0, NULL, NULL, 0, '2023-10-29'),
(258, 7, 2, NULL, 0, NULL, 0, '0.000000', '0.000000', 0, '2023-10-30'),
(259, 7, 2, NULL, 0, NULL, 0, '0.000000', '0.000000', 0, '2023-10-31'),
(260, 7, 2, NULL, 0, NULL, 0, NULL, NULL, 1, '2023-11-01'),
(261, 7, 2, '2023-11-02 20:01:41', 1, '2023-11-02 20:06:43', 1, '0.083889', '0.167778', 1, '2023-11-02'),
(262, 7, 2, '2023-11-03 08:25:56', 1, '2023-11-03 22:51:59', 1, '13.434167', '13.434167', 0, '2023-11-03'),
(263, 7, 2, '2023-11-04 20:30:17', 1, '2023-11-04 22:34:48', 1, '2.075278', '2.075278', 0, '2023-11-04'),
(264, 7, 3, NULL, 0, NULL, 0, NULL, NULL, 0, '2023-10-29'),
(265, 7, 3, NULL, 0, NULL, 0, '0.000000', '0.000000', 0, '2023-10-30'),
(266, 7, 3, NULL, 0, NULL, 0, '0.000000', '0.000000', 0, '2023-10-31'),
(267, 7, 3, NULL, 0, NULL, 0, NULL, NULL, 1, '2023-11-01'),
(268, 7, 3, '2023-11-02 20:17:53', 1, '2023-11-02 20:21:15', 1, '0.056111', '0.112222', 1, '2023-11-02'),
(269, 7, 3, '2023-11-03 08:26:21', 1, '2023-11-03 22:52:16', 1, '13.431944', '13.431944', 0, '2023-11-03'),
(270, 7, 3, '2023-11-04 20:30:39', 1, '2023-11-04 22:35:01', 1, '2.072778', '2.072778', 0, '2023-11-04'),
(271, 7, 5, NULL, 0, NULL, 0, NULL, NULL, 0, '2023-10-29'),
(272, 7, 5, NULL, 0, NULL, 0, '0.000000', '0.000000', 0, '2023-10-30'),
(273, 7, 5, NULL, 0, NULL, 0, '0.000000', '0.000000', 0, '2023-10-31'),
(274, 7, 5, NULL, 0, NULL, 0, NULL, NULL, 1, '2023-11-01'),
(275, 7, 5, NULL, 0, NULL, 0, NULL, NULL, 1, '2023-11-02'),
(276, 7, 5, NULL, 0, NULL, 0, NULL, NULL, 0, '2023-11-03'),
(277, 7, 5, NULL, 0, NULL, 0, NULL, NULL, 0, '2023-11-04'),
(278, 7, 7, NULL, 0, NULL, 0, NULL, NULL, 0, '2023-10-29'),
(279, 7, 7, NULL, 0, NULL, 0, '0.000000', '0.000000', 0, '2023-10-30'),
(280, 7, 7, NULL, 0, NULL, 0, '0.000000', '0.000000', 0, '2023-10-31'),
(281, 7, 7, NULL, 0, NULL, 0, NULL, NULL, 1, '2023-11-01'),
(282, 7, 7, '2023-11-02 20:10:40', 1, '2023-11-02 20:13:49', 1, '0.052500', '0.105000', 1, '2023-11-02'),
(283, 7, 7, '2023-11-03 08:26:33', 1, '2023-11-03 22:52:41', 1, '13.435556', '13.435556', 0, '2023-11-03'),
(284, 7, 7, '2023-11-04 20:30:30', 1, '2023-11-04 22:27:51', 1, '1.955833', '1.955833', 0, '2023-11-04'),
(292, 9, 1, '2023-11-05 08:32:41', 1, '2023-11-05 17:03:14', 1, '0.000000', '7.509167', 0, '2023-11-05'),
(293, 9, 1, '2023-11-06 08:14:05', 1, '2023-11-06 22:14:55', 1, '13.013889', '13.013889', 0, '2023-11-06'),
(294, 9, 1, '2023-11-07 10:43:14', 1, '2023-11-07 17:00:00', 1, '5.279444', '5.279444', 0, '2023-11-07'),
(295, 9, 1, '2023-11-08 10:37:38', 1, '2023-11-08 17:00:00', 1, '5.372778', '5.372778', 0, '2023-11-08'),
(296, 9, 1, '2023-11-09 18:46:36', 1, '2023-11-09 18:46:48', 1, '0.003333', '0.003333', 0, '2023-11-09'),
(297, 9, 1, '2023-11-10 11:17:29', 1, NULL, 0, NULL, NULL, 0, '2023-11-10'),
(298, 9, 1, NULL, 0, NULL, 0, '0.000000', '0.000000', 0, '2023-11-11'),
(299, 9, 2, '2023-11-05 08:33:04', 1, '2023-11-05 19:08:26', 1, '0.000000', '9.589444', 0, '2023-11-05'),
(300, 9, 2, '2023-11-06 08:14:25', 1, '2023-11-06 22:15:11', 1, '13.012778', '13.012778', 0, '2023-11-06'),
(301, 9, 2, '2023-11-07 10:43:26', 1, '2023-11-07 17:00:00', 1, '5.276111', '5.276111', 0, '2023-11-07'),
(302, 9, 2, '2023-11-08 10:37:48', 1, NULL, 0, NULL, NULL, 0, '2023-11-08'),
(303, 9, 2, '2023-11-09 20:31:43', 1, '2023-11-09 20:31:50', 1, '0.001944', '0.001944', 0, '2023-11-09'),
(304, 9, 2, NULL, 0, NULL, 0, NULL, NULL, 0, '2023-11-10'),
(305, 9, 2, NULL, 0, NULL, 0, '0.000000', '0.000000', 0, '2023-11-11'),
(306, 9, 3, '2023-11-05 08:33:20', 1, '2023-11-05 19:08:38', 1, '0.000000', '9.588333', 0, '2023-11-05'),
(307, 9, 3, '2023-11-06 08:14:36', 1, '2023-11-06 22:15:25', 1, '13.013611', '13.013611', 0, '2023-11-06'),
(308, 9, 3, '2023-11-07 10:43:50', 1, NULL, 0, NULL, NULL, 0, '2023-11-07'),
(309, 9, 3, NULL, 0, NULL, 0, NULL, NULL, 0, '2023-11-08'),
(310, 9, 3, NULL, 0, NULL, 0, NULL, NULL, 0, '2023-11-09'),
(311, 9, 3, NULL, 0, NULL, 0, NULL, NULL, 0, '2023-11-10'),
(312, 9, 3, NULL, 0, NULL, 0, '0.000000', '0.000000', 0, '2023-11-11'),
(313, 9, 5, NULL, 0, NULL, 0, '0.000000', '0.000000', 0, '2023-11-05'),
(314, 9, 5, NULL, 0, NULL, 0, NULL, NULL, 0, '2023-11-06'),
(315, 9, 5, NULL, 0, NULL, 0, NULL, NULL, 0, '2023-11-07'),
(316, 9, 5, NULL, 0, NULL, 0, NULL, NULL, 0, '2023-11-08'),
(317, 9, 5, NULL, 0, NULL, 0, NULL, NULL, 0, '2023-11-09'),
(318, 9, 5, NULL, 0, NULL, 0, NULL, NULL, 0, '2023-11-10'),
(319, 9, 5, NULL, 0, NULL, 0, '0.000000', '0.000000', 0, '2023-11-11'),
(320, 9, 7, '2023-11-05 08:33:35', 1, '2023-11-05 19:08:52', 1, '0.000000', '9.588056', 0, '2023-11-05'),
(321, 9, 7, '2023-11-06 08:14:49', 1, '2023-11-06 22:15:37', 1, '13.013333', '13.013333', 0, '2023-11-06'),
(322, 9, 7, '2023-11-07 10:43:41', 1, '2023-11-07 17:00:00', 1, '5.271944', '5.271944', 0, '2023-11-07'),
(323, 9, 7, '2023-11-08 10:38:36', 1, NULL, 0, NULL, NULL, 0, '2023-11-08'),
(324, 9, 7, '2023-11-09 20:35:20', 1, '2023-11-09 20:36:48', 1, '0.024444', '0.024444', 0, '2023-11-09'),
(325, 9, 7, '2023-11-10 13:17:19', 1, NULL, 0, NULL, NULL, 0, '2023-11-10'),
(326, 9, 7, NULL, 0, NULL, 0, '0.000000', '0.000000', 0, '2023-11-11'),
(341, 9, 27, NULL, 0, NULL, 0, '0.000000', '0.000000', 0, '2023-11-05'),
(342, 9, 27, '2023-11-06 08:15:01', 1, '2023-11-06 22:16:16', 1, '13.020833', '13.020833', 0, '2023-11-06'),
(343, 9, 27, '2023-11-07 10:44:08', 1, NULL, 0, NULL, NULL, 0, '2023-11-07'),
(344, 9, 27, NULL, 0, NULL, 0, NULL, NULL, 0, '2023-11-08'),
(345, 9, 27, NULL, 0, NULL, 0, NULL, NULL, 0, '2023-11-09'),
(346, 9, 27, NULL, 0, NULL, 0, NULL, NULL, 0, '2023-11-10'),
(347, 9, 27, NULL, 0, NULL, 0, '0.000000', '0.000000', 0, '2023-11-11'),
(411, 20, 1, NULL, 0, NULL, 0, '0.000000', '0.000000', 0, '2023-11-19'),
(412, 20, 1, NULL, 0, NULL, 0, '0.000000', '0.000000', 0, '2023-11-20'),
(413, 20, 1, NULL, 0, NULL, 0, '0.000000', '0.000000', 0, '2023-11-21'),
(414, 20, 1, NULL, 0, NULL, 0, '0.000000', '0.000000', 0, '2023-11-22'),
(415, 20, 1, NULL, 0, NULL, 0, '0.000000', '0.000000', 0, '2023-11-23'),
(416, 20, 1, NULL, 0, NULL, 0, '0.000000', '0.000000', 0, '2023-11-24'),
(417, 20, 1, NULL, 0, NULL, 0, '0.000000', '0.000000', 0, '2023-11-25'),
(418, 20, 2, NULL, 0, NULL, 0, '0.000000', '0.000000', 0, '2023-11-19'),
(419, 20, 2, NULL, 0, NULL, 0, '0.000000', '0.000000', 0, '2023-11-20'),
(420, 20, 2, NULL, 0, NULL, 0, '0.000000', '0.000000', 0, '2023-11-21'),
(421, 20, 2, NULL, 0, NULL, 0, '0.000000', '0.000000', 0, '2023-11-22'),
(422, 20, 2, NULL, 0, NULL, 0, '0.000000', '0.000000', 0, '2023-11-23'),
(423, 20, 2, NULL, 0, NULL, 0, '0.000000', '0.000000', 0, '2023-11-24'),
(424, 20, 2, NULL, 0, NULL, 0, '0.000000', '0.000000', 0, '2023-11-25'),
(425, 20, 3, NULL, 0, NULL, 0, '0.000000', '0.000000', 0, '2023-11-19'),
(426, 20, 3, NULL, 0, NULL, 0, '0.000000', '0.000000', 0, '2023-11-20'),
(427, 20, 3, NULL, 0, NULL, 0, '0.000000', '0.000000', 0, '2023-11-21'),
(428, 20, 3, NULL, 0, NULL, 0, '0.000000', '0.000000', 0, '2023-11-22'),
(429, 20, 3, NULL, 0, NULL, 0, '0.000000', '0.000000', 0, '2023-11-23'),
(430, 20, 3, NULL, 0, NULL, 0, '0.000000', '0.000000', 0, '2023-11-24'),
(431, 20, 3, NULL, 0, NULL, 0, '0.000000', '0.000000', 0, '2023-11-25'),
(432, 20, 5, NULL, 0, NULL, 0, '0.000000', '0.000000', 0, '2023-11-19'),
(433, 20, 5, NULL, 0, NULL, 0, '0.000000', '0.000000', 0, '2023-11-20'),
(434, 20, 5, NULL, 0, NULL, 0, '0.000000', '0.000000', 0, '2023-11-21'),
(435, 20, 5, NULL, 0, NULL, 0, '0.000000', '0.000000', 0, '2023-11-22'),
(436, 20, 5, NULL, 0, NULL, 0, '0.000000', '0.000000', 0, '2023-11-23'),
(437, 20, 5, NULL, 0, NULL, 0, '0.000000', '0.000000', 0, '2023-11-24'),
(438, 20, 5, NULL, 0, NULL, 0, '0.000000', '0.000000', 0, '2023-11-25'),
(439, 20, 7, NULL, 0, NULL, 0, '0.000000', '0.000000', 0, '2023-11-19'),
(440, 20, 7, NULL, 0, NULL, 0, '0.000000', '0.000000', 0, '2023-11-20'),
(441, 20, 7, NULL, 0, NULL, 0, '0.000000', '0.000000', 0, '2023-11-21'),
(442, 20, 7, NULL, 0, NULL, 0, '0.000000', '0.000000', 0, '2023-11-22'),
(443, 20, 7, NULL, 0, NULL, 0, '0.000000', '0.000000', 0, '2023-11-23'),
(444, 20, 7, NULL, 0, NULL, 0, '0.000000', '0.000000', 0, '2023-11-24'),
(445, 20, 7, NULL, 0, NULL, 0, '0.000000', '0.000000', 0, '2023-11-25'),
(446, 20, 27, NULL, 0, NULL, 0, '0.000000', '0.000000', 0, '2023-11-19'),
(447, 20, 27, NULL, 0, NULL, 0, '0.000000', '0.000000', 0, '2023-11-20'),
(448, 20, 27, NULL, 0, NULL, 0, '0.000000', '0.000000', 0, '2023-11-21'),
(449, 20, 27, NULL, 0, NULL, 0, '0.000000', '0.000000', 0, '2023-11-22'),
(450, 20, 27, NULL, 0, NULL, 0, '0.000000', '0.000000', 0, '2023-11-23'),
(451, 20, 27, NULL, 0, NULL, 0, '0.000000', '0.000000', 0, '2023-11-24'),
(452, 20, 27, NULL, 0, NULL, 0, '0.000000', '0.000000', 0, '2023-11-25'),
(453, 20, 31, NULL, 0, NULL, 0, '0.000000', '0.000000', 0, '2023-11-19'),
(454, 20, 31, NULL, 0, NULL, 0, '0.000000', '0.000000', 0, '2023-11-20'),
(455, 20, 31, NULL, 0, NULL, 0, '0.000000', '0.000000', 0, '2023-11-21'),
(456, 20, 31, NULL, 0, NULL, 0, '0.000000', '0.000000', 0, '2023-11-22'),
(457, 20, 31, NULL, 0, NULL, 0, '0.000000', '0.000000', 0, '2023-11-23'),
(458, 20, 31, NULL, 0, NULL, 0, '0.000000', '0.000000', 0, '2023-11-24'),
(459, 20, 31, NULL, 0, NULL, 0, '0.000000', '0.000000', 0, '2023-11-25'),
(460, 20, 32, NULL, 0, NULL, 0, '0.000000', '0.000000', 0, '2023-11-19'),
(461, 20, 32, NULL, 0, NULL, 0, '0.000000', '0.000000', 0, '2023-11-20'),
(462, 20, 32, NULL, 0, NULL, 0, '0.000000', '0.000000', 0, '2023-11-21'),
(463, 20, 32, NULL, 0, NULL, 0, '0.000000', '0.000000', 0, '2023-11-22'),
(464, 20, 32, NULL, 0, NULL, 0, '0.000000', '0.000000', 0, '2023-11-23'),
(465, 20, 32, NULL, 0, NULL, 0, '0.000000', '0.000000', 0, '2023-11-24'),
(466, 20, 32, NULL, 0, NULL, 0, '0.000000', '0.000000', 0, '2023-11-25'),
(467, 20, 33, NULL, 0, NULL, 0, '0.000000', '0.000000', 0, '2023-11-19'),
(468, 20, 33, NULL, 0, NULL, 0, '0.000000', '0.000000', 0, '2023-11-20'),
(469, 20, 33, NULL, 0, NULL, 0, '0.000000', '0.000000', 0, '2023-11-21'),
(470, 20, 33, NULL, 0, NULL, 0, '0.000000', '0.000000', 0, '2023-11-22'),
(471, 20, 33, NULL, 0, NULL, 0, '0.000000', '0.000000', 0, '2023-11-23'),
(472, 20, 33, NULL, 0, NULL, 0, '0.000000', '0.000000', 0, '2023-11-24'),
(473, 20, 33, NULL, 0, NULL, 0, '0.000000', '0.000000', 0, '2023-11-25');

-- --------------------------------------------------------

--
-- Table structure for table `dtrtickets`
--

DROP TABLE IF EXISTS `dtrtickets`;
CREATE TABLE IF NOT EXISTS `dtrtickets` (
  `dtrTicketID` int NOT NULL AUTO_INCREMENT,
  `dtrID` int NOT NULL,
  `userID` int NOT NULL,
  `resolverName` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL,
  `dtrTicketDescription` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `dtrTicketRemarks` varchar(255) NOT NULL,
  `dtrTicketStatus` int NOT NULL DEFAULT '1',
  `dtrTicketDateRecieved` date NOT NULL,
  `dtrTicketDateResolved` date DEFAULT NULL,
  PRIMARY KEY (`dtrTicketID`),
  UNIQUE KEY `dtrTicketID_Unique` (`dtrTicketID`) USING BTREE,
  KEY `dtrTicketID_Index` (`dtrTicketID`) USING BTREE
) ENGINE=InnoDB AUTO_INCREMENT=8 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

--
-- Dumping data for table `dtrtickets`
--

INSERT INTO `dtrtickets` (`dtrTicketID`, `dtrID`, `userID`, `resolverName`, `dtrTicketDescription`, `dtrTicketRemarks`, `dtrTicketStatus`, `dtrTicketDateRecieved`, `dtrTicketDateResolved`) VALUES
(3, 253, 1, 'John Rey', 'I forgot to CLock in and Clock out on nov 1, 2023', 'Ticket Resolved', 2, '2023-11-07', '2023-11-08'),
(4, 301, 2, 'John Rey', 'I forgot to Clock Out on Nov 07, 2023', 'Resolved', 2, '2023-11-08', '2023-11-08'),
(5, 322, 7, 'John Rey', 'I forgot to clockout on nov 07, 2023', 'ok', 2, '2023-11-08', '2023-11-08'),
(6, 295, 1, 'John Rey', 'eyy', 'eyyaa', 2, '2023-11-09', '2023-11-09'),
(7, 294, 1, 'John Rey', 'wala ko ka log out', 'ok, resolved na', 2, '2023-11-10', '2023-11-10');

-- --------------------------------------------------------

--
-- Table structure for table `eventlog`
--

DROP TABLE IF EXISTS `eventlog`;
CREATE TABLE IF NOT EXISTS `eventlog` (
  `logID` int NOT NULL AUTO_INCREMENT,
  `userID` int NOT NULL DEFAULT '0',
  `serverID` int NOT NULL,
  `eventDate` date NOT NULL,
  `eventTime` time NOT NULL,
  `eventDescription` varchar(255) DEFAULT NULL,
  PRIMARY KEY (`logID`)
) ENGINE=InnoDB AUTO_INCREMENT=321 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

--
-- Dumping data for table `eventlog`
--

INSERT INTO `eventlog` (`logID`, `userID`, `serverID`, `eventDate`, `eventTime`, `eventDescription`) VALUES
(1, 0, 0, '2023-10-29', '00:00:00', 'TESTING eventlog 123'),
(2, 0, 0, '2023-10-29', '00:00:00', 'testNum2 asjdaifbka'),
(3, 0, 0, '2023-10-29', '00:00:00', 'Server Started'),
(4, 0, 0, '2023-10-29', '00:00:00', 'Server Terminated'),
(5, 0, 0, '2023-10-29', '00:00:00', 'Server Started'),
(6, 0, 0, '2023-10-29', '00:00:00', 'Server Terminated'),
(7, 0, 0, '2023-10-29', '00:00:00', 'Server Started'),
(8, 0, 0, '2023-10-29', '00:00:00', 'Server Terminated'),
(9, 0, 0, '2023-10-29', '00:00:00', 'Server Started'),
(10, 0, 0, '2023-10-29', '00:00:00', 'Server Terminated'),
(11, 0, 0, '2023-10-29', '00:00:00', 'Server Started'),
(12, 0, 0, '2023-10-29', '00:00:00', 'Server Terminated'),
(13, 0, 0, '2023-10-29', '00:00:00', 'Server Started'),
(14, 0, 0, '2023-10-29', '00:00:00', 'Server Terminated'),
(15, 0, 0, '2023-10-29', '00:00:00', 'Server Started'),
(16, 0, 0, '2023-10-29', '00:00:00', 'Server Terminated'),
(17, 0, 0, '2023-10-29', '00:00:00', 'Server Started'),
(18, 0, 0, '2023-10-29', '00:00:00', 'Server Terminated'),
(19, 0, 0, '2023-10-29', '00:00:00', 'Server Started'),
(20, 0, 0, '2023-10-29', '00:00:00', 'Server Terminated'),
(21, 0, 0, '2023-10-29', '00:00:00', 'Server Started'),
(22, 0, 0, '2023-10-29', '00:00:00', 'Server Terminated'),
(23, 0, 0, '2023-10-29', '00:00:00', 'Server Started'),
(24, 0, 0, '2023-10-29', '00:00:00', 'Server Terminated'),
(25, 0, 0, '2023-10-29', '00:00:00', 'Server Started'),
(26, 0, 0, '2023-10-29', '00:00:00', 'Server Terminated'),
(27, 0, 0, '2023-10-29', '00:00:00', 'Server Started'),
(28, 0, 0, '2023-10-29', '00:00:00', 'Server Terminated'),
(29, 0, 0, '2023-10-29', '00:00:00', 'Server Started'),
(30, 0, 0, '2023-10-29', '00:00:00', 'Server Terminated'),
(31, 0, 0, '2023-10-31', '00:00:00', 'Server Started'),
(32, 0, 0, '2023-10-31', '00:00:00', 'Server Terminated'),
(33, 0, 0, '2023-10-31', '00:00:00', 'Server Started'),
(34, 0, 0, '2023-10-31', '00:00:00', 'Server Terminated'),
(35, 0, 0, '2023-10-31', '00:00:00', 'Server Started'),
(36, 0, 0, '2023-10-31', '00:00:00', 'Server Terminated'),
(37, 0, 0, '2023-10-31', '00:00:00', 'Server Started'),
(38, 0, 0, '2023-10-31', '00:00:00', 'Server Terminated'),
(39, 0, 0, '2023-11-01', '00:00:00', 'Server Started'),
(40, 0, 0, '2023-11-01', '00:00:00', 'Server Terminated'),
(41, 0, 0, '2023-11-01', '00:00:00', 'Server Started'),
(42, 0, 0, '2023-11-01', '00:00:00', 'Server Terminated'),
(43, 0, 0, '2023-11-01', '00:00:00', 'Server Started'),
(44, 0, 0, '2023-11-01', '00:00:00', 'Server Terminated'),
(45, 0, 0, '2023-11-01', '00:00:00', 'Server Started'),
(46, 0, 0, '2023-11-01', '00:00:00', 'Server Terminated'),
(47, 0, 0, '2023-11-01', '00:00:00', 'Server Started'),
(48, 0, 0, '2023-11-01', '00:00:00', 'Server Terminated'),
(49, 0, 0, '2023-11-01', '00:00:00', 'Server Started'),
(50, 0, 0, '2023-11-01', '00:00:00', 'Server Terminated'),
(51, 0, 0, '2023-11-02', '00:00:00', 'Server Started'),
(52, 0, 0, '2023-11-02', '00:00:00', 'Server Terminated'),
(53, 0, 0, '2023-11-02', '00:00:00', 'Server Started'),
(54, 0, 0, '2023-11-02', '00:00:00', 'Server Terminated'),
(55, 0, 0, '2023-11-02', '00:00:00', 'Server Started'),
(56, 0, 0, '2023-11-02', '00:00:00', 'Server Terminated'),
(57, 0, 0, '2023-11-02', '00:00:00', 'Server Started'),
(58, 0, 0, '2023-11-02', '00:00:00', 'Server Terminated'),
(59, 0, 0, '2023-11-02', '00:00:00', 'Server Started'),
(60, 0, 0, '2023-11-02', '00:00:00', 'Server Terminated'),
(61, 0, 0, '2023-11-02', '00:00:00', 'Server Started'),
(62, 0, 0, '2023-11-02', '00:00:00', 'Server Terminated'),
(63, 0, 0, '2023-11-03', '00:00:00', 'Server Started'),
(64, 0, 0, '2023-11-03', '00:00:00', 'Server Terminated'),
(65, 0, 0, '2023-11-03', '00:00:00', 'Server Started'),
(66, 0, 0, '2023-11-03', '00:00:00', 'Server Terminated'),
(67, 0, 0, '2023-11-03', '00:00:00', 'Server Started'),
(68, 0, 0, '2023-11-03', '00:00:00', 'Server Terminated'),
(69, 0, 0, '2023-11-03', '00:00:00', 'Server Started'),
(70, 0, 0, '2023-11-03', '00:00:00', 'Server Terminated'),
(71, 0, 0, '2023-11-04', '00:00:00', 'Server Started'),
(72, 0, 0, '2023-11-04', '00:00:00', 'Server Terminated'),
(73, 0, 0, '2023-11-04', '00:00:00', 'Server Started'),
(74, 0, 0, '2023-11-04', '00:00:00', 'Server Terminated'),
(75, 0, 0, '2023-11-05', '00:00:00', 'Server Started'),
(76, 0, 0, '2023-11-05', '00:00:00', 'Server Terminated'),
(77, 0, 0, '2023-11-05', '00:00:00', 'Server Started'),
(78, 0, 0, '2023-11-05', '00:00:00', 'Server Terminated'),
(79, 0, 0, '2023-11-05', '00:00:00', 'Server Started'),
(80, 0, 0, '2023-11-05', '00:00:00', 'Server Terminated'),
(81, 0, 0, '2023-11-05', '00:00:00', 'Server Started'),
(82, 0, 0, '2023-11-05', '00:00:00', 'Server Terminated'),
(83, 0, 0, '2023-11-05', '00:00:00', 'Server Started'),
(84, 0, 0, '2023-11-05', '00:00:00', 'Server Terminated'),
(85, 0, 0, '2023-11-05', '00:00:00', 'Server Started'),
(86, 0, 0, '2023-11-05', '00:00:00', 'Server Terminated'),
(87, 0, 0, '2023-11-05', '00:00:00', 'Server Started'),
(88, 0, 0, '2023-11-05', '00:00:00', 'Server Terminated'),
(89, 0, 0, '2023-11-05', '00:00:00', 'Server Started'),
(90, 0, 0, '2023-11-05', '00:00:00', 'Server Terminated'),
(91, 0, 0, '2023-11-05', '00:00:00', 'Server Started'),
(92, 0, 0, '2023-11-06', '00:00:00', 'Server Terminated'),
(93, 0, 0, '2023-11-06', '00:00:00', 'Server Started'),
(94, 0, 0, '2023-11-06', '00:00:00', 'Server Terminated'),
(95, 0, 0, '2023-11-06', '00:00:00', 'Server Started'),
(96, 0, 0, '2023-11-06', '00:00:00', 'Server Terminated'),
(97, 0, 0, '2023-11-06', '00:00:00', 'Server Started'),
(98, 0, 0, '2023-11-06', '00:00:00', 'Server Terminated'),
(99, 0, 0, '2023-11-06', '00:00:00', 'Server Started'),
(100, 0, 0, '2023-11-06', '00:00:00', 'Server Terminated'),
(101, 0, 0, '2023-11-07', '00:00:00', 'Server Started'),
(102, 0, 0, '2023-11-07', '00:00:00', 'Server Terminated'),
(103, 0, 0, '2023-11-07', '00:00:00', 'Server Started'),
(104, 0, 0, '2023-11-07', '00:00:00', 'Server Terminated'),
(105, 0, 0, '2023-11-07', '00:00:00', 'Server Started'),
(106, 0, 0, '2023-11-07', '00:00:00', 'Server Terminated'),
(107, 0, 0, '2023-11-07', '00:00:00', 'Server Started'),
(108, 0, 0, '2023-11-08', '00:00:00', 'Server Terminated'),
(109, 0, 0, '2023-11-08', '00:00:00', 'Server Started'),
(110, 0, 0, '2023-11-08', '00:00:00', 'Server Terminated'),
(111, 0, 0, '2023-11-08', '00:00:00', 'Server Started'),
(112, 0, 0, '2023-11-08', '00:00:00', 'Server Terminated'),
(113, 0, 0, '2023-11-08', '00:00:00', 'Server Started'),
(114, 0, 0, '2023-11-08', '00:00:00', 'Server Terminated'),
(115, 0, 0, '2023-11-08', '00:00:00', 'Server Started'),
(116, 0, 0, '2023-11-08', '00:00:00', 'Server Terminated'),
(117, 0, 0, '2023-11-08', '00:00:00', 'Server Started'),
(118, 0, 0, '2023-11-08', '00:00:00', 'Server Terminated'),
(119, 0, 0, '2023-11-08', '00:00:00', 'Server Started'),
(120, 0, 0, '2023-11-08', '00:00:00', 'Server Terminated'),
(121, 0, 0, '2023-11-08', '00:00:00', 'Server Started'),
(122, 0, 0, '2023-11-08', '00:00:00', 'Server Terminated'),
(123, 0, 0, '2023-11-08', '00:00:00', 'Server Started'),
(124, 0, 0, '2023-11-08', '00:00:00', 'Server Terminated'),
(125, 0, 0, '2023-11-08', '00:00:00', 'Server Started'),
(126, 0, 0, '2023-11-08', '00:00:00', 'Server Terminated'),
(127, 0, 0, '2023-11-08', '00:00:00', 'Server Started'),
(128, 0, 0, '2023-11-08', '00:00:00', 'Server Terminated'),
(129, 0, 0, '2023-11-08', '00:00:00', 'Server Started'),
(130, 0, 0, '2023-11-08', '00:00:00', 'Server Terminated'),
(131, 0, 0, '2023-11-08', '00:00:00', 'Server Started'),
(132, 0, 0, '2023-11-08', '00:00:00', 'Server Terminated'),
(133, 0, 0, '2023-11-08', '00:00:00', 'Server Started'),
(134, 0, 0, '2023-11-08', '00:00:00', 'Server Terminated'),
(135, 0, 0, '2023-11-08', '00:00:00', 'Server Started'),
(136, 0, 0, '2023-11-08', '00:00:00', 'Server Terminated'),
(137, 0, 0, '2023-11-09', '00:00:00', 'Server Started'),
(138, 0, 0, '2023-11-09', '00:00:00', 'Server Terminated'),
(139, 0, 0, '2023-11-09', '00:00:00', ''),
(140, 0, 1, '2023-11-09', '00:00:00', 'Server Started'),
(141, 0, 1, '2023-11-09', '00:00:00', 'Server Terminated'),
(142, 0, 1, '2023-11-09', '00:00:00', 'Server Started'),
(143, 0, 1, '2023-11-09', '00:00:00', 'Server Terminated'),
(148, 0, 0, '2023-11-09', '17:27:44', ''),
(149, 0, 1, '2023-11-09', '17:31:46', 'Server Started'),
(150, 0, 1, '2023-11-09', '17:31:49', 'Server Terminated'),
(151, 0, 1, '2023-11-09', '17:35:30', 'Server Started'),
(152, 0, 1, '2023-11-09', '17:35:57', 'Server Terminated'),
(153, 0, 1, '2023-11-09', '17:58:32', 'Server Started'),
(154, 0, 1, '2023-11-09', '17:58:43', 'Server Started'),
(155, 0, 1, '2023-11-09', '18:01:31', 'Server Terminated'),
(156, 0, 1, '2023-11-09', '18:05:05', 'Server Started'),
(157, 0, 1, '2023-11-09', '18:05:20', 'Server Terminated'),
(158, 0, 1, '2023-11-09', '18:06:54', 'Server Started'),
(159, 0, 1, '2023-11-09', '18:08:50', 'Server Terminated'),
(160, 0, 1, '2023-11-09', '18:11:48', 'Server Started'),
(161, 0, 1, '2023-11-09', '18:11:51', 'Logging out all users'),
(162, 0, 1, '2023-11-09', '18:11:55', 'Server Terminated'),
(163, 0, 1, '2023-11-09', '18:34:57', 'Server Started'),
(164, 0, 1, '2023-11-09', '18:35:23', 'Logging out all users'),
(165, 1, 0, '2023-11-09', '18:36:03', 'johnrey.silverio has logged in'),
(166, 1, 0, '2023-11-09', '18:38:31', 'johnrey.silverio has logged in'),
(167, 1, 0, '2023-11-09', '18:38:38', 'JOHNREY.SILVERIO has logged in'),
(168, 1, 0, '2023-11-09', '18:40:16', 'JoHnReY.SiLvErIo has logged in'),
(169, 1, 0, '2023-11-09', '18:40:19', 'johnrey.silverio has logged out'),
(170, 1, 0, '2023-11-09', '18:46:09', 'johnrey.silverio has logged in'),
(171, 1, 0, '2023-11-09', '18:46:35', 'johnrey.silverio has clocked in'),
(172, 0, 1, '2023-11-09', '18:47:03', 'Logging out all users'),
(173, 1, 0, '2023-11-09', '18:47:36', 'johnrey.silverio has logged in'),
(174, 1, 0, '2023-11-09', '18:47:41', 'johnrey.silverio has logged out'),
(175, 1, 0, '2023-11-09', '18:54:00', 'johnrey.silverio has logged in'),
(176, 1, 0, '2023-11-09', '18:54:22', 'johnrey.silverio has submitted a ticket'),
(177, 1, 0, '2023-11-09', '18:54:39', 'johnrey.silverio has rejected a ticket'),
(178, 1, 0, '2023-11-09', '18:54:55', 'johnrey.silverio has resolved a ticket'),
(179, 1, 0, '2023-11-09', '18:55:10', 'johnrey.silverio has logged out'),
(180, 1, 0, '2023-11-09', '19:04:27', 'johnrey.silverio has logged in'),
(181, 1, 0, '2023-11-09', '19:04:39', 'johnrey.silverio has rejected ticket number 6'),
(182, 1, 0, '2023-11-09', '19:04:58', 'johnrey.silverio has resolved a ticket number 6'),
(183, 1, 0, '2023-11-09', '19:05:22', 'johnrey.silverio has logged out'),
(184, 1, 0, '2023-11-09', '19:14:04', 'johnrey.silverio has logged in'),
(185, 1, 0, '2023-11-09', '19:14:12', 'johnrey.silverio has logged out'),
(186, 1, 0, '2023-11-09', '19:16:24', 'johnrey.silverio has logged in'),
(187, 1, 0, '2023-11-09', '19:16:57', 'johnrey.silverio has edited kontra.dengue'),
(188, 1, 0, '2023-11-09', '19:17:15', 'johnrey.silverio has reset kontra.dengue'),
(189, 1, 0, '2023-11-09', '19:18:00', 'johnrey.silverio registered newaccount.newpassword'),
(190, 1, 0, '2023-11-09', '19:18:12', 'johnrey.silverio has deleted newaccount.newpassword'),
(191, 1, 0, '2023-11-09', '19:18:21', 'johnrey.silverio has logged out'),
(192, 0, 1, '2023-11-09', '19:20:47', 'Server Terminated'),
(193, 0, 1, '2023-11-09', '19:47:54', 'Server Started'),
(194, 0, 1, '2023-11-09', '19:48:05', 'Server Terminated'),
(195, 0, 1, '2023-11-09', '20:07:35', 'Server Started'),
(196, 1, 0, '2023-11-09', '20:07:51', 'johnrey.silverio has logged in'),
(197, 1, 0, '2023-11-09', '20:08:09', 'johnrey.silverio has logged out'),
(198, 1, 0, '2023-11-09', '20:21:13', 'johnrey.silverio has logged in'),
(199, 1, 0, '2023-11-09', '20:21:22', 'johnrey.silverio has logged out'),
(200, 1, 0, '2023-11-09', '20:24:12', 'johnrey.silverio has logged in'),
(201, 1, 0, '2023-11-09', '20:24:24', 'johnrey.silverio has logged out'),
(202, 2, 0, '2023-11-09', '20:31:40', 'laurence.silverio has logged in'),
(203, 2, 0, '2023-11-09', '20:31:43', 'laurence.silverio has clocked in'),
(204, 2, 0, '2023-11-09', '20:31:50', 'laurence.silverio has clocked out'),
(205, 2, 0, '2023-11-09', '20:31:54', 'laurence.silverio has logged out'),
(206, 7, 0, '2023-11-09', '20:35:17', 'johnmatheow.morillo has logged in'),
(207, 7, 0, '2023-11-09', '20:35:20', 'johnmatheow.morillo has clocked in'),
(208, 7, 0, '2023-11-09', '20:36:48', 'johnmatheow.morillo has clocked out'),
(209, 7, 0, '2023-11-09', '20:36:53', 'johnmatheow.morillo has logged out'),
(210, 1, 0, '2023-11-09', '20:37:11', 'johnrey.silverio has logged in'),
(211, 1, 0, '2023-11-09', '20:37:14', 'johnrey.silverio has logged out'),
(212, 1, 0, '2023-11-09', '20:38:53', 'johnrey.silverio has logged in'),
(213, 1, 0, '2023-11-09', '20:39:01', 'johnrey.silverio has logged out'),
(214, 1, 0, '2023-11-09', '20:45:16', 'johnrey.silverio has logged in'),
(215, 1, 0, '2023-11-09', '20:45:27', 'johnrey.silverio has logged out'),
(216, 7, 0, '2023-11-09', '20:46:11', 'johnmatheow.morillo has logged in'),
(217, 7, 0, '2023-11-09', '20:46:16', 'johnmatheow.morillo has logged out'),
(218, 1, 0, '2023-11-09', '20:57:49', 'johnrey.silverio has logged in'),
(219, 1, 0, '2023-11-09', '20:58:25', 'johnrey.silverio has logged out'),
(220, 1, 0, '2023-11-09', '20:59:17', 'johnrey.silverio has logged in'),
(221, 1, 0, '2023-11-09', '20:59:33', 'johnrey.silverio has logged out'),
(222, 1, 0, '2023-11-09', '20:59:43', 'johnrey.silverio has logged in'),
(223, 1, 0, '2023-11-09', '21:00:27', 'johnrey.silverio has logged out'),
(224, 1, 0, '2023-11-09', '21:04:18', 'johnrey.silverio has logged in'),
(225, 1, 0, '2023-11-09', '21:04:31', 'johnrey.silverio has changed password'),
(226, 1, 0, '2023-11-09', '21:04:48', 'johnrey.silverio has changed password'),
(227, 1, 0, '2023-11-09', '21:04:57', 'johnrey.silverio has logged out'),
(228, 0, 1, '2023-11-09', '21:08:47', 'Logging out all users'),
(229, 0, 1, '2023-11-09', '21:08:50', 'Server Terminated'),
(230, 0, 1, '2023-11-10', '10:58:55', 'Server Started'),
(231, 0, 1, '2023-11-10', '11:00:46', 'Server Terminated'),
(232, 0, 1, '2023-11-10', '11:05:13', 'Server Started'),
(233, 0, 1, '2023-11-10', '11:05:34', 'Logging out all users'),
(234, 0, 1, '2023-11-10', '11:06:15', 'Server Terminated'),
(235, 0, 1, '2023-11-10', '11:09:57', 'Server Started'),
(236, 0, 1, '2023-11-10', '11:10:07', 'Logging out all users'),
(237, 0, 1, '2023-11-10', '11:10:23', 'Server Terminated'),
(238, 0, 1, '2023-11-10', '11:17:22', 'Server Started'),
(239, 1, 0, '2023-11-10', '11:17:26', 'johnrey.silverio has logged in'),
(240, 1, 0, '2023-11-10', '11:17:29', 'johnrey.silverio has clocked in'),
(241, 1, 0, '2023-11-10', '11:18:04', 'johnrey.silverio has logged out'),
(242, 1, 0, '2023-11-10', '11:24:31', 'johnrey.silverio has logged in'),
(243, 1, 0, '2023-11-10', '11:24:49', 'johnrey.silverio has logged out'),
(244, 1, 0, '2023-11-10', '11:26:17', 'johnrey.silverio has logged in'),
(245, 1, 0, '2023-11-10', '11:26:59', 'johnrey.silverio registered donotadjust.theaircon'),
(246, 1, 0, '2023-11-10', '11:27:07', 'johnrey.silverio has logged out'),
(247, 1, 0, '2023-11-10', '11:45:40', 'johnrey.silverio has logged in'),
(248, 1, 0, '2023-11-10', '11:45:50', 'johnrey.silverio has updated donotadjust.theaircon account'),
(249, 1, 0, '2023-11-10', '11:45:56', 'johnrey.silverio has updated donotadjust.theaircon account'),
(250, 1, 0, '2023-11-10', '11:46:03', 'johnrey.silverio has logged out'),
(251, 1, 0, '2023-11-10', '11:53:08', 'johnrey.silverio has logged in'),
(252, 1, 0, '2023-11-10', '11:53:32', 'johnrey.silverio registered payroll.system'),
(253, 1, 0, '2023-11-10', '11:53:36', 'johnrey.silverio has logged out'),
(254, 1, 0, '2023-11-10', '12:00:09', 'johnrey.silverio has logged in'),
(255, 1, 0, '2023-11-10', '12:00:49', 'johnrey.silverio has logged out'),
(256, 0, 1, '2023-11-10', '12:03:43', 'Logging out all users'),
(257, 1, 0, '2023-11-10', '12:03:58', 'johnrey.silverio has logged in'),
(258, 0, 1, '2023-11-10', '12:04:14', 'Logging out all users'),
(259, 1, 0, '2023-11-10', '12:05:27', 'johnrey.silverio has logged in'),
(260, 1, 0, '2023-11-10', '12:06:18', 'johnrey.silverio has logged out'),
(261, 1, 0, '2023-11-10', '12:22:52', 'johnrey.silverio has logged in'),
(262, 1, 0, '2023-11-10', '13:11:39', 'johnrey.silverio registered strength.weakness'),
(263, 1, 0, '2023-11-10', '13:12:39', 'johnrey.silverio has submitted a ticket'),
(264, 1, 0, '2023-11-10', '13:13:09', 'johnrey.silverio has resolved a ticket number 7'),
(265, 1, 0, '2023-11-10', '13:13:41', 'johnrey.silverio has logged out'),
(266, 1, 0, '2023-11-10', '13:14:42', 'johnrey.silverio has logged in'),
(267, 1, 0, '2023-11-10', '13:16:53', 'johnrey.silverio has logged out'),
(268, 7, 0, '2023-11-10', '13:17:16', 'johnmatheow.morillo has logged in'),
(269, 7, 0, '2023-11-10', '13:17:18', 'johnmatheow.morillo has clocked in'),
(270, 7, 0, '2023-11-10', '13:18:07', 'johnmatheow.morillo has logged out'),
(271, 1, 0, '2023-11-10', '13:24:27', 'johnrey.silverio has logged in'),
(272, 1, 0, '2023-11-10', '13:24:38', 'johnrey.silverio has logged out'),
(273, 0, 1, '2023-11-10', '13:26:18', 'Server Terminated'),
(274, 0, 1, '2023-11-10', '13:28:26', 'Server Started'),
(275, 1, 0, '2023-11-10', '13:28:46', 'johnrey.silverio has logged in'),
(276, 1, 0, '2023-11-10', '13:28:57', 'johnrey.silverio has logged out'),
(277, 0, 1, '2023-11-10', '13:29:30', 'Server Terminated'),
(278, 0, 1, '2023-11-10', '23:43:45', 'Server Started'),
(279, 1, 0, '2023-11-10', '23:45:10', 'johnrey.silverio has logged in'),
(280, 0, 1, '2023-11-10', '23:47:37', 'Logging out all users'),
(281, 1, 0, '2023-11-10', '23:47:52', 'johnrey.silverio has logged in'),
(282, 0, 1, '2023-11-10', '23:48:56', 'Logging out all users'),
(283, 1, 0, '2023-11-10', '23:49:01', 'johnrey.silverio has logged in'),
(284, 0, 1, '2023-11-10', '23:50:58', 'Logging out all users'),
(285, 1, 0, '2023-11-10', '23:51:00', 'johnrey.silverio has logged in'),
(286, 0, 1, '2023-11-10', '23:51:10', 'Logging out all users'),
(287, 0, 1, '2023-11-10', '23:51:25', 'Logging out all users'),
(288, 1, 0, '2023-11-10', '23:51:31', 'johnrey.silverio has logged in'),
(289, 1, 0, '2023-11-10', '23:54:50', 'johnrey.silverio registered sia.101'),
(290, 1, 0, '2023-11-10', '23:55:36', 'johnrey.silverio has deleted sia.101'),
(291, 1, 0, '2023-11-10', '23:55:49', 'johnrey.silverio has logged out'),
(292, 0, 1, '2023-11-10', '23:55:54', 'Logging out all users'),
(293, 0, 1, '2023-11-10', '23:55:56', 'Server Terminated'),
(294, 0, 1, '2023-11-13', '21:00:45', 'Server Started'),
(295, 1, 0, '2023-11-13', '21:02:49', 'johnrey.silverio has logged in'),
(296, 1, 0, '2023-11-13', '21:03:14', 'johnrey.silverio has logged out'),
(297, 7, 0, '2023-11-13', '21:03:23', 'johnmatheow.morillo has logged in'),
(298, 7, 0, '2023-11-13', '21:04:02', 'johnmatheow.morillo has logged out'),
(299, 1, 0, '2023-11-13', '21:04:08', 'johnrey.silverio has logged in'),
(300, 1, 0, '2023-11-13', '21:04:18', 'johnrey.silverio has logged out'),
(301, 7, 0, '2023-11-13', '21:04:24', 'johnmatheow.morillo has logged in'),
(302, 7, 0, '2023-11-13', '21:09:36', 'johnmatheow.morillo has logged out'),
(303, 1, 0, '2023-11-13', '21:09:43', 'johnrey.silverio has logged in'),
(304, 1, 0, '2023-11-13', '21:13:03', 'johnrey.silverio has logged out'),
(305, 0, 1, '2023-11-21', '22:09:16', 'Server Started'),
(306, 0, 1, '2023-11-21', '22:09:25', 'Logging out all users'),
(307, 0, 1, '2023-11-21', '22:09:43', 'Server Terminated'),
(308, 0, 1, '2023-11-21', '22:12:20', 'Server Started'),
(309, 0, 1, '2023-11-21', '22:12:29', 'Logging out all users'),
(310, 0, 1, '2023-11-21', '22:12:40', 'Server Terminated'),
(311, 0, 1, '2023-11-21', '22:51:00', 'Server Started'),
(312, 0, 1, '2023-11-21', '22:51:15', 'Logging out all users'),
(313, 0, 1, '2023-11-21', '22:51:40', 'Server Terminated'),
(314, 0, 1, '2023-11-21', '22:55:10', 'Server Started'),
(315, 0, 1, '2023-11-21', '22:56:34', 'Logging out all users'),
(316, 1, 1, '2023-11-21', '22:57:30', 'johnrey.silverio has logged in'),
(317, 1, 1, '2023-11-21', '22:58:00', 'johnrey.silverio has logged out'),
(318, 0, 1, '2023-11-21', '22:58:11', 'Server Terminated'),
(319, 0, 1, '2023-11-21', '23:05:08', 'Server Started'),
(320, 0, 1, '2023-11-21', '23:05:30', 'Server Terminated');

--
-- Triggers `eventlog`
--
DROP TRIGGER IF EXISTS `DeleteOldEventLogs`;
DELIMITER $$
CREATE TRIGGER `DeleteOldEventLogs` AFTER INSERT ON `eventlog` FOR EACH ROW BEGIN
    IF EXISTS (SELECT 1 FROM eventlog WHERE eventDate < DATE_SUB(NOW(), INTERVAL 6 MONTH)) THEN
        
        SET @DeleteThresholdDate = DATE_SUB(NOW(), INTERVAL 6 MONTH);
        
        DELETE FROM eventlog
        WHERE eventDate < @DeleteThresholdDate;
    END IF;
END
$$
DELIMITER ;

-- --------------------------------------------------------

--
-- Table structure for table `payslip`
--

DROP TABLE IF EXISTS `payslip`;
CREATE TABLE IF NOT EXISTS `payslip` (
  `payslipID` int NOT NULL AUTO_INCREMENT,
  `startDate` date NOT NULL,
  `endDate` date NOT NULL,
  PRIMARY KEY (`payslipID`)
) ENGINE=InnoDB AUTO_INCREMENT=21 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

--
-- Dumping data for table `payslip`
--

INSERT INTO `payslip` (`payslipID`, `startDate`, `endDate`) VALUES
(7, '2023-10-29', '2023-11-04'),
(9, '2023-11-05', '2023-11-11'),
(19, '2023-11-12', '2023-11-18'),
(20, '2023-11-19', '2023-11-25');

-- --------------------------------------------------------

--
-- Table structure for table `payslipdetail`
--

DROP TABLE IF EXISTS `payslipdetail`;
CREATE TABLE IF NOT EXISTS `payslipdetail` (
  `payslipDetailID` int NOT NULL AUTO_INCREMENT,
  `payslipID` int NOT NULL,
  `userID` int NOT NULL,
  `totalHours` decimal(10,6) DEFAULT NULL,
  `subtotal` decimal(10,2) NOT NULL,
  `allowance` decimal(10,2) NOT NULL,
  `SSSDeduction` decimal(10,2) NOT NULL DEFAULT '0.00',
  `deduction` decimal(10,2) NOT NULL,
  `totalSalary` double(10,2) NOT NULL,
  PRIMARY KEY (`payslipDetailID`),
  UNIQUE KEY `payslipID_Unique` (`payslipDetailID`) USING BTREE,
  UNIQUE KEY `unique_user_payslip` (`userID`,`payslipID`),
  KEY `payslipID_Index` (`payslipDetailID`) USING BTREE
) ENGINE=InnoDB AUTO_INCREMENT=3631 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

--
-- Dumping data for table `payslipdetail`
--

INSERT INTO `payslipdetail` (`payslipDetailID`, `payslipID`, `userID`, `totalHours`, `subtotal`, `allowance`, `SSSDeduction`, `deduction`, `totalSalary`) VALUES
(601, 7, 1, '42.046112', '437.98', '0.00', '43.80', '393.80', 44.18),
(602, 7, 2, '15.677223', '163.30', '0.00', '16.33', '366.33', -203.03),
(603, 7, 3, '15.616944', '0.00', '0.00', '0.00', '350.00', -350.00),
(604, 7, 5, '0.000000', '0.00', '500.00', '0.00', '350.00', 150.00),
(605, 7, 7, '15.496389', '161.42', '0.00', '16.14', '366.14', -204.72),
(751, 9, 1, '31.178611', '324.78', '0.00', '32.48', '382.48', -57.70),
(752, 9, 2, '27.880277', '290.42', '0.00', '29.04', '379.04', -88.62),
(753, 9, 3, '22.601944', '0.00', '0.00', '0.00', '350.00', -350.00),
(754, 9, 5, '0.000000', '0.00', '500.00', '0.00', '350.00', 150.00),
(755, 9, 7, '27.897777', '290.60', '0.00', '29.06', '379.06', -88.46),
(955, 9, 27, '13.020833', '0.00', '0.00', '0.00', '350.00', -350.00),
(2380, 20, 1, '0.000000', '0.00', '0.00', '0.00', '0.00', 0.00),
(2381, 20, 2, '0.000000', '0.00', '0.00', '0.00', '0.00', 0.00),
(2382, 20, 3, '0.000000', '0.00', '0.00', '0.00', '0.00', 0.00),
(2383, 20, 5, '0.000000', '0.00', '0.00', '0.00', '0.00', 0.00),
(2384, 20, 7, '0.000000', '0.00', '0.00', '0.00', '0.00', 0.00),
(2385, 20, 27, '0.000000', '0.00', '0.00', '0.00', '0.00', 0.00),
(2386, 20, 31, '0.000000', '0.00', '0.00', '0.00', '0.00', 0.00),
(2387, 20, 32, '0.000000', '0.00', '0.00', '0.00', '0.00', 0.00),
(2388, 20, 33, '0.000000', '0.00', '0.00', '0.00', '0.00', 0.00);

--
-- Triggers `payslipdetail`
--
DROP TRIGGER IF EXISTS `after_insert_payslipdetail`;
DELIMITER $$
CREATE TRIGGER `after_insert_payslipdetail` AFTER INSERT ON `payslipdetail` FOR EACH ROW BEGIN
  DECLARE i INT;
  SET i = 0;
  SET @startDate = (SELECT startDate FROM payslip WHERE payslipID = NEW.payslipID);

  WHILE i < 7 DO
    INSERT INTO dtr (payslipID, userID, clockintime, clockedIn, clockouttime, clockedOut, subtotalHour, totalHours,holiday, dtrDate)
    VALUES (NEW.payslipID, NEW.userID, NULL, 0, NULL, 0,0, 0,0, DATE_ADD(@startDate, INTERVAL i DAY));
    SET i = i + 1;
  END WHILE;
END
$$
DELIMITER ;

-- --------------------------------------------------------

--
-- Table structure for table `serverstatus`
--

DROP TABLE IF EXISTS `serverstatus`;
CREATE TABLE IF NOT EXISTS `serverstatus` (
  `serverID` int NOT NULL AUTO_INCREMENT,
  `serverName` varchar(50) NOT NULL DEFAULT 'PS Server',
  `serverPassword` varchar(50) NOT NULL,
  `status` int NOT NULL,
  `lastChecked` datetime NOT NULL,
  PRIMARY KEY (`serverID`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

--
-- Dumping data for table `serverstatus`
--

INSERT INTO `serverstatus` (`serverID`, `serverName`, `serverPassword`, `status`, `lastChecked`) VALUES
(1, 'PS Server', '12345', 0, '2023-11-21 23:05:30');

-- --------------------------------------------------------

--
-- Table structure for table `staff`
--

DROP TABLE IF EXISTS `staff`;
CREATE TABLE IF NOT EXISTS `staff` (
  `staffID` int NOT NULL AUTO_INCREMENT,
  `firstName` varchar(50) NOT NULL,
  `lastName` varchar(50) NOT NULL,
  `sex` varchar(50) DEFAULT NULL,
  `DOB` datetime NOT NULL,
  `position` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT 'Employee',
  `salary` decimal(10,2) DEFAULT '500.00',
  `allowance` decimal(10,2) DEFAULT NULL,
  `SSS` varchar(50) DEFAULT NULL,
  `PagIbig` varchar(50) DEFAULT NULL,
  `PhilHealth` varchar(50) DEFAULT NULL,
  `stationNo` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL,
  PRIMARY KEY (`staffID`),
  UNIQUE KEY `employeeID_Unique` (`staffID`) USING BTREE,
  UNIQUE KEY `SSS` (`SSS`),
  UNIQUE KEY `PagIbig` (`PagIbig`),
  UNIQUE KEY `PhilHealth` (`PhilHealth`),
  KEY `employeeID_Index` (`staffID`) USING BTREE,
  KEY `firstName_Index` (`firstName`) USING BTREE
) ENGINE=InnoDB AUTO_INCREMENT=35 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

--
-- Dumping data for table `staff`
--

INSERT INTO `staff` (`staffID`, `firstName`, `lastName`, `sex`, `DOB`, `position`, `salary`, `allowance`, `SSS`, `PagIbig`, `PhilHealth`, `stationNo`) VALUES
(1, 'John Rey', 'Silverio', 'Male', '2001-04-17 00:00:00', 'Employee', '500.00', '0.00', '124151235412', '1251234125123', '15125123512', 'S002'),
(2, 'laurence', 'silverio', 'Male', '2023-08-22 00:00:00', 'Employee', '500.00', '0.00', NULL, NULL, NULL, 'S002'),
(3, 'username', 'password', 'Female', '2023-10-26 16:23:27', 'Employee', '0.00', '0.00', NULL, NULL, NULL, ''),
(5, 'Edit', 'Test', 'Male', '2023-09-28 00:00:00', 'New Manager', '1500.00', '500.00', NULL, NULL, NULL, ''),
(7, 'john matheo', 'morillo', 'Male', '2023-09-28 00:00:00', 'Employee', '500.00', '0.00', NULL, NULL, NULL, 'S002'),
(27, 'Kontra', 'Dengue', 'Male', '2023-04-04 14:03:45', 'Dengue', '0.00', '0.00', '1234212', '3124123', '3141241', 'S003'),
(31, 'donotadjust', 'theaircon', 'Female', '2023-11-10 11:26:21', 'signage', '1000000.00', '1000000.00', '', '', '', 'lab2'),
(32, 'payroll', 'system', 'Female', '2023-11-10 11:53:13', 'pss', '1.00', '1.00', NULL, NULL, NULL, 'pss'),
(33, 'strength', 'weakness', 'Female', '2001-06-05 13:10:25', 'PE', '1000.00', '1000.00', NULL, NULL, NULL, 's012');

-- --------------------------------------------------------

--
-- Table structure for table `staffinsurance`
--

DROP TABLE IF EXISTS `staffinsurance`;
CREATE TABLE IF NOT EXISTS `staffinsurance` (
  `userID` int NOT NULL AUTO_INCREMENT,
  `SSS` decimal(10,2) NOT NULL,
  `PagIbig` decimal(10,2) NOT NULL,
  `PhilHealth` decimal(10,2) NOT NULL,
  UNIQUE KEY `userID` (`userID`)
) ENGINE=InnoDB AUTO_INCREMENT=35 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

--
-- Dumping data for table `staffinsurance`
--

INSERT INTO `staffinsurance` (`userID`, `SSS`, `PagIbig`, `PhilHealth`) VALUES
(1, '10.00', '250.00', '100.00'),
(2, '10.00', '250.00', '100.00'),
(3, '10.00', '250.00', '100.00'),
(5, '10.00', '250.00', '100.00'),
(7, '10.00', '250.00', '100.00'),
(27, '10.00', '250.00', '100.00'),
(31, '10.00', '250.00', '100.00'),
(32, '10.00', '250.00', '100.00'),
(33, '10.00', '250.00', '100.00');

--
-- Constraints for dumped tables
--

--
-- Constraints for table `account`
--
ALTER TABLE `account`
  ADD CONSTRAINT `account_ibfk_1` FOREIGN KEY (`staffID`) REFERENCES `staff` (`staffID`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
