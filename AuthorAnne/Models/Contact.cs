﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AuthorAnne.Models
{
    public class Contact
    {
        public int ContactID { get; set; }

        [Display(Name = "Name*", Prompt = "Name*")]
        [StringLength(100)]
        [Required(ErrorMessage = "Please enter your name")]
        public string Name { get; set; }

        [Display(Name = "Email*", Prompt = "Email*")]
        [StringLength(200)]
        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessage = "Please enter your email address")]
        public string Email { get; set; }

        [Display(Name = "Telephone*", Prompt = "Telephone*")]
        [DataType(DataType.PhoneNumber)]
        [StringLength(15)]
        [Required(ErrorMessage = "Please enter your phone number")]
        public string Telephone { get; set; }

        [Display(Name = "Enquiry*", Prompt = "Your Message...")]
        [StringLength(20)]
        [Required(ErrorMessage = "Please enter your question or comments")]
        public string Enquiry { get; set; }
    }
}