namespace Calabonga.AspNetCore.Controllers.UpdateSteps
{
    /// <summary>
    /// On UpdateAfterSaveChange Step
    /// </summary>
    public class OnUpdateAfterSaveChangeStep: HandlerResult
    {
        /// <inheritdoc />
        public OnUpdateAfterSaveChangeStep(IHandlerContext context)
        {
            Context = context;
        }

        /// <inheritdoc />
        protected override int OrderIndex => 5;
    }
}