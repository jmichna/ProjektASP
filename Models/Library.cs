using Data.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;
using ProjektASP.Models;
using System.ComponentModel.DataAnnotations;

namespace ProjektASP.Models
{

    public enum Rating
    {
        [Display(Name = "1/4")] Low = 1,
        [Display(Name = "2/4")] Medium = 2,
        [Display(Name = "3/4")] High = 3,
        [Display(Name = "4/4")] VeryHigh = 4
    }

    public class Library
    {
        [HiddenInput]
        public int Id { get; set; }

        [Required(ErrorMessage ="Proszę podać tytuł książki!")]
        public string Title { get; set; }

        [Required(ErrorMessage ="Proszę podać imię i nazwisko autora!")]
        public string Autor { get; set; }

        [Required(ErrorMessage ="Proszę podać ilość stron!")]
        public int PageNumber { get; set; }

        [StringLength(17, MinimumLength = 17)]
        [Required(ErrorMessage ="Proszę podać ISBN")]
        public string ISBN { get; set; }

        [Required(ErrorMessage ="Proszę podać datę wydania książki!")]
        public DateTime DateOfRelease { get; set; }

        [HiddenInput]
        public int PublishingHouseId {  get; set; }

        [ValidateNever]
        public PublishingHouseEntity? PublishingHouse { get; set; }

        [Display(Name ="Ocena")]
        [Required(ErrorMessage ="Proszę wybrać ocenę!")]
        public int Rating { get; set; }
    }
}
