using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Client;
using web.Extensions;
using web.Models;
using System.Linq;

namespace web.Commands
{
    public class SaveContactCommand
    {
        private readonly IOrganizationService _service;
        public SaveContactCommand(IOrganizationService service) 
        {
            _service = service;
        }
        public GenericResult Save(ContactDetailsModel model)
        {
            return null;
        }

    }
}
