namespace InheritanceAndPolymorphism
{
    using System;
    using System.Collections.Generic;

    public class CoursesExamples
    {
        public static void Main()
        {
            LocalCourse localCourse = new LocalCourse("JS OOP", "Ivan Ivanov", new List<string>() { "Peter", "Maria" }, "Enterprise");
            Console.WriteLine(localCourse);
            localCourse.Students.Add("Gosho");
            localCourse.Students.Add("Pesho");
            localCourse.Students.Add("Stamatka");
            localCourse.Students.Add("Vania");
            Console.WriteLine(localCourse);

            OffsiteCourse offsiteCourse = new OffsiteCourse("JS Fundamental", "Maria Petrova", new List<string>() { "Mitko", "Stamat", "John Snow" }, "Sofia");
            Console.WriteLine(offsiteCourse);
        }
    }
}