

namespace Calabonga.AspNetCore.Controllers.CreateSteps
{
    /// <summary>
    /// Step for Create pipeline 2
    /// </summary>
    public class OnCreateBeforeAnyValidationsStep: HandlerStep
        
    {
        /// <inheritdoc />
        public OnCreateBeforeAnyValidationsStep(IHandlerContext context)
        {
            Context = context;
        }

        /// <inheritdoc />
        protected override int OrderIndex => 2;
    }
}