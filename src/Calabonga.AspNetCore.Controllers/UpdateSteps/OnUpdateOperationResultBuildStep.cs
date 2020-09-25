namespace Calabonga.AspNetCore.Controllers.UpdateSteps
{
    /// <summary>
    /// Step for Create pipeline 4
    /// </summary>
    public class OnUpdateOperationResultBuildStep: HandlerStep
    {
        /// <inheritdoc />
        public OnUpdateOperationResultBuildStep(IHandlerContext context)
        {
            Context = context;
        }

        /// <inheritdoc />
        protected override int OrderIndex => 4;

        
    }
}