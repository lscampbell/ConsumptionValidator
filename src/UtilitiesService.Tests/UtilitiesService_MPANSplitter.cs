
using System;
using Xunit;
using UtilitiesService;
using UtilitiesService.Models;

namespace UtilitiesService.Tests
{
    public class UtilitiesService_MPANSplitter
    {
        [Fact]
        public void ReturnFalseGivenValueLengthLessThan12InLength()
        {
            string value = "143234";
            var result = MpanHelper.Split(value);
            Assert.False(result.Complete, $"{value} should not be mpan");
        }

        [Fact]
        public void ReturnTrueGivenValueLengthGreaterThan12InLength()
        {
            string value = "1900033146143";
            var result = MpanHelper.Split(value);
            Assert.True(result.Complete, $"{value} should not be mpan");
        }

        [Fact]
        public void ReturnCorrectCheckDigit()
        {
            string value = "1900033146143";
            var result = MpanHelper.Split(value);
            Assert.Equal(result.Result.CheckDigit, "143");
        }
        [Fact]
        public void ReturnCorrectDistributionId()
        {
            string value = "1900033146143";
            var result = MpanHelper.Split(value);
            Assert.Equal(result.Result.DistributionId, "19");
        }

        [Fact]
        public void ReturnCorrectResult()
        {
            string value = "009998071900033146143";
            var result = MpanHelper.Split(value);

            Assert.Equal(result.Result.Mpan, "009998071900033146143");
            Assert.Equal(result.Result.SupplyPointRef, "1900033146143");
            Assert.Equal(result.Result.ProfileType, "00");
            Assert.Equal(result.Result.MeterTimeSwitchCode, "999");
            Assert.Equal(result.Result.LLF, "807");
            Assert.Equal(result.Result.DistributionId, "19");
            Assert.Equal(result.Result.UniqueIdentifer, "00033146");
            Assert.Equal(result.Result.CheckDigit, "143");
        }
    }
}
