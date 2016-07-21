using LitJson;

namespace PokeAPI
{
    public class Stat : NamedApiObject
    {
        [JsonPropertyName("game_index")]
        public int GameIndex
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

        [JsonPropertyName("affecting_moves")]
        public StatAffectSets<Move> AffectingMoves
        {
            get;
            internal set;
        }
        [JsonPropertyName("affecting_natures")]
        public StatAffectNature AffectingNatures
        {
            get;
            internal set;
        }

        public ApiResource<Characteristic>[] Characteristics
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
    }
}