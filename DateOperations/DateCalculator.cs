using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DateOperations
{
    public class DateCalculator : IDateCalculator
    {
        private int[] monthLengths = new int[] { 31, 28, 31, 30, 31, 30,31, 31, 30, 31, 30, 31 };
        private IDateFormatter dateFormatter;

        public DateCalculator(IDateFormatter dateFormatter)
        {
            this.dateFormatter = dateFormatter;
        }

        public string AddDays(string date, int daysToAdd)
        {
            dateFormatter.GetDateElements(date, out int year, out int month, out int day);
            return AddDays(year, month, day, daysToAdd);
        }

        public string AddDays(int year, int month, int day, int daysToAdd)
        {
            if ( ( day < 1 || GetMonthLength(year, month) < day) || year < Constants.yearMin || year > Constants.yearMax)
                throw new ArgumentException(Constants.invalidDateErrorMessage);

            if (daysToAdd > 0)
            {
                return CalculateDayMonthsYearsPositive(year, month, day, daysToAdd);
            }
            else if (daysToAdd < 0)
            {
                return CalculateDayMonthsYearsNegitive(year, month, day, daysToAdd);
            }
            else return dateFormatter.FormatDate(year, month, day);
        }

        /*
           Assesses the value of 'day', and if too large for the month, then successsively
           increments the month and year until value of day is appropriate for the month
        */
        private string CalculateDayMonthsYearsPositive(int year, int month, int day, int daysToAdd)
        {
            day += daysToAdd;
            var currentMonthDays = GetMonthLength(year, month);

            while (day > currentMonthDays)
            {
                day -= currentMonthDays;
                month++;
                if (month > 12)
                {
                    month = 1;
                    year++;

                    if (year>Constants.yearMax)
                    {
                        throw new ArgumentException(Constants.yearMaxExceededErrorMessage);
                    }
                }

                currentMonthDays = GetMonthLength(year, month);
            }

            return dateFormatter.FormatDate(year, month, day);
        }

        /*
           Assesses the value of 'day', and if too low for the month, then successsively
           decrements the month and year until value of day is appropriate for the month
        */
        private string CalculateDayMonthsYearsNegitive(int year, int month, int day, int daysToAdd)
        {
            day += daysToAdd;
            var previousMonthDays = GetPreviousMonthLength(year, month);

            while (day < 1)
            {
                day += previousMonthDays;
                month--;

                if (month < 1)
                {
                    month = 12;
                    year--;

                    if (year < Constants.yearMin)
                    {
                        throw new ArgumentException(Constants.yearMinExceededErrorMessage);
                    }
                }
                previousMonthDays = GetPreviousMonthLength(year, month);
            }
            return dateFormatter.FormatDate(year, month, day);
        }

        private int GetPreviousMonthLength(int year, int month)
        {
            return GetMonthLength((month == 1) ? year - 1 : year, (month == 1) ? 12 : month - 1);
        }

        private int GetMonthLength(int year, int month)
        {
            bool leapYear = false;
            var monthLength = monthLengths[month - 1];
            if (month==2)
            {
                if (year%4 == 0)
                {
                    leapYear = true;
                    if (year%100 == 0)
                    {
                        leapYear = false;
                        if (year % 400 == 0)
                        {
                            leapYear = true;
                        }
                    }
                }

                if (leapYear == true)
                    monthLength++;
            }
            return monthLength;
        }
    }
}
