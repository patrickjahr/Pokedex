using LitJson;

namespace PokeAPI
{
    public class PokemonShape : NamedApiObject
    {
        public PokemonShape()
        {
            AwesomeNames = null;
            Names = null;
            Species = null;
        }

        [JsonPropertyName("awesome_names")]
        public AwesomeName[] AwesomeNames
        {
            get;
            internal set;
        }

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