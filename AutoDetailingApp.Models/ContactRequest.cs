using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace AutoDetailingApp.Models
{
    public class ContactRequest
    {
        public ContactRequest()
        {
            this.Id = Guid.NewGuid();
        }

        public Guid Id { get; set;}

        public string FullName { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        public string Message { get; set; }

        public DateTime CreatedAt { get; set; }

    }
}
