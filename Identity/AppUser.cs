﻿using Clothings_Store.Models;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Clothings_Store.Identity
{
    public class AppUser : IdentityUser
    {
        [PersonalData]
        [MaxLength(100)]
        public string Name { get; set; }
        [PersonalData]
        public DateTime DOB { get; set; }
        [PersonalData]
        [MaxLength(255)]
        public string? Address { get; set; }
        [DataType(DataType.Date)]
        public DateTime? Birthday { set; get; }
        [PersonalData]
        public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
       
    }
}