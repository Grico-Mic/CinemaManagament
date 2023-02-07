using CinemaManagament.Common.Exceptions;

namespace CinemaManagament.Common.Validators
{
    public static class IntegerValidator
    {
        public static int ValidatePositive(string input)
        {
            var rezult = int.TryParse(input, out int parsed);

            if (!rezult || parsed < 0)
            {
                throw new CinemaManagamentExceptions("Invalid input");
            }
            return parsed;
        }
    }
}
