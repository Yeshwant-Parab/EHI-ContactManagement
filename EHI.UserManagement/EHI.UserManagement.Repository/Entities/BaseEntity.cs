using System;

namespace EHI.UserManagement.Repository.Entities
{
    /// <summary>
    /// Used to include common properties to an Entity
    /// </summary>
    public class BaseEntity
    {
        public int Id { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }
    }
}
