using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KEService.Models
{
    public class PersonModel
    {
        public string Oid { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public string Birthday { get; set; }
        public string Email { get; set; }
    }
}
