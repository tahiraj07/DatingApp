using System;

namespace datingapp.API.Dtos
{
    public class PhotosForDetailedDto
    {
        public int Id { get; set; }
        public string Url { get; set; }
        public string Descripton { get; set; }
        public DateTime DateAdded { get; set; }
        public Boolean IsMain { get; set; }
    }
}