using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;
using System;
using System.Collections.Generic;

namespace web.Controllers
{
    [ApiController]
    [Route("[controller]")]
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
        public IEnumerable<Entity> Get()
        {
            var fetchxml =
                $@"<fetch version='1.0' output-format='xml-platform' mapping='logical'>
                        <entity name='contact'>
                        <all-attributes />
                        </entity>
                    </fetch>";

            var contactResponse = _orgService.RetrieveMultiple(new FetchExpression(fetchxml));

            return contactResponse.Entities;
        }


        [HttpGet("{id}")]
        public string Get(Guid id)
        {
            var contactResponse = _orgService.Retrieve("contact", id, new ColumnSet(true));

            return contactResponse.GetAttributeValue<string>("fullname");
        }
    }
}