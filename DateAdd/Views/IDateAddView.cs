using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DateAdd.Views
{
    public interface IDateAddView
    {
        string DateText { get; set; }
        string DaysToAddText { get; set; }
        string OutputText { get; set; }
    }
}
