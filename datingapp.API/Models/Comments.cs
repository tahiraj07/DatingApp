using System;

namespace datingapp.API.Models
{
    public class Comments
    {
     public int Id { get; set; }  
     public int UserId { get; set; } 
     public User Commenter { get; set; }   
     public int TaskId { get; set; }
     public Tasks tasksId { get; set; }
     public string Content { get; set; }   
     public DateTime CommentSent { get; set; }   
    }
}