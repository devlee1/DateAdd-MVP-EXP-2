using DateOperations;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DateAdd.Tests
{
    [TestFixture]
    public class DateFormatterTests
    {
        [TestCase("01-01-2018", 1)]
        [TestCase("01/01/2018x", 1)]
        public void AddDaysTest_Exception_InvalidDate(string date, int daysToAdd)
        {
            var dateFormatter = new DateFormatter();

            var ex = Assert.Throws<ArgumentException>(() => dateFormatter.GetDateElements(date, out int year, out int month, out int days));
            Assert.That(ex.Message, Is.EqualTo(Constants.invalidDateFormatErrorMessage));
        }
    }
}
