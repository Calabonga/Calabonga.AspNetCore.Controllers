using Calabonga.AspNetCore.Controllers.Demo.ViewModels;
using Calabonga.AspNetCore.Controllers.Handlers;
using Calabonga.AspNetCore.Controllers.Queries;
using Calabonga.OperationResults;

namespace Calabonga.AspNetCore.Controllers.Demo.Controllers.Queries
{
    public class PersonCreateViewModelQuery : CreateViewModelQuery<PersonCreateViewModel>
    {

    }

    public class PersonCreateViewModelHandler : CreateViewModelHandlerBase<PersonCreateViewModelQuery, PersonCreateViewModel>
    {
        /// <summary>
        /// Process operation result
        /// </summary>
        /// <param name="operationResult"></param>
        /// <returns></returns>
        protected override OperationResult<PersonCreateViewModel> OperationResultBeforeReturn(OperationResult<PersonCreateViewModel> operationResult)
        {
            operationResult.AppendLog("OperationResultBeforeReturn FIRED!");
            return base.OperationResultBeforeReturn(operationResult);
        }

        
    }

}
