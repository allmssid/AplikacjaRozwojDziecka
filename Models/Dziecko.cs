using System.ComponentModel.DataAnnotations;

namespace Aplikacja_wspierajaca_rozwoj_dziecka.Models
{
    public class Dziecko
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        [Display(Name = "Imię")]
        public string Imie { get; set; }

        [MaxLength(50)]
        [Display(Name = "Nazwisko")]
        public string? Nazwisko { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Data urodzenia")]
        public DateTime DataUrodzenia { get; set; }

        [MaxLength(500)]
        [Display(Name = "Notatki")]
        public string? Notatki { get; set; }

        // Relacje
        public ICollection<DzieckoUmiejetnosc> UmiejetnosciDziecka { get; set; } = new List<DzieckoUmiejetnosc>();
        public ICollection<DziennikAktywnosci> DziennikiAktywnosci { get; set; } = new List<DziennikAktywnosci>();
    }
}
