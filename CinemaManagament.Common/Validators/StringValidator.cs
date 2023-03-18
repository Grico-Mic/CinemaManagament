using CinemaManagament.Common.Exceptions;
using System;


namespace CinemaManagament.Common.Validators
{
    public static class StringValidator
    {
        public static string CheeckNullOrEmpty(this string input)
        {
          

            if (String.IsNullOrEmpty(input))
            {
                throw new CinemaManagamentExceptions("Invalid Input");
            }
            return input;
        }

        public static int ValidatePositiveInteger(string input)
        {
            var rezult = int.TryParse(input, out int parsed);

            if (!rezult || parsed < 0)
            {
                throw new CinemaManagamentExceptions("Invalid parse");
            }
            return parsed;
        }

        public static decimal ValidatePositiveDecimal(string input)
        {
            var rezult = decimal.TryParse(input, out decimal parsed);

            if (!rezult || parsed < 0)
            {
                throw new CinemaManagamentExceptions("Invalid input");
            }
            return parsed;
        }
    }

    
}
