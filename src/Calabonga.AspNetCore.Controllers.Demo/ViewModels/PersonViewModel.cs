using System.Collections.Generic;
using Calabonga.EntityFrameworkCore.Entities.Base;

namespace Calabonga.AspNetCore.Controllers.Demo.ViewModels
{
    public class PersonViewModel : ViewModelBase
    {
        public string LastName { get; set; }

        public string FirstName { get; set; }

        public List<AddressViewModel> Addresses { get; set; }
    }
}