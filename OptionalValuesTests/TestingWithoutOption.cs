using OptionalValues;
using System;
using System.Collections.Generic;
using System.Text;
using OptionalValues.WithoutOption;
using Xunit;

namespace OptionalValuesTests
{
    public class TestingWithoutOption
    {
        [Fact]
        public void NoOption_TestNoneCase_ShouldReturnNone()
        {
            IAlpha obj = Alpha.None;
            Assert.Equal(0, obj.Value);
            Assert.Equal(0, obj.GetValue());
            obj.SetValue(5);
            Assert.Equal(0, obj.Value);
            Assert.Equal(0, obj.GetValue());
            Assert.True(obj.IsNone);
        }

        [Fact]
        public void NoOption_TestValueCase_ShouldReturnValue()
        {
            IAlpha obj = new Alpha(42.2);
            Assert.Equal(42.2, obj.Value);
            Assert.Equal(42.2, obj.GetValue());
            obj.SetValue(5);
            Assert.Equal(5, obj.Value);
            Assert.Equal(5, obj.GetValue());
            Assert.False(obj.IsNone);
        }
    }
}
