namespace Calabonga.AspNetCore.Controllers.CreateSteps
{
    /// <summary>
    /// Step for Create pipeline 4
    /// </summary>
    public class OnCreateOperationResultBuildStep: HandlerStep
    {
        /// <inheritdoc />
        public OnCreateOperationResultBuildStep(IHandlerContext context)
        {
            Context = context;
        }

        /// <inheritdoc />
        protected override int OrderIndex => 4;
    }
}