using System.ComponentModel.DataAnnotations;

namespace EHI.UserManagement.Dto.Contact
{
    /// <summary>
    /// Contact DTO class used to transfer data from web api to web project
    /// Included client validations for web project
    /// Mapping to entity is done in MappingProfile.cs in EHI.UserManagement.Repository library(Using Automapper)
    /// </summary>
    public class ContactDetails
    {
        public int Id { get; set; }

        [Required]
        [StringLength(30)]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Required]
        [StringLength(30)]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        [Required]
        [StringLength(30)]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [StringLength(15)]
        [RegularExpression(@"^([0-9]{10})$", ErrorMessage = "Invalid Phone Number.")]
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }
        public string Status { get; set; }
    }
}
