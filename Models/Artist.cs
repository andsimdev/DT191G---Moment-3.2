using System.ComponentModel.DataAnnotations;

namespace DT191G___Moment_3._2.Models
{
    public class Artist
    {
        // ID
        public int ArtistId { get; set; }

        // NAMN
        [Required(ErrorMessage = "Ange ett artistnamn")]
        [Display(Name = "Artistnamn")]
        public string ArtistName { get; set; }

        public List<Cd>? Cds { get; set; }
    }
}
