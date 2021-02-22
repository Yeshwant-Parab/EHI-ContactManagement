using EHI.UserManagement.Repository.Context;
using EHI.UserManagement.Repository.Entities;
using System.Linq;

namespace EHI.UserManagement.Repository
{/// <summary>
 ///Craete Contact table if not exists
 /// Add data to Contact table
 /// </summary>
    public static class DbInitializer
    {
        public static void Initialize(DatabaseContext context)
        {
            context.Database.EnsureCreated();

            if (context.Contact.Any())
            {
                return;  
            }

            var contacts = new Contact[]
            {
            new Contact{FirstName="Carson",LastName="Alexander",PhoneNumber="9874758962",Status = Enums.ContactStatus.Active, Email = "Carson@test.com"},
            new Contact{FirstName="Meredith",LastName="Alonso",PhoneNumber="6985124360",Status = Enums.ContactStatus.Active, Email = "Meredith@test.com"},
            new Contact{FirstName="Arturo",LastName="Anand",PhoneNumber="9898982013",Status = Enums.ContactStatus.Active, Email = "Arturo@test.com"},
            new Contact{FirstName="Gytis",LastName="Barzdukas",PhoneNumber="8798789560",Status = Enums.ContactStatus.Active, Email = "Gytis@test.com"},
            new Contact{FirstName="Yan",LastName="Li",PhoneNumber="5610235987",Status = Enums.ContactStatus.Active, Email = "Yan@test.com"},
            };
            foreach (var con in contacts)
            {
                context.Contact.Add(con);
            }
            context.SaveChanges();
        }
    }
}
