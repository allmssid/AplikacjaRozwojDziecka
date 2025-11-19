using System.ComponentModel.DataAnnotations;

namespace Aplikacja_wspierajaca_rozwoj_dziecka.Models
{
    public class Aktywnosc
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        [Display(Name = "Tytuł")]
        public string Tytul { get; set; }

        [MaxLength(2000)]
        [Display(Name = "Opis")]
        public string? Opis { get; set; }

        [Required]
        [Display(Name = "Kierunek rozwoju")]
        public ObszarRozwoju Kierunek { get; set; }

        [Display(Name = "Zalecany wiek od (lata)")]
        public int? ZalecanyWiekOdRoku { get; set; }

        [Display(Name = "Zalecany wiek do (lata)")]
        public int? ZalecanyWiekDoRoku { get; set; }

        [Display(Name = "Szacowany czas (minuty)")]
        public int? SzacowanyCzasMinuty { get; set; }

        public ICollection<DziennikAktywnosci> DziennikiAktywnosci { get; set; } = new List<DziennikAktywnosci>();
        public ICollection<Umiejetnosc> Umiejetnosci { get; set; } = new List<Umiejetnosc>();
    }
}
