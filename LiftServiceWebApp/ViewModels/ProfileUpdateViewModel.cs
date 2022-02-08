using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LiftServiceWebApp.ViewModels
{
    public class ProfileUpdateViewModel
    {
        public UserProfileViewModel UserProfileViewModel { get; set; } = new();
        public PasswordUpdateViewModel PasswordUpdateViewModel { get; set; } = new();
    }
}
