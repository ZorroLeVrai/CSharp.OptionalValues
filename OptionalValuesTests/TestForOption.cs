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

        public TestForOption AddYears(double years)
        {
            return new TestForOption(Name, Age + 1);
        }

        public Option<double> GetDividedAge(double number)
        {
            switch (number)
            {
                case 0.0:
                    return Option<double>.None;
                default:
                    return Option<double>.Create(Age / number);
            }
        }
    }
}
