using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PS.Server
{
    internal class UserDetails
    {
        static DataTable? userDetail;
        static int? selectedStaffID;
        public static DataTable? UserDetail
        {
            get => userDetail;
            set => userDetail = value;
        }
        public static int? SelectedStaffID
        {
            get => selectedStaffID;
            set => selectedStaffID = value;
        }
    }
}
