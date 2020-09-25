using Calabonga.EntityFrameworkCore.Entities.Base;

namespace Calabonga.AspNetCore.Controllers.Demo.ViewModels
{
    public class PersonCreateViewModel : IViewModel
    {
        public string LastName { get; set; }

        public string FirstName { get; set; }
    }
}