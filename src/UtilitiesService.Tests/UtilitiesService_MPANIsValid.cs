using System;
using Xunit;
using UtilitiesService;

namespace UtilitiesService.Tests
{
    public class UtilitiesService_MPANIsValid
    {
        [Theory]
        [InlineData("1121")]
        [InlineData("000000")]
        [InlineData("143234")]
        public void ReturnFalseGivenValueLengthLessThan12InLength(string value)
        {
            var result = ValidationChecks.MPANIsValid(value);
            Assert.False(result, $"{value} should not be mpan");
        }

        [Theory]
        [InlineData("1900033146143")]
        [InlineData("0000000000000")]
        public void ReturnTrueGivenValueLengthGreaterThan12InLength(string value)
        {
            var result = ValidationChecks.MPANIsValid(value);
            Assert.True(result, $"{value} should not be mpan");
        }

        [Theory]
        [InlineData("1121682346772")]
        [InlineData("0000000000001")]
        [InlineData("1432342343242")]
        public void ReturnFalseGivenValueLengthGreaterThan12InLength(string value)
        {
            var result = ValidationChecks.MPANIsValid(value);
            Assert.False(result, $"{value} should not be mpan");
        }
    }
}
