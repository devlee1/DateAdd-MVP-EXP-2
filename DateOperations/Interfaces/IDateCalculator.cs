namespace DateOperations
{
    public interface IDateCalculator
    {
        string AddDays(int year, int month, int day, int daysToAdd);

        string AddDays(string date, int daysToAdd);
    }
}