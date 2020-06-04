using Microsoft.Xrm.Sdk;
using web.Models;

namespace web.Extensions
{
    public static class ContactEntityExtensions
    {
        public static ContactRowModel ToContactRowModel(this Entity e) 
        {
            return new ContactRowModel()
            {
                Id = e.Id,
                FullName = e.GetAttributeValue<string>("fullname"),
                Email = e.GetAttributeValue<string>("emailaddress1"),
                CompanyName = e.GetAttributeValue<EntityReference>("parentcustomerid")?.Name,
                BusinessPhone = e.GetAttributeValue<string>("telephone1")
            };
        }

        public static ContactDetailsModel ToContactDetailsModel(this Entity e) 
        {
            return new ContactDetailsModel()
            {
                Id = e.Id,
                FirstName = e.GetAttributeValue<string>("firstname"),
                LastName = e.GetAttributeValue<string>("lastname"),
                Email = e.GetAttributeValue<string>("emailaddress1"),
                BusinessPhone = e.GetAttributeValue<string>("telephone1")
            };
        }

        public static Entity ToEntity(this ContactDetailsModel model) 
        {
            return new Entity("contact")
            {
                Id = model.Id,
                ["firstname"] = model.FirstName,
                ["lastname"] = model.LastName,
                ["emailaddress1"] = model.Email,
                ["telephone1"] = model.BusinessPhone
            };
        }
    }
}