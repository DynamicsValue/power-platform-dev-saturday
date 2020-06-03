using System;

namespace web.Models
{
    public class ContactRowModel
    {
        public Guid Id { get; set;}
        public string FullName { get; set; }
        public string Email { get; set; }
        
        public string CompanyName { get; set; }
        public string BusinessPhone { get; set; }
    }
}