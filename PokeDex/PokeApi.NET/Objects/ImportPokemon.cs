using System.Collections.Generic;

namespace PokeAPI.Objects
{
    public class ImportPokemon
    {
        public int Id { get; set; }
        public Dictionary<string, string> Names { get; set; }
        public string ImageUrl { get; set; }
        public Dictionary<string, string> Descriptions { get; set; }
        public List<string> Types { get; set; }

    }
}