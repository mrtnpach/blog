using Blog.Presentation.Domain.Entities;

namespace Blog.Presentation.Models
{
    public class AssignmentsViewModel
    {
        public AssignmentsViewModel(IEnumerable<Assignment> assignments)
        {
            Assignments = assignments;
        }

        public IEnumerable<Assignment> Assignments { get; set; }
    }
}
