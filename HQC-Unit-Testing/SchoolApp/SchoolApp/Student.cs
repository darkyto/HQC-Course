namespace SchoolApp
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Student
    {
        private const int IdMinValue = 10000;
        private const int IdMaxValue = 99999;

        private static int uniqueID = IdMinValue;
        private readonly int id;
        private string name;

        public Student(string name)
        {
            this.id = uniqueID++;
            this.Name = name;
        }

        public int Id
        {
            get
            {
                if (this.id > IdMaxValue)
                {
                    throw new IndexOutOfRangeException(
                        string.Format("Student.id out of range {0} - {1}", IdMinValue, IdMaxValue));
                }

                return this.id;
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
                    throw new ArgumentNullException("Missing argument at Student.name");
                }

                this.name = value;
            }
        }
    }
}
