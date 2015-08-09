namespace ExampleFormating
{
    using System;
    using System.Linq;
    using System.Text;

    public class EventMain : IComparable
    {
        private readonly DateTime date;
        private readonly string title;
        private readonly string location;

        public EventMain(DateTime date, string title, string location)
        {
            this.date = date;
            this.title = title;
            this.location = location;
        }

        public int CompareTo(object obj)
        {
            EventMain other = obj as EventMain;
            int checkByDate = this.date.CompareTo(other.date);
            int checkByTitle = this.title.CompareTo(other.title);
            int checkByLocation = this.location.CompareTo(other.location);
            if (checkByDate == 0)
            {
                if (checkByTitle == 0)
                {
                    return checkByLocation;
                }
                else
                {
                    return checkByTitle;
                }
            }
            else
            {
                return checkByDate;
            }
        }

        public override string ToString()
        {
            StringBuilder toString = new StringBuilder();
            toString.Append(this.date.ToString("yyyy-MM-ddTHH:mm:ss"));
            toString.Append(" | " + this.title);
            if (this.location != null && this.location != string.Empty)
            {
                toString.Append(" | " + this.location);
            }

            return toString.ToString();
        }
    }
}