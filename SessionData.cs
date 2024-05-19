using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RGO_LIPA_FINALPROJECT
{
    public class SessionData
    {
        // Define a static variable to hold the current student's SRCODE
        public static int CurrentStudentSRCODE { get; set; }

        // Define a static variable to hold the current RGO staff's StaffID
        public static int StaffID { get; set; }

        // Define a static variable to hold the current admin's StaffID
        public static int CurrentAdminID { get; set; }

    }
}
