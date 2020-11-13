using System;
using System.Collections.Generic;
using System.Text;

namespace TaskManagementSystem.Model
{
    public class Person
    {
        public int Id { get; internal set; }
        public string FirstName { get; internal set; }
        public string LastName { get; internal set; }
        public string Address { get; internal set; }
        public string Phone { get; internal set; }
        public string Email { get; internal set; }
    }
}
