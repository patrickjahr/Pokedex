using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Ioc;
using Newtonsoft.Json;
using PokeAPI;
using PokeAPI.Objects;
using PokeDex.Core.Common;
using PokeDex.Core.Repositories;
using PokeDex.Core.Services;
using PokeDex.Core.Utils;

namespace PokeDex.Core.ViewModel
{
    public class PokemonOverviewViewModel : ViewModelBase
    {
        private readonly IPokemonRepositories _pokmePokemonRepositories;
        private readonly INavigationService _navigationService;
        private readonly IPackageStorageService _packageStorageService;
        private ObservableCollection<ImportPokemon> _pokemonCollection;
        public ObservableCollection<ImportPokemon> PokemonCollection
        {
            get { return _pokemonCollection ?? (_pokemonCollection = new ObservableCollection<ImportPokemon>()); }
            set { _pokemonCollection = value; RaisePropertyChanged(); }
        }

        private string _searchQuery;
        public string SearchQuery
        {
            get { return _searchQuery; }
            set { _searchQuery = value; RaisePropertyChanged(); }
        }

        private bool _isLoading;
        public bool IsLoading
        {
            get { return _isLoading; }
            set { _isLoading = value; RaisePropertyChanged(); }
        }

        public RelayCommand InitCommand { get; private set; }
        public RelayCommand SearchCommand { get; private set; }
        public RelayCommand<int> NavigateToDetailPageCommand { get; private set; }

        public PokemonOverviewViewModel(IPokemonRepositories pokmePokemonRepositories, INavigationService navigationService)
        {
            _pokmePokemonRepositories = pokmePokemonRepositories;
            _navigationService = navigationService;
            InitCommand = new RelayCommand(Init);
            SearchCommand = new RelayCommand(Search);
            NavigateToDetailPageCommand = new RelayCommand<int>(NavigateToDetailPage);
        }

        private void NavigateToDetailPage(int pokeId)
        {
            var detailVm = SimpleIoc.Default.GetInstance<PokemonDetailViewModel>();
            detailVm.InitCommand.Execute(pokeId);
            _navigationService.Navigate(NavigationTarget.POKEMON_DETAIL_PAGE);
        }

        private async void Search()
        {
            IsLoading = true;
            if (SearchQuery.IsNeitherNullNorEmpty())
            {
                PokemonCollection = await _pokmePokemonRepositories.SearchPokemon(SearchQuery);
            }
            else
            {
                PokemonCollection = await _pokmePokemonRepositories.GetAllPokemon();
            }
            IsLoading = false;
        }

        private async void Init()
        {
            IsLoading = true;
            PokemonCollection = await _pokmePokemonRepositories.GetAllPokemon();
            IsLoading = false;
        }
    }
}