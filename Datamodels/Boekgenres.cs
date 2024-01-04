using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Drawing;
using System;
using System.Xml.Linq;

namespace Bibliotheek.Datamodels;

public enum Boekgenres
{
    [Display(Name = "None")] None = 0,
    [Display(Name = "Roman")] Roman = 1,
    [Display(Name = "Thriller")] Thriller = 2,
    [Display(Name = "ScienceFiction")] ScienceFiction = 3,
    [Display(Name = "Biografie")] Biografie = 4
}