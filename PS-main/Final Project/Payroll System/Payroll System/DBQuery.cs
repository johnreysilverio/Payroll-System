using Org.BouncyCastle.Asn1.Mozilla;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Payroll_System
{
    internal class DBQuery
    {
        private string loginQuery = @"CALL `getLogin`(@p0, @p1)";
        private string userDetailsQuery = @"CALL `getAccDetails`(@p0)";
        private string updateAccountPassword = @"CALL `updateAccountPassword`(@p0, @p1)";
        private string registerAccount = @"CALL `registerAccount`(@p0, @p1, @p2, @p3, @p4, @p5, @p6, @p7, @p8, @p9, @p10, @p11)";
        private string getUserAcc = @"CALL `getUserAcc`(@p0)";
        private string editUserAcc = @"CALL `editUserAcc`(@p0, @p1, @p2, @p3, @p4, @p5, @p6, @p7, @p8, @p9, @p10, @p11, @p12, @p13)";
        private string loginStatus = @"CALL `loginStatus`(@p0, @p1)";
        private string checkIsEnabled = @"CALL `checkIsEnabled`(@p0)";
        private string checkServerStatus = @"CALL `CheckServerStatus`()";
        private string getUserDTR = @"CALL `getUserDTR`(@p0)";
        private string updateLoginStatus = @"CALL `UpdateLoginStatus`(@p0)";
        private string deleteUser = @"CALL `DeleteUser`(@p0)";
        private string clockInOut = @"CALL `ClockInOut`(@p0, @p1, @p2, @p3, @p4)";
        private string getPayslip = @"CALL `GetPayslip`(@p0)";
        private string getPayslipDTR = @"CALL `GetPayslipDTR`(@p0, @p1)";
        private string getPayslipInfo = @"CALL `GetPayslipInfo`(@p0)";
        private string getDates = @"CALL `GetDates`()";
        private string updateDTRHoliday = @"CALL `UpdateDTRHoliday`(@p0, @p1)";
        private string getAllUserID = @"CALL `getAllUserID`()";
        private string fillPayrollDetail = @"CALL `FillPayslipDetail`(@p0, @p1)";
        private string generateDTRTicket = @"CALL `GenerateDTRTicket`(@p0, @p1, @p2)";
        private string getSpecificDTR = @"CALL `GetSpecificDTR`(@p0)";
        private string showDTRTickets = @"CALL `ShowDTRTickets`(@p0, @p1)";
        private string getDTRFromDTRTickets = @"CALL `GetDTRFromDTRTickets`(@p0)";
        private string resetDTRClockIn = @"CALL `ResetDTRClockIn`(@p0)";
        private string resetDTRClockOut = @"CALL `ResetDTRClockOut`(@p0)";
        private string updateDTRTickets = @"CALL `UpdateDTRTickets`(@p0, @p1, @p2, @p3)";
        private string checkLoginStatus = @"CALL `CheckUserLoginStatus`(@p0)";
        private string eventLog = @"CALL `EventLog`(@p0, @p1, @p2)";
        private string showPayslipRange = @"CALL `ShowPayslipDateRange`()";
        private string showPayslips = @"CALL `ShowPayslips`(@p0)";
        private string getStaffInsurance = @"CALL `GetStaffInsurance`()";
        private string updateStaffInsurance = @"CALL `UpdateInsurance`(@p0, @p1, @p2)";
        public string LoginQuery()
        {
            return loginQuery;
        }
        public string LoginStatus()
        {
            return loginStatus;
        }
        public string CheckIsEnabled()
        {
            return checkIsEnabled;
        }
        public string UserDetailsQuery()
        {
            return userDetailsQuery;
        }
        public string UpdateAccountPassword()
        {
            return updateAccountPassword;
        }
        public string RegisterAccount()
        {
            return registerAccount;
        }
        public string GetUserAcc()
        {
            return getUserAcc;
        }
        public string EditUserAcc()
        {
            return editUserAcc;
        }
        public string CheckServerStatus()
        {
            return checkServerStatus;
        }
        public string GetUserDTR()
        {
            return getUserDTR;
        }
        public string UpdateLoginStatus()
        {
            return updateLoginStatus;
        }
        public string DeleteUser()
        {
            return deleteUser;
        }
        public string ClockInOut()
        {
            return clockInOut;
        }
        public string GetPayslip()
        {
            return getPayslip;
        }
        public string GetPayslipDTR()
        {
            return getPayslipDTR;
        }
        public string GetPayslipInfo()
        {
            return getPayslipInfo;
        }
        public string GetDates()
        {
            return getDates;
        }
        public string UpdateDTRHoliday()
        {
            return updateDTRHoliday;
        }
        public string GetAllUserID()
        {
            return getAllUserID;
        }
        public string FillPayrollDetail()
        {
            return fillPayrollDetail;
        }
        public string GenerateDTRTicket()
        {
            return generateDTRTicket;
        }
        public string GetSpecificDTR()
        {
            return getSpecificDTR;
        }
        public string ShowDTRTickets()
        {
            return showDTRTickets;
        }
        public string GetDTRFromDTRTickets()
        {
            return getDTRFromDTRTickets;
        }
        public string ResetDTRClockIn()
        {
            return resetDTRClockIn;
        }
        public string ResetDTRClockOut()
        {
            return resetDTRClockOut;
        }
        public string UpdateDTRTickets()
        {
            return updateDTRTickets;
        }
        public string CheckLoginStatus()
        {
            return checkLoginStatus;
        }
        public string EventLog()
        {
            return eventLog;
        }
        public string ShowPayslipRange()
        {
            return showPayslipRange;
        }
        public string ShowPayslips()
        {
            return showPayslips;
        }
        public string GetStaffInsurance()
        {
            return getStaffInsurance;
        }
        public string UpdateStaffInsurance()
        {
            return updateStaffInsurance;
        }
    }
}
