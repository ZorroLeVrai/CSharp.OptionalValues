using System;
using Xunit;
using OptionalValues;

namespace OptionalValuesTests
{
    public class OptionUsingEnumerableTests
    {
        [Theory]
        [InlineData(OptionType.UsingEnumerable)]
        [InlineData(OptionType.UsingStruct)]
        public void OptionCase_CheckFunctionReturnNone_ShouldNotRaiseException(OptionType optionType)
        {
            var itemToTest = GetValue();
            var result = itemToTest.Apply(item => item.AddYears(1))
                .ApplyOption(item => item.GetDividedAge(2));

            Assert.True(result.IsNone);

            IOption<TestForOption> GetValue()
            {
                return OptionFactory
                    .Create(optionType)
                    .CreateEmpty<TestForOption>();
            }
        }

        [Theory]
        [InlineData(OptionType.UsingEnumerable)]
        [InlineData(OptionType.UsingStruct)]
        public void OptionCase_CheckOperationReturnNone_ShouldNotRaiseException(OptionType optionType)
        {
            var itemToTest = GetValue();
            var result = itemToTest.Apply(item => item.AddYears(1))
                .ApplyOption(item => item.GetDividedAge(0));

            Assert.True(result.IsNone);

            IOption<TestForOption> GetValue()
            {
                return OptionFactory
                    .Create(optionType)
                    .Create(new TestForOption("Adam", 5));
            }
        }

        [Theory]
        [InlineData(OptionType.UsingEnumerable)]
        [InlineData(OptionType.UsingStruct)]
        public void OptionCase_CheckOperationReturnValue_ShouldReturnTheRightValue(OptionType optionType)
        {
            var itemToTest = GetValue();
            var result = itemToTest.Apply(item => item.AddYears(1))
                .ApplyOption(item => item.GetDividedAge(2));

            Assert.False(result.IsNone);
            Assert.Equal(3, result.GetValue(0));

            IOption<TestForOption> GetValue()
            {
                return OptionFactory
                    .Create(optionType)
                    .Create(new TestForOption("Adam", 5));
            }
        }
    }
}
