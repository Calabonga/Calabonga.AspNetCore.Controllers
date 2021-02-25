using System;
using System.Threading.Tasks;

namespace Calabonga.AspNetCore.Controllers.Extensions
{
    public static class TaskExtensions
    {
        /// <summary>
        /// Safely execute the task without waiting for it to complete before moving to the next line of code
        /// </summary>
        /// <param name="source"></param>
        /// <param name="continueOnCapturedContext"></param>
        /// <param name="onException"></param>
        public static async void SafeFireAndForget(this Task source, bool continueOnCapturedContext = true, Action<Exception> onException = null)
        {
            try
            {
                await source.ConfigureAwait(continueOnCapturedContext);
            }
            catch (Exception exception)
            {
                onException?.Invoke(exception);
            }
        }
    }
}
