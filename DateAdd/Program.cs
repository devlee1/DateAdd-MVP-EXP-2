using DateAdd.Models;
using DateAdd.Presenters;
using DateAdd.Views;
using DateOperations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Unity;

namespace DateAdd
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            IUnityContainer container = new UnityContainer()
                .RegisterType<IDateCalculator, DateCalculator>()
                .RegisterType<IDateFormatter, DateFormatter>()
                .RegisterType<IDateAddModel, DateAddModel>()
                .RegisterType<IDateAddPresenter, DateAddPresenter>();

            var dateAddPresentor = container.Resolve<IDateAddPresenter>();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1(dateAddPresentor));
        }
    }
}
