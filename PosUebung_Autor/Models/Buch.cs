using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace PosUebung_Autor.Models
{
    public class Buch
    {
        public int Id { get; set; }
        [MaxLength(100, ErrorMessage = "Maximum length is 100 characters!"), MinLength(5, ErrorMessage = "Mininum length is 5 characters!")]
        public string Title { get; set; }
        public List<string> Genres { get; set; }
        [Range(1, 1000)]
        public int Pages { get; set; }
        [Range(1, 5)]
        public int Stars { get; set; }

        //Fremdschlüssel
        public Autor? Autor { get; set; }
        public int? AutorId { get; set; }

        public override string ToString()
        {
            return $"{Title} {Autor?.Name} {Pages} {Stars}";
        }
    }
}
