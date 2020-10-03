using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Definux.Utilities.DataAnnotations
{
    /// <summary>
    /// Validation attribute that check whether the value is password that contains at least one letter.
    /// </summary>
    public class PasswordLetterRequiredAttribute : ValidationAttribute
    {
        /// <inheritdoc/>
        public override bool IsValid(object value)
        {
            if (value != null)
            {
                string password = value.ToString();
                return password.Any(x => char.IsLetter(x));
            }

            return true;
        }
    }
}
