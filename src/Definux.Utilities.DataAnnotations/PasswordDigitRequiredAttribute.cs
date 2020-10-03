using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Definux.Utilities.DataAnnotations
{
    /// <summary>
    /// Validation attribute that check whether the value is password that contains at least one digit.
    /// </summary>
    public class PasswordDigitRequiredAttribute : ValidationAttribute
    {
        /// <inheritdoc/>
        public override bool IsValid(object value)
        {
            if (value != null)
            {
                string password = value.ToString();
                return password.Any(x => char.IsDigit(x));
            }

            return true;
        }
    }
}
