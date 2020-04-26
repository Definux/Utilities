namespace Definux.Utilities.Objects
{
    public class SuccessCreateResultAsInteger : SuccessCreateResult<int>
    {
        public SuccessCreateResultAsInteger(int createdEntityId)
            : base(createdEntityId)
        {
        }
    }
}
