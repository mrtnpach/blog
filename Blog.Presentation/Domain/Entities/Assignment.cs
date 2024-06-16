using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Presentation.Domain.Entities
{
    public class Assignment
    {
        public int Id { get; set; }

        public string Name { get; set;}
        public string Description { get; set;}
        public DateTime Date { get; set; }

        public string? Filename { get; set;}

        public Student Student { get; set; }
        public Class Class { get; set;}
    }
}
