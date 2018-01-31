using System;
using Xunit;
using CalculatorService;

namespace CalculatorService.Tests
{
    public class CalculatorService_RetrieveTestData
    {
        readonly RetrieveData _rd = new RetrieveData(
            "2012-02-01",
            "9912345678345",
            "222",
            "TEST"
        );

        [Fact]
        public void ReturnsListOfFactors()
        {
            var result = _rd.GetLosses();
            Assert.True(result.Count != 0, $"List is filled with data");
        }
        
        [Fact]
        public void ReturnsOneFactor()
        {
            var result = _rd.GetTLossFactor();
            Assert.True(result != 0F, $"Object is not zero");
        }

        [Fact]
        public void ReturnListOfBands()
        {
            var result = _rd.GetDuosTimeBands();
            Assert.True(result.Count != 0, $"List is filled with data");
        }

        [Fact]
        public void ReturnListOfTariffs()
        {
            var result = _rd.GetDuosTariffs();
            Assert.True(result.Count != 0, $"List is filled with data");
        }

        [Fact]
        public void ReturnListOfProfile()
        {
            var result = _rd.GetProfileData();
            Assert.True(result.Count != 0, $"List is filled with data");            
        }

        [Fact]
        public void ReturnOneCustomer()
        {
            var result = _rd.GetCustomerName();
            Assert.True(result != string.Empty, $"String is filled with data");            
        }

        [Fact]
        public void ReturnListOfCharges()
        {
            var result = _rd.GetContractBands();
            Assert.True(result.Count != 0, $"List is filled with data");
        }

        [Fact]
        public void ReturnOneCapacity()
        {
            var result = _rd.GetSupplyCapacity();
            Assert.True(result != 0, $"Object is not zero");
        }
    }
}
