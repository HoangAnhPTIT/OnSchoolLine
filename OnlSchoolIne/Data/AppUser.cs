using Microsoft.AspNetCore.Identity;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlSchoolIne.Data
{
    [Table("IdentityUser")]
    public class AppUser : IdentityUser
    {
        public string FullName { get; set; }

        public int Age { get; set; }

        public string Address { get; set; }
    }
}