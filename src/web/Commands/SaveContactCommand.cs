using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Client;
using web.Extensions;
using web.Models;
using System.Linq;

namespace web.Commands
{
    public class SaveContactCommand
    {
        private const string Email = "emailaddress1";
        private const string Contact = "contact";

        private readonly IOrganizationService _service;
        public SaveContactCommand(IOrganizationService service)
        {
            _service = service;
        }

        public GenericResult Save(ContactDetailsModel model)
        {
            using(var ctx = new OrganizationServiceContext(_service))
            {
                var existingContact = (from c in ctx.CreateQuery(Contact)
                                        where (string) c[Email] == model.Email
                                        select c).FirstOrDefault();

                if(existingContact == null)
                {
                    _service.Create(model.ToEntity());
                    return GenericResult.Succeed();
                }
                else 
                {
                    return GenericResult.FailWith($"Contact with email '{model.Email}' already exists");
                }
            }
            
            
        }

    }
}
