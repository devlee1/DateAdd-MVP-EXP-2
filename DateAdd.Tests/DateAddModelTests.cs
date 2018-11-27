using DateAdd.Models;
using DateOperations;
using Moq;
using NUnit.Framework;
using System;

namespace DateAdd.Tests
{
    [TestFixture]
    public class DateAddModelTests
    {
        [TestCase("20/01/2016", "0", ExpectedResult = "20/01/2016")]
        public string TestDateAddModel(string date, string daysToAdd)
        {
            var dateCalculator = new Mock<IDateCalculator>();
            var dateAddModel = new DateAddModel(dateCalculator.Object);

            dateCalculator.Setup(o => o.AddDays(It.IsAny<string>(), It.IsAny<int>())).Returns("20/01/2016");

            return dateAddModel.AddDays(date, daysToAdd);
        }

        [TestCase("20/01/2016", "")]
        public void TestDateAddModel_NumberOfDaysException(string date, string daysToAdd)
        {
            var dateCalculator = new Mock<IDateCalculator>();
            var dateAddModel = new DateAddModel(dateCalculator.Object);
            var ex = Assert.Throws<ArgumentException>(() => dateAddModel.AddDays(date, daysToAdd));
            Assert.That(ex.Message, Is.EqualTo(Constants.invalidNumberOfDaysErrorMessage));
        }
    }
}
