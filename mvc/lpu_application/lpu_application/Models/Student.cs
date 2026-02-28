using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace lpu_application.Models
{
    public class Student
    {
        [Key]
        public int StudentId { get; set; }

        public string? RegistrationNo { get; set; }

        [Required(ErrorMessage = "First Name is required")]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last Name is required")]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [DataType(DataType.Password)]
        [MinLength(6, ErrorMessage = "Minimum 6 characters")]
        public string Password { get; set; }

        [Display(Name = "Phone Number")]
        public string? Phone { get; set; }

        [Display(Name = "Date of Birth")]
        [DataType(DataType.Date)]
        public DateTime? DateOfBirth { get; set; }

        public string? Gender { get; set; }

        public string? Course { get; set; }

        public string? Branch { get; set; }

        public string? Address { get; set; }

        [Display(Name = "Profile Photo")]
        public string? PhotoPath { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        // This is NOT mapped to DB — used only for file upload in form
        [NotMapped]
        public IFormFile? PhotoFile { get; set; }
    }
}