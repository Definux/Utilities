namespace Definux.Utilities.Validation
{
    public interface IHandler<T>
    {
        IHandler<T> SetNext(IHandler<T> handler);

        T Handle(T requestObject, out string validationResultMessage);
    }
}
