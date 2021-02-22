using AutoMapper;
using EHI.UserManagement.Dto.Contact;
using EHI.UserManagement.Repository.Entities;

namespace EHI.UserManagement.Repository
{
    /// <summary>
    /// Add mappings between Entity and DTO objects
    /// </summary>
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Contact, ContactDetails>().ReverseMap();
        }
    }
}
