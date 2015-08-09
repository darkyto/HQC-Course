namespace SchoolApp
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Course
    {
        private const int MaxStudentsInCourse = 30;

        private ICollection<Student> students;

        public Course(ICollection<Student> students)
        {
            this.Students = new List<Student>(students);
        }

        public ICollection<Student> Students 
        {
            get 
            { 
                return this.students; 
            }

            set
            {
                if (value.Count > MaxStudentsInCourse)
                {
                    throw new ArgumentOutOfRangeException("Students in each course can be max 30");
                }

                this.students = value;
            }
        }

        public void AddStudent(Student student)
        {
            this.Students.Add(student);
        }

        public void RemoveStudent(Student student)
        {
            this.Students.Remove(student);
        }
    }
}
