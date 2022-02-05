using System.Collections.Generic;

namespace LiftServiceWebApp.Models
{
    public static class RoleNames
    {
        public static string Admin = "Admin";
        public static string User = "User";
        public static string Operator = "Operator";
        public static string Technician = "Technician";

        public static List<string> Roles => new List<string>() { Admin, User, Operator, Technician };
    }
}
