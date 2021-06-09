namespace datingapp.API.Dtos
{
    public class UserForUpdateDto
    {
        public string Username { get; set; }
         public string Password {get; set;} 
        public string Gender {get; set;} 
        public string Name {get; set;} 
        public string Surname {get; set;}  
        public string City { get; set;} 
        public string  Country {get; set;} 
        public string  Email {get; set;}
        public string Department { get; set; }
        public string Phone { get; set; }
        public string Title { get; set; }
    }
}