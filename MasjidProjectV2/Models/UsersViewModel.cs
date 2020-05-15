using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MasjidProjectV2.Models
{
    public class UsersViewModel
    {
        public List<ApplicationUser> Users { get; set; }


        public int CalculateAge(ApplicationUser user)
        {
            // Save today's date.
            var today = DateTime.Today;
            // Calculate the age.
            var age = today.Year - user.DateOfBirth.Year;
            // Go back to the year the person was born in case of a leap year
            //            if (user.DateOfBirth.Date > today.AddYears(-age)) age--;
            if (DateTime.Now.DayOfYear < user.DateOfBirth.DayOfYear)
            {
                age -= 1;
            }

            return age;
        }

        public UsersViewModel()
        {
            
        }
    }
}