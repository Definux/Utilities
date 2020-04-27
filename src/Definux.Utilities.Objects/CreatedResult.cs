using System;

namespace Definux.Utilities.Objects
{
    public class CreatedResult
    {
        private int? createdEntityAsInt;
        private Guid? createdEntityIdAsGuid;

        public CreatedResult(int createdEntityId)
        {
            this.createdEntityAsInt = createdEntityId;
        }

        public CreatedResult(Guid createdEntityId)
        {
            this.createdEntityIdAsGuid = createdEntityId;
        }

        public string CreatedEntityId 
        { 
            get
            {
                if (this.createdEntityAsInt.HasValue)
                {
                    return this.createdEntityAsInt.Value.ToString();
                }
                else if (this.createdEntityIdAsGuid.HasValue)
                {
                    return this.createdEntityIdAsGuid.Value.ToString();
                }

                return null;
            }
        }
    }
}
