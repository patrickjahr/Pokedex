using LitJson;

namespace PokeAPI
{
    public class PokemonForm : NamedApiObject
    {
        public int Order
        {
            get;
            internal set;
        }

        [JsonPropertyName("form_order")]
        public int FormOrder
        {
            get;
            internal set;
        }

        /// <summary>
        /// NOTE: some props can be null, fall back on male, non-shiny (if all shinies are null) values!
        /// </summary>
        public PokemonSprites Sprites
        {
            get;
            internal set;
        }

        [JsonPropertyName("is_default")]
        public bool IsDefault
        {
            get;
            internal set;
        }
        [JsonPropertyName("is_battle_only")]
        public bool IsBattleOnly
        {
            get;
            internal set;
        }
        [JsonPropertyName("is_mega")]
        public bool IsMegaEvolution
        {
            get;
            internal set;
        }

        [JsonPropertyName("form_names")]
        public string[] FormNames
        {
            get;
            internal set;
        }

        [JsonPropertyName("form_name")]
        public string FormName
        {
            get;
            internal set;
        }
        public ResourceName[] Names
        {
            get;
            internal set;
        }

        public NamedApiResource<Pokemon> Pokemon
        {
            get;
            internal set;
        }

        [JsonPropertyName("version_group")]
        public NamedApiResource<VersionGroup> VersionGroup
        {
            get;
            internal set;
        }
    }
}