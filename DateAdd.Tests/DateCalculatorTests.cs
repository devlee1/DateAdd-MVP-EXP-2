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
    public class DateCalculatorTests
    {
        [TestCase("20/01/2016", 0, ExpectedResult = "20/01/2016")]
        [TestCase("20/01/2016", 14, ExpectedResult = "03/02/2016")]
        [TestCase("20/01/2016", 50, ExpectedResult = "10/03/2016")]
        [TestCase("31/12/2016", 1, ExpectedResult = "01/01/2017")]
        [TestCase("01/01/2016", 1, ExpectedResult = "02/01/2016")]
        [TestCase("31/01/2016", 1, ExpectedResult ="01/02/2016")]
        [TestCase("31/01/2016", -1, ExpectedResult = "30/01/2016")]
        [TestCase("28/02/2016", 1, ExpectedResult = "29/02/2016")]
        [TestCase("28/02/2016", 2, ExpectedResult = "01/03/2016")]
        [TestCase("01/03/2016", -1, ExpectedResult = "29/02/2016")]
        [TestCase("01/03/2016", -2, ExpectedResult = "28/02/2016")]
        [TestCase("29/02/2016", 1, ExpectedResult = "01/03/2016")]
        [TestCase("29/02/2016", -1, ExpectedResult = "28/02/2016")]
        [TestCase("19/11/2018", 365, ExpectedResult = "19/11/2019")]
        [TestCase("19/11/2018", 730, ExpectedResult = "18/11/2020")]
        [TestCase("19/11/2018", 36500, ExpectedResult = "26/10/2118")]
        [TestCase("19/11/2018", -36500, ExpectedResult = "14/12/1918")]
        [TestCase("01/01/0000", 0, ExpectedResult = "01/01/0000")]
        [TestCase("31/12/2999", 0, ExpectedResult = "31/12/2999")]
        public string AddDaysTest(string date, int daysToAdd)
        {
            var dateFormatter = new DateFormatter();
            dateFormatter.GetDateElements(date, out int year, out int month, out int days);

            var dateCalculator = new DateCalculator(year, month, days);

            return dateCalculator.AddDays(daysToAdd);
        }

        [TestCase("32/01/2018",1)]
        public void AddDaysTest_Exception_InvalidDate(string date, int daysToAdd)
        {
            var dateFormatter = new DateFormatter();
            dateFormatter.GetDateElements(date, out int year, out int month, out int days);

            var ex = Assert.Throws<ArgumentException>(() => new DateCalculator(year, month, days));
            Assert.That(ex.Message, Is.EqualTo(Constants.invalidDateErrorMessage));
        }

        [TestCase("31/01/2018", 1000000)]
        public void AddDaysTest_Exception_MaxDate(string date, int daysToAdd)
        {
            var dateFormatter = new DateFormatter();
            dateFormatter.GetDateElements(date, out int year, out int month, out int days);

            var dateCalculator = new DateCalculator(year, month, days);

            var ex = Assert.Throws<ArgumentException>(() => dateCalculator.AddDays(daysToAdd));
            Assert.That(ex.Message, Is.EqualTo(Constants.yearMaxExceededErrorMessage));
        }

        [TestCase("31/01/2018", -1000000)]
        public void AddDaysTest_Exception_MinDate(string date, int daysToAdd)
        {
            var dateFormatter = new DateFormatter();
            dateFormatter.GetDateElements(date, out int year, out int month, out int days);

            var dateCalculator = new DateCalculator(year, month, days);

            var ex = Assert.Throws<ArgumentException>(() => dateCalculator.AddDays(daysToAdd));
            Assert.That(ex.Message, Is.EqualTo(Constants.yearMinExceededErrorMessage));
        }
    }
}
