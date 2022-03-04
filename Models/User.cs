using System.ComponentModel.DataAnnotations;

namespace DT191G___Moment_3._2.Models
{
    public class User
    {
        // ID
        public int UserId { get; set; }

        // ANVÄNDARNAMN
        [Required(ErrorMessage = "Ange ett användarnamn")]
        [Display(Name = "Användarnamn")]
        public string? UserName { get; set; }

        // REGISTRERINGSDATUM
        [Display(Name = "Registreringsdatum")]
        public DateTime RegTime { get; set; } = DateTime.Now;

        // LÅN
        [Display(Name = "Användarens Lån")]
        public List<Borrow>? Borrows { get; set; }
    }
}
