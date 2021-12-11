using OptionalValues.UsingEnumerable;
using System.Diagnostics;

namespace OptionalValuesTests
{
    [DebuggerDisplay("Name = {Name}; Age = {Age}")]
    public class TestForOption
    {
        public string Name { get; }
        public double Age { get; }

        public TestForOption(string name, double age)
        {
            Name = name;
            Age = age;
        }

        public TestForOption AddYears(double nbYears)
        {
            return new TestForOption(Name, Age + nbYears);
        }

        public Option<double> GetDividedAge(double number)
        {
            return number switch
            {
                0.0 => Option<double>.None,
                _ => Option<double>.Create(Age / number)
            };
        }
    }
}
