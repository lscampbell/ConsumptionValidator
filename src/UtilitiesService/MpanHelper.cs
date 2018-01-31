using UtilitiesService.Models;

namespace UtilitiesService
{
    public class MpanHelper
    {
        public static Maybe<MeterPointAdministrationNumber> Split(string mpan)
        {
            var result = new Maybe<MeterPointAdministrationNumber> 
                            { 
                                Complete = false, 
                                Result = new MeterPointAdministrationNumber(), 
                                Message = $"Error splitting mpan: {mpan}" 
                            };
            
            if(!ValidationChecks.MPANIsValid(mpan))
                return result;

            switch(mpan.Length)
            {
                case 21:
                    {
                        result.Complete = true;
                        result.Result = new MeterPointAdministrationNumber{
                            Id = 1,
                            Mpan = mpan,
                            SupplyPointRef = mpan.Substring(8, 13),
                            ProfileType = mpan.Substring(0, 2),
                            MeterTimeSwitchCode = mpan.Substring(2, 3),
                            LLF = mpan.Substring(5, 3),
                            DistributionId = mpan.Substring(8, 2),
                            UniqueIdentifer = mpan.Substring(10, 8),
                            CheckDigit = mpan.Substring(mpan.Length - 3)
                        };

                    }
                    break;
                case 13:
                    {
                        result.Complete = true;
                        result.Result = new MeterPointAdministrationNumber{
                            Id = 1,
                            Mpan = mpan,
                            SupplyPointRef = mpan,
                            CheckDigit = mpan.Substring(mpan.Length - 3),
                            DistributionId = mpan.Substring(0, 2)
                        };
                    }
                    break;
                default:
                    {
                        result.Complete = true;
                        result.Result = new MeterPointAdministrationNumber{
                            Id = 1,
                            Mpan = mpan,
                            SupplyPointRef = mpan
                        };
                    }
                break;
            }
            result.Message = string.Empty;            
            return result;
        }
    }
}