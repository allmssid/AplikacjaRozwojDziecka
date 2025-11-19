using System.ComponentModel.DataAnnotations;

namespace Aplikacja_wspierajaca_rozwoj_dziecka.Models
{
    public class Umiejetnosc
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        [Display(Name = "Nazwa umiejętności")]
        public string Nazwa { get; set; }

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

        [Display(Name = "Czy własna (użytkownika)")]
        public bool CzyWlasna { get; set; } = false;

        // Relacje
        public ICollection<DzieckoUmiejetnosc> UmiejetnosciDzieci { get; set; } = new List<DzieckoUmiejetnosc>();
        public ICollection<Aktywnosc> Aktywnosci { get; set; } = new List<Aktywnosc>();
    }
}
