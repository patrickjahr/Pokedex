using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using GalaSoft.MvvmLight.Ioc;
using GalaSoft.MvvmLight.Views;
using PokeDex.Core.Common;
using PokeDex.Core.ViewModel;
using PokeDex.UwpApp.Views;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace PokeDex.UwpApp
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private readonly Core.Services.INavigationService _navService;
        public MainPage()
        {
            this.InitializeComponent();
            _navService = SimpleIoc.Default.GetInstance<Core.Services.INavigationService>();
        }

        private void PokemonButton_OnClick(object sender, RoutedEventArgs e)
        {
            _navService.Navigate(NavigationTarget.POKEMON_OVERVIEW_PAGE);
        }
    }
}
