using System;

namespace datingapp.API.Dtos
{
    public class CommentsToCreate
    {
        public int UserId  { get; set; }
        public int TaskId { get; set; } 
        public DateTime CommentSent { get; set; }
        public string Content { get; set; }

        public CommentsToCreate()
        {
            CommentSent = DateTime.Now;
        }

    }
}