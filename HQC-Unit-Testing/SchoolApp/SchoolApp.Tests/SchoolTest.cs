namespace SchoolApp.Tests
{
    using System;
    using System.Collections.Generic;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class SchoolTest
    {
        [TestMethod]
        public void TestValidIdCreation()
        {
            const string Name1 = "John Snow";
            const string Name2 = "John Snow";
            var student1 = new Student(Name1);
            var student2 = new Student(Name2);
            Assert.AreEqual(10000, student1.Id);
            Assert.AreEqual(10001, student2.Id);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestStudentNameNUllCase()
        {
            const string Name1 = "John Snow";
            const string Name2 = null;
            var student1 = new Student(Name1);
            var student2 = new Student(Name2);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception), AllowDerivedTypes = true)]
        public void TestStudentNameStringEmptyCase()
        {
            var student = new Student(string.Empty);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception), AllowDerivedTypes = true)]
        public void TestStudentIdGetterOutOfRange()
        {
            for (int i = 1; i < 100000; i++)
            {
                var student = new Student("Ali-Baba#" + i);
                var currrentId = student.Id;
            }
        }

        [TestMethod]
        public void TestStudentNameGetterAndSetter()
        {
            const string StudentName = "Provalqnov";
            var student = new Student(StudentName);
            Assert.AreEqual(StudentName, student.Name);
        }

        [TestMethod]
        public void TestSchoolCreation()
        {
            var student1 = new Student("Maria");
            var student2 = new Student("Petur");
            var student3 = new Student("Asen");
            var student4 = new Student("Ivanka");
            var student5 = new Student("John");
            var student6 = new Student("Elizabeth");

            var studentsSet = new List<Student> { student1, student2, student3, student4, student5, student6 };
            var studentsSet2 = new List<Student> { student2, student3, student4 };
            var studentsSet3 = new List<Student> { student1, student3, student5, student6 };
            var studentsSet4 = new List<Student> { student2, student4 };

            var course = new Course(studentsSet);
            var course2 = new Course(studentsSet2);
            var course3 = new Course(studentsSet3);
            var course4 = new Course(studentsSet4);

            var courseSet = new List<Course> { course, course2, course3, course4 };

            var newSchool = new School(studentsSet, courseSet);
            Assert.AreEqual(studentsSet.Count, newSchool.Students.Count);
            Assert.AreEqual(courseSet.Count, newSchool.Courses.Count);
        }

        [TestMethod]
        public void TestCourseCtor()
        {
            var student1 = new Student("Bruce");
            var student2 = new Student("Lawrence");
            var student3 = new Student("Ernest");
            var student4 = new Student("Robert");

            var studentsSet = new List<Student> { student1, student2, student3, student4 };

            var course = new Course(studentsSet);
            Assert.AreEqual(studentsSet.Count, course.Students.Count);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception), AllowDerivedTypes = true)]
        public void TestCourseStudentsSetter()
        {
            var students = new List<Student>();
            for (int i = 0; i < 31; i++)
            {
                var student = new Student("B#" + i);
                students.Add(student);
            }

            var course = new Course(students);
        }

        [TestMethod]
        public void TestCourseAddStudent()
        {
            var students = new List<Student>();
            var course = new Course(students);

            var student = new Student("Vania");
            course.AddStudent(student);
            course.AddStudent(student);
            course.AddStudent(student);
            Assert.AreEqual(students.Count + 3, course.Students.Count);
        }

        [TestMethod]
        public void TestCourseRemoveStudent()
        {
            var students = new List<Student>();
            var course = new Course(students);

            var student = new Student("Petia");
            course.AddStudent(student);
            course.AddStudent(student);
            course.AddStudent(student);
            course.RemoveStudent(student);
            Assert.AreEqual(students.Count + 2, course.Students.Count);
        }
    }
}
