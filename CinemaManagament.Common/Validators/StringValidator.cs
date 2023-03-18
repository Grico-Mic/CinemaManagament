using CinemaManagament.Common.Exceptions;
using System;


namespace CinemaManagament.Common.Validators
{
    public static class StringValidator
    {
        /// <summary>
        /// Check for string if is null or empty
        /// </summary>
        /// <param name="input"></param>
        /// <returns>Returns if string is valid.</returns>
        /// <exception cref="CinemaManagamentExceptions">description</exception>
        public static string CheeckNullOrEmpty(this string input)
        {
          

            if (String.IsNullOrEmpty(input))
            {
                throw new CinemaManagamentExceptions("Invalid Input");
            }
            return input;
        }
        /// <summary>
        /// Try to parse string in int.
        /// </summary>
        /// <param name="input"></param>
        /// <returns>Return if int is parsed.</returns>
        /// <exception cref="CinemaManagamentExceptions">description</exception>
        public static int ValidatePositiveInteger(this string input)
        {
            var rezult = int.TryParse(input, out int parsed);

            if (!rezult || parsed < 0)
            {
                throw new CinemaManagamentExceptions("Invalid parse");
            }
            return parsed;
        }
        /// <summary>
        /// Try parse string in decimal.
        /// </summary>
        /// <param name="input"></param>
        /// <returns>Return if decimal is parsed.</returns>
        /// <exception cref="CinemaManagamentExceptions">description</exception>
        public static decimal ValidatePositiveDecimal(this string input)
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
