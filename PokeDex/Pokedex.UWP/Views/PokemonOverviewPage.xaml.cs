using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using PokeDex.Core.ViewModel;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace Pokedex.UWP.Views
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
    }
}
