using System;

namespace datingapp.API.Dtos
{
    public class UserForListDto
    {
        public int Id {get; set;}
        public string Username {get; set;} 
        public string Gender { get; set; }
        public int Age  { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Department { get; set; }
         public string Title { get; set; }
        public DateTime Created { get; set; }
        public DateTime LastActive { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string Phone { get; set; }
        public string PhotoUrl { get; set; }
    } 
}