using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DateOperations
{
    public class Constants
    {
        public const char seperator = '/';
        public const string invalidDateErrorMessage = "Year, Month, Day represent invalid date";
        public const string invalidDateFormatErrorMessage = "Invalid Date Format";
        public const string invalidNumberOfDaysErrorMessage = "Invalid Number Of Days";
        public const int yearMax = 2999;
        public const int yearMin = 0000;
        public const string yearMaxExceededErrorMessage = "Calculated Date Greater than allowed";
        public const string yearMinExceededErrorMessage = "Calculated Date Less than allowed";
    }
}
