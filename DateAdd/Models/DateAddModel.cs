using DateOperations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DateAdd.Models
{
    public class DateAddModel : IDateAddModel
    {
        IDateCalculator dateCalculator;

        public DateAddModel(IDateCalculator dateCalculator)
        {
            this.dateCalculator = dateCalculator;
        }

        public string AddDays(string dateText, string daysToAddText)
        {
            if (int.TryParse(daysToAddText, out int daysToAdd))
                return dateCalculator.AddDays(dateText, daysToAdd);
            else
                throw new ArgumentException(Constants.invalidNumberOfDaysErrorMessage);
        }
    }
}
