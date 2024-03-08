using System.Text.Json.Serialization;

namespace PosUebung_Autor.Models
{
    public class Autor
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Age { get; set; }

        [JsonIgnore]
        public List<Buch> Books { get; set; } = new List<Buch>();
    }
}
