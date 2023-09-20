using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicApp
{
    static public class DateHelper
    {
        public static bool IsValidBirthDate(this DateTime? birthDate)
        {
            DateTime nonNullDate = (DateTime)birthDate;
            if (nonNullDate.Year < 1890) return false;
            if (nonNullDate > DateTime.Now) return false;
            return true;
        }
    }
}
