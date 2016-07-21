using LitJson;

namespace PokeAPI
{
    public class PokemonHabitat : NamedApiObject
    {
        public ResourceName[] Names
        {
            get;
            internal set;
        }

        [JsonPropertyName("pokemon_species")]
        public NamedApiResource<PokemonSpecies>[] Species
        {
            get;
            internal set;
        }
    }
}