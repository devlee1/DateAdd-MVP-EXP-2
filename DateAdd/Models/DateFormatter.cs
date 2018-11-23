using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DateAdd.Models
{
    public class DateFormatter
    {
        public void GetDateElements(string date, out int year, out int month, out int day)
        {
            try
            {
                var words = date.Split(Constants.seperator);
                day = int.Parse(words[0]);
                month = int.Parse(words[1]);
                year = int.Parse(words[2]);
            }
            catch(Exception ex)
            {
                throw new ArgumentException(Constants.invalidDateFormatErrorMessage);
            }
        }
    }
}
