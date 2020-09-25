using System.IO;
using Calabonga.AspNetCore.Controllers.Base;
using Calabonga.EntityFrameworkCore.Entities.Base;
using Calabonga.OperationResults;

namespace Calabonga.AspNetCore.Controllers.Queries
{
    /// <summary>
    /// Query for GenerateUpdateViewModel getting operation
    /// </summary>
    /// <typeparam name="TCreateViewModel"></typeparam>
    public abstract class CreateViewModelQuery<TCreateViewModel> : RequestBase<OperationResult<TCreateViewModel>>, IViewModel 
        where TCreateViewModel : class, IViewModel
    {

    }
}