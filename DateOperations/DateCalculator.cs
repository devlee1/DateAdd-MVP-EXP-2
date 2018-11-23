using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DateOperations
{
    public class DateCalculator
    {
        private int[] monthLengths = new int[] { 31, 28, 31, 30, 31, 30,31, 31, 30, 31, 30, 31 };

        int year;
        int month;
        int day;

        public DateCalculator(int year, int month, int day)
        {
            if ( ( day < 1 || GetMonthLength(year, month) < day) || year < Constants.yearMin || year > Constants.yearMax)
            {
                throw new ArgumentException(Constants.invalidDateErrorMessage);
            }

            this.year = year;
            this.month = month;
            this.day = day;
        }

        public string AddDays(int daysToAdd)
        {
            day += daysToAdd;

            if (daysToAdd == 0)
            {
                //null
            }
            else if (daysToAdd > 0)
            {
                AllocateMonthsYearsPositive();
            }
            else if (daysToAdd < 0)
            {
                AllocateMonthsYearsNegative();
            }

            return day.ToString("00") + Constants.seperator + month.ToString("00") + Constants.seperator + year.ToString("0000");
        }

        /*
           Assesses the value of 'day', and if too large for the month, then successsively
           increments the month and year until value of day is appropriate for the month
        */
        private void AllocateMonthsYearsPositive()
        {
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
        }

        /*
           Assesses the value of 'day', and if too low for the month, then successsively
           decrements the month and year until value of day is appropriate for the month
        */
        private void AllocateMonthsYearsNegative()
        {
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
