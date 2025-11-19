using System.ComponentModel.DataAnnotations;

namespace Aplikacja_wspierajaca_rozwoj_dziecka.Models
{
    public class DzieckoUmiejetnosc
    {
        public int Id { get; set; }

        [Required]
        public int DzieckoId { get; set; }

        [Display(Name = "Dziecko")]
        public Dziecko? Dziecko { get; set; }

        [Required]
        public int UmiejetnoscId { get; set; }

        [Display(Name = "Umiejętność")]
        public Umiejetnosc? Umiejetnosc { get; set; }

        [Required]
        [Display(Name = "Status")]
        public StatusUmiejetnosci Status { get; set; } = StatusUmiejetnosci.NieRozpoczeto;

        [DataType(DataType.Date)]
        [Display(Name = "Data zmiany statusu")]
        public DateTime DataStatusu { get; set; } = DateTime.UtcNow;

        [MaxLength(500)]
        [Display(Name = "Komentarz")]
        public string? Komentarz { get; set; }
    }
}
