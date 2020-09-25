using System.Collections;
using System.Collections.Generic;
using Calabonga.EntityFrameworkCore.Entities.Base;

namespace Calabonga.AspNetCore.Controllers.Demo.Entities
{
    
    public class Person : Identity
    {
        public string LastName { get; set; }

        public string FirstName { get; set; }

        public ICollection<Address> Addresses { get; set; }
    }
}