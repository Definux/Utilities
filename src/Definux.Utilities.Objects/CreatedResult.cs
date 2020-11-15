using System;

namespace Definux.Utilities.Objects
{
    /// <summary>
    /// Result of created operation that returns id of the created entity. Supports GUID and integer id.
    /// </summary>
    public class CreatedResult
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CreatedResult"/> class.
        /// </summary>
        /// <param name="createdEntityId"></param>
        public CreatedResult(int createdEntityId)
        {
            this.CreatedEntityId = createdEntityId.ToString();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CreatedResult"/> class.
        /// </summary>
        /// <param name="createdEntityId"></param>
        public CreatedResult(Guid createdEntityId)
        {
            this.CreatedEntityId = createdEntityId.ToString();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CreatedResult"/> class.
        /// </summary>
        /// <param name="createdEntityId"></param>
        public CreatedResult(string createdEntityId)
        {
            this.CreatedEntityId = createdEntityId;
        }

        /// <summary>
        /// Created entity id as string.
        /// </summary>
        public string CreatedEntityId { get; protected set; }
    }
}
