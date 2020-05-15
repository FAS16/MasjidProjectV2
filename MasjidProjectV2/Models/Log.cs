using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MasjidProjectV2.Models
{
    public class Log
    {
        public int Id { get; set; }

        public ApplicationUser ApplicationUser { get; set; }

        [Required]
        public string ApplicationUserId { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public DateTime Timestamp { get; set; }

        [Required]
        public LogAction LogAction { get; set; }




    }
}