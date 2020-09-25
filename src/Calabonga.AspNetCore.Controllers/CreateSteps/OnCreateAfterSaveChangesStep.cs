namespace Calabonga.AspNetCore.Controllers.CreateSteps
{
    /// <summary>
    /// Step for Create pipeline 5
    /// </summary>
    public class OnCreateAfterSaveChangesStep: HandlerResult
    {
        /// <inheritdoc />
        public OnCreateAfterSaveChangesStep(IHandlerContext context)
        {
            Context = context;
        }

        /// <inheritdoc />
        protected override int OrderIndex => 5;
    }
}