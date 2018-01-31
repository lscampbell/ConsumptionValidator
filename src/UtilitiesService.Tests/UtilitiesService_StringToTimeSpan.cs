using System;
using Xunit;
using UtilitiesService;

namespace UtilitiesService.Tests
{
    public class UtilitiesService_StringToTimeSpan
    {
        StringTo _st = new StringTo();
        
        [Theory]
        [InlineData("00")]
        [InlineData("000000")]
        [InlineData("143234")]
        public void ReturnFalseIfStringInWrongFormat(string value)
        {
            var result = _st.TimeSpan(value);
            Assert.False(result.Complete, result.Message);
        }

        [Theory]
        [InlineData("14:32:34")]
        public void ReturnTrueIfStringInRightFormat(string value)
        {
            var result = _st.TimeSpan(value);
            Assert.True(result.Complete, result.Message);
        }

        [Fact]
        public void ReturnTrueIfStringIsEmpty()
        {
            var result = _st.TimeSpan();
            Assert.True(result.Complete, result.Message);
        }
    }
}