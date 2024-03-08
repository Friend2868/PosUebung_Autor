using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace PosUebung_Autor.Models
{
    public class Autor
    {
        public int Id { get; set; }
        [MaxLength(50, ErrorMessage = "The name can have 50 characters!")]
        public string Name { get; set; }
        [MaxLength(255, ErrorMessage = "The description can have 255 characters!")]
        public string Description { get; set; }
        [Range(18, 150, ErrorMessage = "Age must be between 18 and 150!")]
        public int Age { get; set; }

        [JsonIgnore]
        public List<Buch> Books { get; set; } = new List<Buch>();
    }
}
