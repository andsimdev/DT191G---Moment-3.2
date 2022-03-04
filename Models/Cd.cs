using System.ComponentModel.DataAnnotations;

namespace DT191G___Moment_3._2.Models
{
    public class Cd
    {
        // ID
        public int CdId { get; set; }

        // NAMN
        [Required(ErrorMessage = "Ange CD-skivans namn")]
        [Display(Name = "Skivans namn")]
        public string? CdName { get; set; }

        // REGISTRERINGSDATUM
        [Display(Name = "Registrerad")]
        public DateTime DateTime { get; set; } = DateTime.Now;

        // ARTIST ID
        [Required]
        [Display(Name = "Artist")]
        public int ArtistId { get; set; }

        public Artist? Artist { get; set; }

        public Borrow? Borrow { get; set; }
    }
}