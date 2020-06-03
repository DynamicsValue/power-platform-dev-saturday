using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;
using System;
using System.Collections.Generic;
using System.Linq;
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

            return contactResponse.Entities.Select(e => new ContactRowModel()
            {
                Id = e.Id,
                FullName = e.GetAttributeValue<string>("fullname"),
                Email = e.GetAttributeValue<string>("emailaddress1"),
                CompanyName = e.GetAttributeValue<EntityReference>("parentcustomerid")?.Name,
                BusinessPhone = e.GetAttributeValue<string>("telephone1")
            });
        }


        [HttpGet("{id}")]
        public string Get(Guid id)
        {
            var contactResponse = _orgService.Retrieve("contact", id, new ColumnSet(true));

            return contactResponse.GetAttributeValue<string>("fullname");
        }
    }
}