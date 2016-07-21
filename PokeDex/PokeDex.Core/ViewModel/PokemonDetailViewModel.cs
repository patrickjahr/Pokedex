using System.Collections.Generic;
using System.Collections.ObjectModel;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using PokeAPI;
using PokeDex.Core.Utils;

namespace PokeDex.Core.ViewModel
{
    public class PokemonDetailViewModel : ViewModelBase
    {
        private Pokemon _currentPokemon;
        public Pokemon CurrentPokemon
        {
            get { return _currentPokemon; }
            set { _currentPokemon = value; RaisePropertyChanged(); }
        }

        private ObservableCollection<KeyValuePair<PokemonStats,Stat>> _baseStats;
        public ObservableCollection<KeyValuePair<PokemonStats, Stat>> BaseStats
        {
            get { return _baseStats ?? (_baseStats = new ObservableCollection<KeyValuePair<PokemonStats, Stat>>()); }
            set { _baseStats = value; RaisePropertyChanged(); }
        }
        
        private bool _isLoading;
        public bool IsLoading
        {
            get { return _isLoading; }
            set { _isLoading = value; RaisePropertyChanged(); }
        }

        public RelayCommand<int> InitCommand { get; private set; }

        public PokemonDetailViewModel()
        {
            InitCommand = new RelayCommand<int>(InitAsync);
        }

        private async void InitAsync(int id)
        {
            IsLoading = true;
            CurrentPokemon = await DataFetcher.GetApiObject<Pokemon>(id);
            if (CurrentPokemon != null)
            {
                BaseStats.Clear();
                CurrentPokemon.Stats.ForEach(async item =>
                {
                    var stat = await DataFetcher.GetApiObject<Stat>(item.Stat.Url);
                    BaseStats.Add(new KeyValuePair<PokemonStats, Stat>(item, stat));
                });
            }
            IsLoading = false;
        }
    }
}