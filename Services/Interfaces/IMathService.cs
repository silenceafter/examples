namespace service_template.Services.Interfaces
{
    public interface IMathService
    {
        double CalculateAverage(IEnumerable<int> numbers);
        int FindMaximum(IEnumerable<int> numbers);
        int FindMinimum(IEnumerable<int> numbers);
        IEnumerable<int> SortNumbers(IEnumerable<int> numbers);
    }
}
