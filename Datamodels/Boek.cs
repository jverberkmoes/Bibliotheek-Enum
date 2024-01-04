using Humanizer;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.ComponentModel.DataAnnotations;

namespace Bibliotheek.Datamodels
{
    public class Boek
    {
        [Key]
        public int Boek_ID { get; set; }
        [Display(Name = "Genre")]
        public Boekgenres Boek_Genre { get; set; }
        [Display(Name = "Titel")]
        public string? Boek_Titel { get; set; }
        [Display(Name = "Serienummer")]
        public int Boek_Serienummer { get; set; }
        [Display(Name = "Schrijver")]
        public string? Boek_Schrijver { get; set; }
         [Display(Name = "Prijs")]
        public decimal Boek_Prijs { get; set; }
        [Display(Name = "ISBN")]
        public string? Boek_ISBN { get; set; }
        [Display(Name = "Uitgifte")]
        public DateTime Boek_Uitgifte { get; set; }
        [Display(Name = "Gelezen")]
        public DateTime Boek_Gelezen { get; set; }
    }
}
