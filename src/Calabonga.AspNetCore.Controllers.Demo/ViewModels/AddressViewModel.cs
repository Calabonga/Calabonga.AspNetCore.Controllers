using Calabonga.EntityFrameworkCore.Entities.Base;

namespace Calabonga.AspNetCore.Controllers.Demo.ViewModels
{
    public class AddressViewModel : ViewModelBase
    {
        public string Name { get; set; }

        public string Content { get; set; }
    }
}