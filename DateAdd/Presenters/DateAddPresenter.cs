using DateOperations;
using DateAdd.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DateAdd.Models;

namespace DateAdd.Presenters
{
    public class DateAddPresenter : IDateAddPresenter
    {
        private readonly IDateAddModel dateAddModel;

        public IDateAddView DateAddView
        { get; set; }

        public DateAddPresenter(IDateAddModel dateAddModel) 
        {
            this.dateAddModel = dateAddModel;
        }

        public void SetDateAddView(IDateAddView dateAddView)
        {
            DateAddView = dateAddView;
        }

        public string AddDays()
        {
            var result = string.Empty;

            try
            {
                result = dateAddModel.AddDays(DateAddView.DateText, DateAddView.DaysToAddText);
            }
            catch(Exception ex)
            {
                result = ex.Message;
            }

            return result;
        }
    }
}
