using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
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
using PokeAPI.Objects;
using PokeDex.Core.Services;
using PokeDex.Core.ViewModel;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace PokeDex.UwpApp.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class PokemonOverviewPage : Page
    {
        private readonly PokemonOverviewViewModel _vm;

        public PokemonOverviewPage()
        {
            this.InitializeComponent();
            _vm = (PokemonOverviewViewModel)DataContext;
        }

        private void PokemonOverviewControl_OnLoaded(object sender, RoutedEventArgs e)
        {
            _vm.InitCommand.Execute(null);
        }

        private void SearchBox_OnQueryChanged(SearchBox sender, SearchBoxQueryChangedEventArgs args)
        {
            _vm.SearchCommand.Execute(null);
        }

        private void BackButton_OnClick(object sender, RoutedEventArgs e)
        {
            var navService = SimpleIoc.Default.GetInstance<INavigationService>();
            if (navService.CanGoBack)
            {
                navService.GoBack();
            }
        }

        private void PokemonItem_OnClick(object sender, ItemClickEventArgs e)
        {
            var currentPokemon = e.ClickedItem as ImportPokemon;
            if(currentPokemon != null)
                _vm.NavigateToDetailPageCommand.Execute(currentPokemon.Id);
        }
    }
}
