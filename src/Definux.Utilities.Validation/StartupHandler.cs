namespace Definux.Utilities.Validation
{
    public class StartupHandler<T> : Handler<T>
    {
        protected override string HandleProcessAction()
        {
            string resultMessage = string.Empty;
            if (this.requestObject == null)
            {
                resultMessage = "Requested object for validation is null. ";
            }

            return resultMessage;
        }
    }
}