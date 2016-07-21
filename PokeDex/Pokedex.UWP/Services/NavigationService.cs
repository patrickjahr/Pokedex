using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows.Input;
using Windows.UI.Xaml.Controls;
using GalaSoft.MvvmLight.Command;
using PokeDex.Core.Services;

namespace PokeDex.UwpApp.Services
{
    public class NavigationService : INavigationService
    {
        private static Frame _rootFrame;
        private static volatile bool _initialized;

        public bool CanGoBack => _rootFrame != null && _rootFrame.CanGoBack;

        public ICommand GoBackCommand { get; private set; }

        public NavigationService(Dictionary<string, Type> availablePages)
        {
            if (availablePages == null) throw new ArgumentNullException(nameof(availablePages));

            GoBackCommand = new RelayCommand(GoBack);
            _availablePages = availablePages;
        }

        private readonly Dictionary<string, Type> _availablePages;
        private readonly ICustomSerializerService _serializer;

        public void Initialize(object rootFrame)
        {
            _initialized = true;
            _rootFrame = rootFrame as Frame;
        }

        public void Navigate(string targetPage, object parameter = null, int removeFromBackStackCount = 0)
        {
            try
            {
                if (!_initialized)
                {
                    Debug.WriteLine("NavigationService.cs | Navigate | NOT INITIALIZED YET");
                    return;
                }

                if (_rootFrame.SourcePageType != null && _rootFrame.SourcePageType.Name == targetPage)
                    return; //don't navigate to the actual page again

                var targetPageType = _availablePages[targetPage];

                if (_rootFrame.CurrentSourcePageType != targetPageType)
                {
                    //frame is not able to serializer complex objects (issue: https://social.msdn.microsoft.com/Forums/en-US/3e24c556-3758-40d0-bd03-55e193538340/getnavigationstate-doesnt-support-serialization-of-a-parameter-type-which-was-passed-to?forum=winappswithcsharp)
                    if (parameter == null)
                    {
                        _rootFrame.Navigate(targetPageType);
                    }
                }

                if (removeFromBackStackCount > 0)
                    RemoveBackEntries(removeFromBackStackCount);
            }
            catch (Exception e)
            {
                Debug.WriteLine("NavigationService.cs | Navigate | " + e);
                throw;
            }
        }

        public void GoBack()
        {
            try
            {
                if (_rootFrame == null)
                {
                    Debug.WriteLine("NavigationService.cs | GoBack | Please initialize rootframe");
                    return;
                }

                if (_rootFrame.CanGoBack)
                    _rootFrame.GoBack();
            }
            catch (Exception e)
            {
                Debug.WriteLine("NavigationService.cs | GoBack | " + e);
                throw;
            }
        }

        public void ClearBackStack()
        {
            if (_rootFrame != null)
            {
                while (_rootFrame.BackStackDepth > 0)
                {
                    _rootFrame.BackStack.RemoveAt(0);
                }
            }
        }

        /// <summary>
        /// Removes the last 'count' entries from the back stack.
        /// </summary>
        /// <param name="count">Count of entries to remove.</param>
        public void RemoveBackEntries(int count)
        {
            if (count <= _rootFrame?.BackStackDepth)
            {
                while (count > 0)
                {
                    _rootFrame.BackStack.RemoveAt(_rootFrame.BackStackDepth - 1);
                    count--;
                }
            }
        }

        /// <summary>
        /// Removes a single back entries from the frame's back stack.
        /// </summary>
        public void RemoveBackEntry()
        {
            RemoveBackEntries(1);
        }

        public string GetActualPageName()
        {
            if (_rootFrame.SourcePageType != null)
                return _rootFrame.SourcePageType.Name;

            return "No Page in RootFrame";
        }

      
    }
}
