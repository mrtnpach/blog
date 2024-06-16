using Blog.Presentation.Domain.Entities;

namespace Blog.Presentation.Domain.Singletons
{
    public class StudentInfo
    {
        private static volatile StudentInfo _instance;
        private static readonly object _instanceLock = new object();

        private StudentInfo()
        {
            StudentInitialized = false;
            AssignmentsInitialized = false;
        }

        public static StudentInfo Instance
        {
            get
            {
                if(_instance != null) return _instance;
                lock(_instanceLock)
                {
                    if(_instance == null)
                    {
                        _instance = new StudentInfo();
                    }
                }
                return _instance;
            }
        }

        public Student Student { get; private set; }
        public IEnumerable<Assignment> Assignments { get; private set; }

        public bool StudentInitialized { get; private set; }
        public bool AssignmentsInitialized { get; private set; }

        public void InitializeStudent(Student student)
        {
            if(!StudentInitialized)
            {
                this.Student = student;
                StudentInitialized = true;
            }
        }

        public void InitializeAssignments(IEnumerable<Assignment> assignments)
        {
            if(!AssignmentsInitialized)
            {
                this.Assignments = assignments;
                AssignmentsInitialized = true;
            }
        }
    }
}
