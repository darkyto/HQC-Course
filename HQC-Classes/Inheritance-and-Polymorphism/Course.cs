namespace InheritanceAndPolymorphism
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public abstract class Course : ICourse
    {
        private string name;
        private string teacherName;

        protected Course(string name)
        {
            this.Name = name;
            this.Students = new List<string>();
        }

        protected Course(string name, string teacherName)
            : this(name)
        {
            this.TeacherName = teacherName;
        }

        protected Course(string name, string teacherName, ICollection<string> students)
            : this(name, teacherName)
        {
            if (students != null && students.Count > 0)
            {
                foreach (var stu in students)
                {
                    this.Students.Add(stu);
                }
            }
        }

        public string Name
        {
            get 
            { 
                return this.name; 
            }

            set 
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new FormatException("Wrong input at course name setter");
                }

                this.name = value; 
            }
        }
        
        public string TeacherName
        {
            get 
            { 
                return this.teacherName; 
            }

            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new FormatException("Wrong input at teacher's name setter");
                }

                this.teacherName = value; 
            }
        }

        public List<string> Students { get; private set; }

        public virtual string GetStudentsAsString()
        {
            if (this.Students == null || this.Students.Count == 0)
            {
                return "{ }";
            }
            else
            {
                return "{ " + string.Join(", ", this.Students) + " }";
            }
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            string courseType = this.GetType().Name;
            string courseName = string.Format("Name = {0}", this.Name);
            string teacherName = string.Format("Teacher = {0}", this.TeacherName);
            string students = string.Empty;

            if (this.Students.Count > 0)
            {
                students = string.Format("Students = {0}", this.GetStudentsAsString());
            }
           
            result.AppendLine(courseType);
            result.AppendLine(courseName);
            result.AppendLine(teacherName);
            result.AppendLine(students);

            return result.ToString().Trim();
        }
    }
}
