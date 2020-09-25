namespace Calabonga.AspNetCore.Controllers.CreateSteps
{
    /// <summary>
    /// Step for Create pipeline 3
    /// </summary>
    public class OnCreateBeforeSaveChangesStep: HandlerStep
    {
        /// <inheritdoc />
        public OnCreateBeforeSaveChangesStep(IHandlerContext context)
        {
            Context = context;
        }

        /// <inheritdoc />
        protected override int OrderIndex => 3;
    }
}