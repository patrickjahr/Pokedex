using System;
using System.Collections.Generic;
using LitJson;

namespace PokeAPI
{
    public class Pokemon : NamedApiObject
    {
        [JsonPropertyName("base_experience")]
        public int BaseExperience
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

        public int Height
        {
            get;
            internal set;
        }
        [JsonPropertyName("weight")]
        public int Mass
        {
            get;
            internal set;
        }

        public int Order
        {
            get;
            internal set;
        }

        public PokemonAbility[] Abilities
        {
            get;
            internal set;
        }

        public NamedApiResource<PokemonForm>[] Forms
        {
            get;
            internal set;
        }

        [JsonPropertyName("game_indices")]
        public VersionGameIndex[] GameIndices
        {
            get;
            internal set;
        }

        [JsonPropertyName("held_items")]
        public PokemonHeldItem[] HeldItems
        {
            get;
            internal set;
        }

        [JsonPropertyName("location_area_encounters"), JsonConverter(typeof(StructResourceFromStringConverter<LocationAreaEncounter[]>))]
        public StructResource<LocationAreaEncounter[]> LocationAreaEncounters
        {
            get;
            internal set;
        }

        public PokemonMove[] Moves
        {
            get;
            internal set;
        }

        public NamedApiResource<PokemonSpecies> Species
        {
            get;
            internal set;
        }

        public PokemonStats[] Stats
        {
            get;
            internal set;
        }

        public PokemonTypeMap[] Types
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
    }
}
