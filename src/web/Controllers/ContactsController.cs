using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using web.Commands;
using web.Extensions;
using web.Models;

namespace web.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ContactsController : ControllerBase
    {
        private readonly ILogger<ContactsController> _logger;
        private readonly IOrganizationService _orgService;
        public ContactsController(ILogger<ContactsController> logger, IOrganizationService orgService)
        {
            _logger = logger;
            _orgService = orgService;
        }

        [HttpGet]
        public IEnumerable<ContactRowModel> Get()
        {
            var fetchxml =
                $@"<fetch version='1.0' output-format='xml-platform' mapping='logical'>
                        <entity name='contact'>
                        <attribute name='fullname' />
                        <attribute name='emailaddress1' />
                        <attribute name='parentcustomerid' />
                        <attribute name='telephone1' />
                        <order attribute='fullname' />
                        </entity>
                    </fetch>";

            var contactResponse = _orgService.RetrieveMultiple(new FetchExpression(fetchxml));

            return contactResponse.Entities.Select(e => e.ToContactRowModel());
        }


        [HttpGet("{id}")]
        public ContactDetailsModel Get(Guid id)
        {
            var contactResponse = _orgService.Retrieve("contact", id, new ColumnSet(new string[] { "firstname", "lastname", "emailaddress1", "telephone1" }));

            return contactResponse.ToContactDetailsModel();
        }

        [HttpPut]
        public GenericResult SaveNewContact([FromBody] ContactDetailsModel model)
        {
            var cmd = new SaveContactCommand(_orgService);
            return cmd.Save(model);
        }

        [HttpPost("{id}")]
        public GenericResult SaveNewContact(Guid id, [FromBody] ContactDetailsModel model)
        {
            var cmd = new SaveContactCommand(_orgService);
            model.Id = id;
            return cmd.Save(model);
        }
    }
}