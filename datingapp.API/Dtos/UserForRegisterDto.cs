using System;
using System.ComponentModel.DataAnnotations;

namespace  datingapp.API.Dtos
{
    public class UserForRegisterDto
    {
        [Required]
        public string Username {get; set;}
        [Required]
        [StringLength(8 , MinimumLength = 4,ErrorMessage="You must specify a password betwen 4-8 characters")]
        public string Password {get; set;}
        [Required]
        public string Gender {get; set;}
        [Required]
        public string Name {get; set;}
        [Required]
        public string Surname {get; set;}
        [Required]
        public DateTime DateOfBirth {get; set;}
        [Required]
        public string City { get; set;}
        [Required]
        public string  Country {get; set;}
        [Required]
        public string  Email {get; set;}
        public string Department { get; set; }
        public string Phone { get; set; }
        public string Title { get; set; }
        [Required]
        public DateTime Created { get; set;}
        public DateTime LastActive { get; set;}
        public UserForRegisterDto()
        {
            Created = DateTime.Now;
            LastActive = DateTime.Now;
        }
    }
}