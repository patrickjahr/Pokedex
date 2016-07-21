using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using PokeAPI;
using PokeAPI.Objects;
using PokeDex.Core.Services;
using PokeDex.Core.Utils;

namespace PokeDex.Core.Repositories
{
    public class PokemonRepositories : IPokemonRepositories
    {
        private readonly IPackageStorageService _packageStorageService;
        private readonly IResourceService _resourceService;
        private static readonly ObservableCollection<ImportPokemon> _pokmonCollection = new ObservableCollection<ImportPokemon>();

        public PokemonRepositories(IPackageStorageService packageStorageService, IResourceService resourceService)
        {
            _packageStorageService = packageStorageService;
            _resourceService = resourceService;
        }

        public async Task<ObservableCollection<ImportPokemon>> GetAllPokemon()
        {
            if (!_pokmonCollection.HasItems())
            {
                var jsonString = await _packageStorageService.GetStringAsync(new Uri("ms-appx:///Assets/pokemon.json"));
                if (jsonString.IsNeitherNullNorEmpty())
                {
                    try
                    {
                        var pokemon = JsonConvert.DeserializeObject<List<ImportPokemon>>(jsonString);
                        _pokmonCollection.AddRange(pokemon);
                    }
                    catch (Exception e)
                    {
                        Debug.WriteLine(e.Message);   
                    }
                    
                }
            }
            return _pokmonCollection;
        }

        public async Task<ObservableCollection<ImportPokemon>> SearchPokemon(string searchQuery)
        {
            var pokemon = (await GetAllPokemon());
            return pokemon.Where(item => item.Names.ContainsValue(searchQuery)).ToObservableCollection();
        }

        public async Task<Pokemon> GetPokemonById(int id)
        {
            return await DataFetcher.GetApiObject<Pokemon>(id);
        }
    }
}