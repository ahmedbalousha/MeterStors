﻿using MS.Core.Enums;
using System;
using System.ComponentModel.DataAnnotations;

namespace MS.Core.Dtos
{
    public class CreateUserDto
    {
        [Required]
        [Display(Name = "اسم المستخدم")]
        public string FullName { get; set; }
        [Required]
        [EmailAddress]
        [Display(Name = "البريد الالكتروني ")]
        public string Email { get; set; }
        [Required]
        [Phone]
        [Display(Name = "رقم الجوال ")]
        public string PhoneNumber { get; set; }
        [Display(Name = "الصورة")]
       // public IFormFile Image { get; set; }

        [DataType(DataType.Date)]
        public DateTime? DOB { get; set; }
        [Display(Name = "نوع المستخدم")]
        public UserType UserType { get; set; }
    }
}
