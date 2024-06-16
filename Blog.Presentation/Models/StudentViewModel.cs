using Blog.Presentation.Domain.Entities;

namespace Blog.Presentation.Models
{
    public class StudentViewModel
    {
        public StudentViewModel(
            Student student
            )
        {
            Student = student;
            if (student.InfoItems == null)
                student.InfoItems = new List<InfoItem>();
        }

        public Student Student { get; private set; }
    }
}
