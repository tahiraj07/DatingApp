using System;

namespace datingapp.API.Models
{
    public class Photo
    {
        public int Id { get; set; }
        public string Url { get; set; }
        public string Descripton { get; set; }
        public DateTime DateAdded { get; set; }
        public Boolean IsMain { get; set; }
        public User User { get; set; }
        public int UserId { get; set; }
    }
}