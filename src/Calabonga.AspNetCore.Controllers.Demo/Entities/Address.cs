using System;
using Calabonga.EntityFrameworkCore.Entities.Base;

namespace Calabonga.AspNetCore.Controllers.Demo.Entities
{
    
    public class Address : Identity
    {
        public string Name { get; set; }

        public string Content { get; set; }

        public Guid PersonId { get; set; }

        public Person Person{ get; set; }
    }
}