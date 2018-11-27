namespace DateOperations
{
    public interface IDateFormatter
    {
        void GetDateElements(string date, out int year, out int month, out int day);

        string FormatDate(int year, int month, int day);
    }
}