using System;
using System.Linq;
using Microsoft.Xrm.Sdk;
using web.Commands;
using web.Models;
using Xunit;

namespace WebCdsWithFakeXrmEasy.UnitTests
{
    public class ContactTests: FakeXrmEasyTestsBase
    {
        private readonly SaveContactCommand _createContactCommand;

        public ContactTests() : base()
        {
            _createContactCommand = new SaveContactCommand(_service);
        }

        [Fact]
        public void Should_succeed_and_create_new_contact()
        {
            var result = _createContactCommand.Save(new ContactDetailsModel() 
            {
                FirstName = "Leo",
                LastName = "Messi"
            });

            Assert.True(result.Succeeded);

            var createdContact = _context.CreateQuery("contact").FirstOrDefault();
            Assert.NotNull(createdContact);
            Assert.Equal("Leo", createdContact["firstname"]);
            Assert.Equal("Messi", createdContact["lastname"]);
        }

        [Fact]
        public void Should_fail_and_not_create_contact_with_a_duplicate_email()
        {
            _context.Initialize(new Entity("contact")
            {
                Id = Guid.NewGuid(),
                ["emailaddress1"] = "leo.messi@fcb.cat"
            });
            
            var result = _createContactCommand.Save(new ContactDetailsModel() 
            {
                FirstName = "Leo",
                LastName = "Messi",
                Email = "leo.messi@fcb.cat"
            });

            Assert.False(result.Succeeded);

            var contacts = _context.CreateQuery("contact").ToList();
            Assert.Single(contacts);
        }
    }
}
