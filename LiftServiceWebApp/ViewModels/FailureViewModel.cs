using LiftServiceWebApp.Models.Entities;
using System.ComponentModel.DataAnnotations;

namespace LiftServiceWebApp.ViewModels
{
    public class FailureViewModel
    {
        [Required(ErrorMessage = "Arıza alanı boş geçilemez.")]
        [Display(Name = "Arıza")]
        [StringLength(70)]
        public string FailureName { get; set; }

        [Required(ErrorMessage = "Arıza tanımı boş geçilemez.")]
        [Display(Name = "Arıza Tanım")]
        [StringLength(100)]
        public string FailureDescription { get; set; }

        public FailureStates FailureState { get; set; }
        public string Latitude { get; set; }//Enlem
        public string Longitude { get; set; }//Boylam

        [Required(ErrorMessage = "Arıza adres detay bilgileri boş geçilemez.")]
        [Display(Name = "Arıza Adres Detay")]
        [StringLength(70)]
        public string AddressDetail { get; set; }
        
    }
}
