namespace Calabonga.AspNetCore.Controllers.UpdateSteps
{
    /// <summary>
    /// On UpdateBeforeAnyValidations Step
    /// </summary>
    public class OnUpdateBeforeAnyValidationsStep: HandlerStep
    {
        /// <inheritdoc />
        public OnUpdateBeforeAnyValidationsStep(IHandlerContext context)
        {
            Context = context;
        }

        /// <inheritdoc />
        protected override int OrderIndex => 2;
    }
}