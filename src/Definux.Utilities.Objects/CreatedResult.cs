using System;

namespace Definux.Utilities.Objects
{
    /// <summary>
    /// Result of created operation that returns id of the created entity. Supports GUID and integer id.
    /// </summary>
    public class CreatedResult
    {
        private int? createdEntityAsInt;
        private Guid? createdEntityIdAsGuid;

        /// <summary>
        /// Initializes a new instance of the <see cref="CreatedResult"/> class.
        /// </summary>
        /// <param name="createdEntityId"></param>
        public CreatedResult(int createdEntityId)
        {
            this.createdEntityAsInt = createdEntityId;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CreatedResult"/> class.
        /// </summary>
        /// <param name="createdEntityId"></param>
        public CreatedResult(Guid createdEntityId)
        {
            this.createdEntityIdAsGuid = createdEntityId;
        }

        /// <summary>
        /// Created entity id as string.
        /// </summary>
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

        /// <summary>
        /// Created entity id as GUID.
        /// </summary>
        public Guid? GuidId => this.createdEntityIdAsGuid;

        /// <summary>
        /// Created entity id as int.
        /// </summary>
        public int? IntId => this.createdEntityAsInt;
    }
}
