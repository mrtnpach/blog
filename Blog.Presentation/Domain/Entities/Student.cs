using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Presentation.Domain.Entities
{
    public class Student
    {
        public int Id { get; set; }

        // Blog info
        public int Legajo { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }

        public College College { get; set; }
        public List<InfoItem> InfoItems { get; set; }
        //public List<Assignment> Assignments { get; set; }
    }
}
