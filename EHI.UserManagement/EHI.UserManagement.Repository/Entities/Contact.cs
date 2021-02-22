using EHI.UserManagement.Repository.Enums;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using Newtonsoft.Json.Converters;
using System.Text.Json.Serialization;

namespace EHI.UserManagement.Repository.Entities
{
    /// <summary>
    /// Contact Entity class
    /// </summary>
    public class Contact: BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }

        [JsonConverter(typeof(StringEnumConverter))]
        public ContactStatus Status { get; set; }
    }
}
