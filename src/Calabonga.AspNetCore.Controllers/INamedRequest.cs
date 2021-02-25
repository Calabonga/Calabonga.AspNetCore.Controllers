namespace Calabonga.AspNetCore.Controllers
{
    /// <summary>
    /// Named request interface for logging
    /// </summary>
    public interface INamedRequest
    {
        string RequestName { get; }
    }
}