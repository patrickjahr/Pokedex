using System.Collections.ObjectModel;
using System.Threading.Tasks;
using PokeAPI;
using PokeAPI.Objects;

namespace PokeDex.Core.Repositories
{
    public interface IPokemonRepositories
    {
        Task<ObservableCollection<ImportPokemon>> GetAllPokemon();
        Task<ObservableCollection<ImportPokemon>> SearchPokemon(string searchQuery);
        Task<Pokemon> GetPokemonById(int id);

    }
}