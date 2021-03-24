using System.Linq;
using Definux.Utilities.Validation;
using Xunit;

namespace Definux.Utilities.Tests.Validation
{
    public class ValidationTests
    {
        [InlineData("This is cool text 123", true, "")]
        [InlineData("123 32", false, LetterHandler.ErrorMessage)]
        [InlineData("Random text", false, DigitHandler.ErrorMessage)]
        [InlineData("!@#$", false, LetterHandler.ErrorMessage)]
        [Theory]
        public void HandleValidation_ValidWorkflow_SuccessPassing(string text, bool valid, string expectedErrorMessage)
        {
            var startupHandler = new StartupHandler<string>();
            startupHandler
                .SetNext(new LetterHandler())
                .SetNext(new DigitHandler());

            var result = startupHandler.Handle(text, out var errorMessage);

            Assert.Equal(valid, result == text);
            Assert.Equal(expectedErrorMessage, errorMessage);
        }
    }

    public class DigitHandler : Handler<string>
    {
        public const string ErrorMessage = "String must have at least one digit";
        
        protected override string HandleProcessAction()
        {
            var resultMessage = string.Empty;
            var objectChars = RequestObject.ToCharArray();
            if (!objectChars.Any(char.IsNumber))
            {
                resultMessage = ErrorMessage;
                this.RequestObject = null;
            }

            return resultMessage;
        }
    }

    public class LetterHandler : Handler<string>
    {
        public const string ErrorMessage = "String must have at least one letter";
        
        protected override string HandleProcessAction()
        {
            var resultMessage = string.Empty;
            var objectChars = RequestObject.ToCharArray();
            if (!objectChars.Any(char.IsLetter))
            {
                resultMessage = ErrorMessage;
                this.RequestObject = null;
            }

            return resultMessage;
        }
    }
}