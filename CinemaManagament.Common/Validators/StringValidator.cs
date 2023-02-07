using CinemaManagament.Common.Exceptions;
using System;


namespace CinemaManagament.Common.Validators
{
    public class StringValidator
    {
        public string CheeckNullOrEmpty(string input)
        {
          

            if (String.IsNullOrEmpty(input))
            {
                throw new CinemaManagamentExceptions("Invalid Input");
            }
            return input;
        }
    }
}
