using System;

namespace Definux.Utilities.Validation
{
    public abstract class Handler<T> : IHandler<T>
    {
        private IHandler<T> nextHandler;
        protected T requestObject;

        /// <summary>
        /// Receive object and validation message. If current validation pass successfully continue with the validation chain. If validation fail - return null.
        /// </summary>
        /// <param name="requestObject"></param>
        /// <param name="validationResultMessage"></param>
        /// <returns></returns>
        public virtual T Handle(T requestObject, out string validationResultMessage)
        {
            this.requestObject = requestObject;
            validationResultMessage = HandleProcessAction();

            T returnObject = this.requestObject;
            if (returnObject != null && this.nextHandler != null)
            {
                string newResultMessage = string.Empty;
                returnObject = this.nextHandler.Handle(requestObject, out newResultMessage);

                validationResultMessage += newResultMessage;
            }

            return returnObject;
        }

        /// <summary>
        /// Set next validation handler to validation chain.
        /// </summary>
        /// <param name="handler"></param>
        /// <returns></returns>
        public IHandler<T> SetNext(IHandler<T> handler)
        {
            this.nextHandler = handler;

            return handler;
        }

        /// <summary>
        /// Method that contains current validation logic for current handler. If validation pass successfully return empty string as a message, if not - return validation message and set handler object to null.
        /// </summary>
        /// <returns></returns>
        protected virtual string HandleProcessAction()
        {
            throw new NotImplementedException("Handler has no process action implementation.");
        }
    }
}
