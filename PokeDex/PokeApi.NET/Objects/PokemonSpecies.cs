using LitJson;

namespace PokeAPI
{
    public class PokemonSpecies : NamedApiObject
    {
        public int Order
        {
            get;
            internal set;
        }

        [JsonPropertyName("gender_rate"), JsonConverter(typeof(PokemonSpeciesGender.GenderConverter))]
        public float? FemaleToMaleRate
        {
            get;
            internal set;
        }
        [JsonPropertyName("capture_rate")]
        public float CaptureRate
        {
            get;
            internal set;
        }

        [JsonPropertyName("base_happiness")]
        public int BaseHappiness
        {
            get;
            internal set;
        }

        [JsonPropertyName("is_baby")]
        public bool IsBaby
        {
            get;
            internal set;
        }

        [JsonPropertyName("hatch_counter")]
        public int HatchCounter
        {
            get;
            internal set;
        }

        [JsonPropertyName("has_gender_differences")]
        public bool HasGenderDifferences
        {
            get;
            internal set;
        }

        [JsonPropertyName("forms_switchable")]
        public bool FormsAreSwitchable
        {
            get;
            internal set;
        }

        [JsonPropertyName("growth_rate")]
        public NamedApiResource<GrowthRate> GrowthRate
        {
            get;
            internal set;
        }

        [JsonPropertyName("pokedex_numbers")]
        public PokemonSpeciesDexEntry[] PokedexNumbers
        {
            get;
            internal set;
        }

        [JsonPropertyName("egg_groups")]
        public NamedApiResource<EggGroup>[] EggGroups
        {
            get;
            internal set;
        }

        [JsonPropertyName("color")]
        public NamedApiResource<PokemonColour> Colours
        {
            get;
            internal set;
        }
        public NamedApiResource<PokemonShape> Shape
        {
            get;
            internal set;
        }
        [JsonPropertyName("evolves_from_species")]
        public NamedApiResource<PokemonSpecies> EvolvesFromSpecies
        {
            get;
            internal set;
        }
        [JsonPropertyName("evolution_chain")]
        public ApiResource<EvolutionChain> EvolutionChain
        {
            get;
            internal set;
        }
        public NamedApiResource<PokemonHabitat> Habitat
        {
            get;
            internal set;
        }
        public NamedApiResource<Generation> Generation
        {
            get;
            internal set;
        }

        public ResourceName[] Names
        {
            get;
            internal set;
        }

        [JsonPropertyName("pal_park_encounters")]
        public PalParkEncounterArea[] PalParkEncounters
        {
            get;
            internal set;
        }

        [JsonPropertyName("form_descriptions")]
        public Description[] Descriptions
        {
            get;
            internal set;
        }

        public Genus[] Genera
        {
            get;
            internal set;
        }

        public PokemonSpeciesVariety[] Varieties
        {
            get;
            internal set;
        }

        [JsonPropertyName("flavor_text_entries")]
        public PokemonSpeciesFlavorText[] FlavorTexts
        {
            get;
            internal set;
        }
    }
}