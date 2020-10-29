using System;
using System.Collections.Generic;
using System.Text;

namespace TaskManagementSystem.Model
{
    public class Task
    {
        public int Id { get; set; }
        public string TaskName { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
    }
}
