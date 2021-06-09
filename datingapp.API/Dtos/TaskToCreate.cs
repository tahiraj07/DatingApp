using System;
using System.ComponentModel.DataAnnotations;

namespace  datingapp.API.Dtos
{
    public class TaskToCreate
    {
        public int UserWhoCreate {get; set;} 
        public string TaskDetail {get; set;} 
        public string TaskName {get; set;} 
        public string Assigned {get; set;} 
        public string Status {get; set;} 
        public string Notify {get; set;} 
        public DateTime DueTo {get; set;} 
        public string Notes { get; set;} 
        public string ToDo { get; set;} 
        public string  Comment {get; set;} 
        public DateTime CreatedDate { get; set;} 
        public TaskToCreate()
        {
            CreatedDate = DateTime.Now; 
        }
    }
}