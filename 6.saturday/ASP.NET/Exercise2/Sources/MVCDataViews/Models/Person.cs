using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace MVCDataViews.Models
{
    public class Person
    {
        [Required(ErrorMessage = "The ID is required.")]
        public int Id { get; set; }

        [Required(ErrorMessage = "The name is required.")]
        public string Name { get; set; }

        [Range(1, 200, ErrorMessage = "A number between 1 and 200.")]
        public int Age { get; set; }

        [RegularExpression(@"((\(\d{3}\) ?)|(\d{3}-))?\d{3}-\d{4}", ErrorMessage = "Invalid phone number.")]
        public string Phone { get; set; }

        [RegularExpression(@"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$", ErrorMessage = "Invalid email address.")]
        public string Email { get; set; }
    }
}