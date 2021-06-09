using System;
using System.Collections.Generic;

namespace datingapp.API.Models
{
    public class Tasks
    {
        public int Id { get; set; }
        public int UserWhoCreate { get; set; }
        public User CreatedBy { get; set; }
        public string TaskDetail { get; set; }
        public string TaskName { get; set; }
        public DateTime DueTo { get; set; }
        public DateTime CreatedDate { get; set; }
        public string Assigned { get; set; }
        public string Status { get; set; }
        public string Notify { get; set; }
        public string Notes { get; set; }
        public string Comment { get; set; }
        public string ToDo { get; set; }
        public ICollection<Comments> TasksId { get; set; }

    }
}