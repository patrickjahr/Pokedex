using System.Linq;
using LitJson;

namespace PokeAPI
{
    public class PokemonType : NamedApiObject
    {
        [JsonPropertyName("damage_relations")]
        public TypeRelations DamageRelations
        {
            get;
            internal set;
        }

        [JsonPropertyName("game_indices")]
        public GenerationGameIndex[] GameIndices
        {
            get;
            internal set;
        }

        public NamedApiResource<Generation> Generation
        {
            get;
            internal set;
        }

        [JsonPropertyName("move_damage_class")]
        public NamedApiResource<MoveDamageClass> MoveDamageClass
        {
            get;
            internal set;
        }

        public ResourceName[] Names
        {
            get;
            internal set;
        }

        public TypePokemon[] Pokemon
        {
            get;
            internal set;
        }

        public NamedApiResource<Move>[] Moves
        {
            get;
            internal set;
        }

        public static double CalculateDamageMultiplier(PokemonType attackingType, PokemonType defendingType)
        {
            var ad = attackingType.DamageRelations;

            if (ad.NoDamageTo    .Any(t => t.Name == defendingType.Name))
                return 0d;
            if (ad.HalfDamageTo  .Any(t => t.Name == defendingType.Name))
                return 0.5d;
            if (ad.DoubleDamageTo.Any(t => t.Name == defendingType.Name))
                return 2.0d;

            return 1d;
        }
        public static double CalculateDamageMultiplier(PokemonType attackingType, PokemonType defendingA, PokemonType defendingB)
        {
            return CalculateDamageMultiplier(attackingType, defendingA)
                   * CalculateDamageMultiplier(attackingType, defendingB);
        }
    }
}