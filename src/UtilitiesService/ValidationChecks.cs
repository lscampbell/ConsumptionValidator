using System;

namespace UtilitiesService
{
    public class ValidationChecks
    {
        public static bool MPANIsValid(string mpan)
        {
            // Set initial conditions.
            bool validationResult = false;

            if (mpan.Length > 12) {
                //Read the check digit into an Integer variable.
                int intCheckDigit = 0;
                if (int.TryParse(mpan.Substring(mpan.Length - 1), out intCheckDigit)) {
                    string strTest = mpan.Substring(mpan.Length - 13, 12);
                    int[] intPrimes = {3, 5, 7, 13, 17, 19, 23, 29, 31, 37, 41, 43};
                    int productTotal = 0;
                    bool blnError = false;

                    for(int i = 0; i <= 11; i++) {
                        int intTestDigit = 0;
                        if (int.TryParse(strTest.Substring(i, 1), out intTestDigit)) {
                            productTotal += (intTestDigit * intPrimes[i]); 
                        } 
                        else {
                            blnError = true;
                            break; 
                        }
                    }
                    if (!blnError) {
                        validationResult = ((productTotal % 11 % 10) == intCheckDigit);
                    } 
                    else { 
                        validationResult = false; // Due to a parsing error.
                    } 
                }
            }
            return validationResult;
        } 
    }
}
