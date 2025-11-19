using System.ComponentModel.DataAnnotations;

namespace Aplikacja_wspierajaca_rozwoj_dziecka.Models
{
    public class DziennikAktywnosci
    {
        public int Id { get; set; }

        [Required]
        public int DzieckoId { get; set; }

        [Display(Name = "Dziecko")]
        public Dziecko? Dziecko { get; set; }

        [Required]
        public int AktywnoscId { get; set; }

        [Display(Name = "Aktywność")]
        public Aktywnosc? Aktywnosc { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Data")]
        public DateTime Data { get; set; } = DateTime.Today;

        [Display(Name = "Czas trwania (minuty)")]
        public int? CzasTrwaniaMinuty { get; set; }

        [Range(1, 5)]
        [Display(Name = "Reakcja dziecka (1–5)")]
        public int? OcenaReakcjiDziecka { get; set; }

        [MaxLength(1000)]
        [Display(Name = "Notatki")]
        public string? Notatki { get; set; }
    }
}
