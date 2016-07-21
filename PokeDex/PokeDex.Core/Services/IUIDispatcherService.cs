using System;
using System.Threading.Tasks;

namespace PokeDex.Core.Services
{
    public interface IUIDispatcherService
    {
        /// <summary>
        /// Executes the specified action with the ability to await it.
        /// </summary>
        /// <param name="action">The action.</param>
        /// <returns></returns>
        Task RunAsync(Action action);

        Task RunAsync(Func<Task> funct);
        
    }
}
