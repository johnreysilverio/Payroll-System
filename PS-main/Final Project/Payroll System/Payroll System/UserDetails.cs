using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Payroll_System
{
    static class UserDetails
    {
        static DataTable? userDetail;
        static int? selectedStaffID;
        static int? selectedPayslipID;
        static int? selectedDTRID;
        static int? selectedDTRTicketID;
        static int? selectedPayslipDetailId;
        public static DataTable? UserDetail { 
            get => userDetail; 
            set => userDetail = value; 
        }
        public static int? SelectedStaffID {
            get => selectedStaffID; 
            set => selectedStaffID = value; 
        }
        public static int? SelectedPayslipID
        {
            get => selectedPayslipID;
            set => selectedPayslipID = value;
        }
        public static int? SelectedDTRID
        {
            get => selectedDTRID;
            set => selectedDTRID = value;
        }
        public static int? SelectedDTRTicketID
        {
            get => selectedDTRTicketID;
            set => selectedDTRTicketID = value;
        }
        public static int? SelectedPayslipDetailID
        {
            get => selectedPayslipDetailId;
            set => selectedPayslipDetailId = value;
        }
    }
}
