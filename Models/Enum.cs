using System.ComponentModel.DataAnnotations;

namespace Aplikacja_wspierajaca_rozwoj_dziecka.Models
{
    public enum ObszarRozwoju
    {
        [Display(Name = "Matematyka poziom podstawowy")]
        Matematyka1 = 0,

        [Display(Name = "Matematyka poziom średniozaawansowany")]
        Matematyka2 = 1,

        [Display(Name = "Matematyka poziom zaawansowany")]
        Matematyka3 = 2,

        [Display(Name = "Matematyka poziom ekspercki")]
        Matematyka4 = 3,

        [Display(Name = "Język angielski poziom podstawowy")]
        Angielski1 = 4,

        [Display(Name = "Język angielski poziom średniozaawansowany")]
        Angielski2 = 5,

        [Display(Name = "Język angielski poziom zaawansowany")]
        Angielski3 = 6,

        [Display(Name = "Język angielski poziom ekspercki")]
        Angielski4 = 7
    }

    public enum StatusUmiejetnosci
    {
        [Display(Name = "Nie rozpoczęto")]
        NieRozpoczeto = 0,

        [Display(Name = "W trakcie")]
        WTrakcie = 1,

        [Display(Name = "Osiągnięto")]
        Osiagnieto = 2,

        [Display(Name = "Regres")]
        Regres = 3
    }
}
