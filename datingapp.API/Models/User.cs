using System;
using System.Collections.Generic;

namespace datingapp.API.Models
{
    public class User
    {
        public int Id {get; set;}
        public string Username {get; set;}
        public byte[] PasswordHash {get; set;}
        public byte[] PasswordSalt {get; set;}
        public string Gender { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime Created { get; set; }
        public DateTime LastActive { get; set; }
        public string Introduction { get; set; }
        public string Email { get; set; } 
        public string City { get; set; }
        public string Country { get; set; }
        public string Department { get; set; }
        public string Title { get; set; }
        public string Phone { get; set; }
        public ICollection<Photo> Photos { get; set; }
        public ICollection<Like> Likers { get; set; }
        public ICollection<Like> Likees { get; set; }
        public ICollection<Message> MessagesSent { get; set; }
        public ICollection<Message> MessagesReceived { get; set; } 
        public ICollection<Tasks> TaskCreated { get; set; }
        public ICollection<Comments> UserComment { get; set; }

    }
}