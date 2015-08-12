namespace Methods
{
    using System;
    using System.Globalization;

    public class Student
    {
        private string firstName;
        private string lastName;
        private string additionalInfo;

        public Student() 
        { 
        }

        public Student(string firstName, string lastName, string additionalInfo)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.AdditionalInfo = additionalInfo;
        }

        public string FirstName 
        {
            get 
            { 
                return this.firstName; 
            }

            internal set 
            {
                if (value == null)
                {
                    throw new ArgumentNullException(this.firstName, "firstName is null!");
                }

                this.firstName = value; 
            }
        }

        public string LastName 
        {
            get 
            { 
                return this.lastName; 
            }

            internal set 
            {
                if (value == null)
                {
                    throw new ArgumentNullException(this.lastName, "lastName is null!");
                }

                this.lastName = value; 
            } 
        }

        public string AdditionalInfo 
        {
            get 
            { 
                return this.additionalInfo; 
            }

            internal set
            {
                if (value == null)
                {
                    throw new ArgumentNullException(this.additionalInfo, "additionalInfo is null!");
                }

                this.additionalInfo = value; 
            }  
        }

        public static bool IsOlderThan(Student first, Student second)
        {
            DateTime firstDate =
                DateTime.ParseExact(first.AdditionalInfo.Substring(first.AdditionalInfo.Length - 10), "dd.MM.yyyy", CultureInfo.InvariantCulture);
            DateTime secondDate =
                DateTime.ParseExact(second.AdditionalInfo.Substring(second.AdditionalInfo.Length - 10), "dd.MM.yyyy", CultureInfo.InvariantCulture);
            
            int result = DateTime.Compare(firstDate, secondDate);

            return result > -1 ? false : true;
        }
    }
}
