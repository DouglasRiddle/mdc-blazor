using System;
using System.Threading;
using System.Threading.Tasks;

namespace SsExample.Code
{
    public class DebounceHelper
    {
        private CancellationTokenSource debounceToken = null;

        /// <summary>
        /// Debounce the passed method so that it only executes once x milliseconds have passed without it being called
        /// </summary>
        /// <param name="func">The <see cref="Func{TResult}"/> method to debounce</param>
        /// <param name="milliseconds">An <see cref="int"/> value representing the milliseconds to wait before running the method</param>
        /// <returns>
        /// Returns a cancellation token that can be passed to the called method
        /// </returns>
        /// <example>
        /// <code>
        /// DebounceHelper debouncer = new DebounceHelper();
        /// 
        /// private async Task SomeMethod(CancellationToken token) { ... your code here... }
        /// 
        /// public async Task OnSearch()
        /// {
        ///     debouncer.Debounce(async (cancellationToken) => await SomeMethod(cancellationToken), 1000);
        /// }
        /// </code>
        /// </example>
        public async Task DebounceAsync(Func<CancellationToken, Task> func, int milliseconds = 300)
        {
            try
            {
                // Cancel previous task
                if (debounceToken != null) { debounceToken.Cancel(); }

                // Assign new token
                debounceToken = new CancellationTokenSource();

                // Debounce delay
                await Task.Delay(milliseconds, debounceToken.Token);

                // Throw if canceled
                debounceToken.Token.ThrowIfCancellationRequested();

                // Run function
                await func(debounceToken.Token);
            }
            catch (TaskCanceledException) { }
        }
    }
}
