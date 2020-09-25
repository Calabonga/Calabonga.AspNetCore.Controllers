namespace Calabonga.AspNetCore.Controllers
{
    /// <summary>
    /// Marker for empty step
    /// </summary>
    public class EmptyStep : HandlerStep
    {
        /// <summary>
        /// Pipeline operation executing order index
        /// </summary>
        protected override int OrderIndex => -1;
    }
}