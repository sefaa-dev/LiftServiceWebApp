using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LiftServiceWebApp.ViewModels
{
    public class UserProfileViewModel
    {
        [Required(ErrorMessage = "Ad alanı gereklidir.")]
        [Display(Name = "Ad")]
        [StringLength(50)]
        public string Name { get; set; }
        [Required(ErrorMessage = "Soyad alanı gereklidir.")]
        [Display(Name = "Soyad")]
        [StringLength(50)]
        public string Surname { get; set; }
        [Required(ErrorMessage = "E-Posta alanı gereklidir.")]
        [EmailAddress]
        public string Email { get; set; }
    }
}