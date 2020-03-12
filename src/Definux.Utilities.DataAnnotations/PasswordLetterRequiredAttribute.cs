using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Definux.Utilities.DataAnnotations
{
    public class PasswordLetterRequiredAttribute : ValidationAttribute
    {
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
