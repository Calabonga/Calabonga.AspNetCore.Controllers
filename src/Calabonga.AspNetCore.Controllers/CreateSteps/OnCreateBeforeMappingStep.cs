namespace Calabonga.AspNetCore.Controllers.CreateSteps
{
    /// <summary>
    /// Step for Create pipeline 1
    /// </summary>
    public class OnCreateBeforeMappingStep : HandlerStep

    {
        /// <inheritdoc />
        public OnCreateBeforeMappingStep(IHandlerContext context)
        {
            Context = context;
        }

        /// <inheritdoc />
        protected override int OrderIndex => 1;
    }
}