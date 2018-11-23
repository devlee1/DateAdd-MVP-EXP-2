using DateOperations;
using DateAdd.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DateAdd.Presenters
{
    public class DateAddPresenter
    {
        IDateAdd dateAddView;

        public DateAddPresenter(IDateAdd view)
        {
            dateAddView = view;
        }

        public void AddDays()
        {
            var date = dateAddView.DateText;

            try
            {
                var dateFormatter = new DateFormatter();
                dateFormatter.GetDateElements(date, out int year, out int month, out int day);

                var dateCalculator = new DateCalculator(year, month, day);

                dateAddView.OutputText = dateCalculator.AddDays(int.Parse(dateAddView.DaysToAddText));
            }
            catch (Exception ex)
            {
                dateAddView.OutputText = ex.Message;
            }
        }
    }
}
