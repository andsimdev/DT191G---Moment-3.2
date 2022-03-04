using System.ComponentModel.DataAnnotations;

namespace DT191G___Moment_3._2.Models
{
    public class Borrow
    {
        // ID
        public int BorrowId { get; set; }

        // ANVÄNDARENS ID
        [Required]
        [Display(Name = "Användare")]
        public int UserId { get; set; }

        // SKIVANS ID
        [Required]
        [Display(Name = "CD-skiva")]
        public int CdId { get; set; }

        // UTLÅNINGSDATUM
        [Required(ErrorMessage = "Ange utlåningsdatum")]
        [Display(Name ="Utlåningsdatum")]
        public DateTime BorrowDate { get; set; }

        [Display(Name = "Användare")]
        public User? User { get; set; }

        [Display(Name = "Lånad CD-skiva")]
        public Cd? Cd { get; set; }
    }
}