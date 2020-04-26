namespace Definux.Utilities.Objects
{
    public class SuccessCreateResult<T>
    {
        public SuccessCreateResult(T createdEntityId)
        {
            CreatedEntityId = createdEntityId;
        }

        public T CreatedEntityId { get; set; }
    }
}
