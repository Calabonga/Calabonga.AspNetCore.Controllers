using Calabonga.OperationResults;

namespace Calabonga.AspNetCore.Controllers.Base
{
    public abstract class OperationResultRequestBase<TResponse> : RequestBase<OperationResult<TResponse>>
    {

    }
}