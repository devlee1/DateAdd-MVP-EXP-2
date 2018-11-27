using DateAdd.Views;

namespace DateAdd.Presenters
{
    public interface IDateAddPresenter
    {
        void SetDateAddView(IDateAddView dateAddView);

        string AddDays();
    }
}