using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnSchoolLine.Data
{
    [Table("AppUser")]
    public class AppUser : IdentityUser
    {
        public string FullName { get; set; }

        public int Age { get; set; }

        public string Address { get; set; }

        public Guid? ClassId { get; set; }

        public ClassModel ClassModel { get; set; }

        public List<RegisterModel> RegisterModels { get; set; }
    }
}