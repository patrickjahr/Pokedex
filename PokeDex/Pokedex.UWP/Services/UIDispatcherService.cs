using System;
using System.Threading.Tasks;
using Windows.UI.Core;
using Windows.UI.Xaml;
using PokeDex.Core.Services;

namespace Pokedex.UWP.Services
{
    public class UIDispatcherService : IUIDispatcherService
    {
        private CoreDispatcher _dispatcher;

        public IUIDispatcherService Initialize(CoreDispatcher dispatcher = null)
        {
            _dispatcher = dispatcher ?? Window.Current.Dispatcher;
            return this;
        }

        public async Task RunAsync(Action action)
        {
            if (_dispatcher.HasThreadAccess)
            {
                action();
            }
            else
            {
                TaskCompletionSource<bool> completionSource = new TaskCompletionSource<bool>();
                await _dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
                {
                    action();
                    completionSource.TrySetResult(true);
                });
                await completionSource.Task;
            }
        }


        public async Task RunAsync(Func<Task> funct)
        {
            if (_dispatcher.HasThreadAccess)
            {
                await funct();
            }
            else
            {
                TaskCompletionSource<bool> completionSource = new TaskCompletionSource<bool>();
                await _dispatcher.RunAsync(CoreDispatcherPriority.Normal, async () =>
                {
                    await funct();
                    completionSource.TrySetResult(true);
                });
                await completionSource.Task;
            }
        }

    }
}
