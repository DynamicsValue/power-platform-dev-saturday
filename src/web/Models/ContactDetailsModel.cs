using System;

namespace web.Models
{
    public class ContactDetailsModel
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get ;set; }
        public string BusinessPhone { get; set; }
    }
}
