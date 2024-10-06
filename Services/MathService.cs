using service_template.Services.Interfaces;

namespace service_template.Services
{
    public class MathService : IMathService
    {
        public double CalculateAverage(IEnumerable<int> numbers)
        {
            if (!numbers.Any())
            {
                throw new ArgumentException("Список чисел не должен быть пустым.");
            }

            return numbers.Average();
        }

        public int FindMaximum(IEnumerable<int> numbers)
        {
            if (!numbers.Any())
            {
                throw new ArgumentException("Список чисел не должен быть пустым.");
            }

            return numbers.Max();
        }

        public int FindMinimum(IEnumerable<int> numbers)
        {
            if (!numbers.Any())
            {
                throw new ArgumentException("Список чисел не должен быть пустым.");
            }

            return numbers.Min();
        }

        public IEnumerable<int> SortNumbers(IEnumerable<int> numbers)
        {
            return numbers.OrderBy(n => n);
        }
    }
}
