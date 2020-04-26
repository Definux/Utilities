using System;

namespace Definux.Utilities.Objects
{
    public class SuccessCreateResultAsGuid : SuccessCreateResult<Guid>
    {
        public SuccessCreateResultAsGuid(Guid createdEntityId)
            : base(createdEntityId)
        {
        }
    }
}
