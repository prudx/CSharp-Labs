using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lists
{
    class Student
    {
        public int Id { get; set; }
        private string Name { get; set; }
        private char Gender { get; set; }

        public Student (int id, string name, char gender)
        {
            Id = id;
            Name = name;
            Gender = gender;
        }

        public override string ToString()
        {
            return "Id: " + Id + "\nName: " + Name + "\nGender: " + Gender +"\n";
        }
    }

    class StudentClass
    {
        public string Crn { get; set; }
        public string Lecturer { get; set; }
        public List<Student> students;

        public StudentClass (string c, string lec)
        {
            Crn = c;
            Lecturer = lec;
            students = new List<Student>();
        }

        public void StudentAdd(Student s)
        {
            if (students.Contains(s))
            {
                throw new ArgumentException("Student already contained");
            }
            else
            {
                students.Add(s);
            }
        }

        public IEnumerator GetEnumerator()
        {
            foreach (Student student in students)
            {
                yield return student;                   // iterator
            }
        }
    }

    class Test
    {
        static void Main()
        {
            Student daniel = new Student(0, "Daniel Maguire", 'M');
            Student jack = new Student(1, "Jack Harlow", 'M');


            StudentClass csharp = new StudentClass("0A", "Gary");

            csharp.StudentAdd(daniel);
            //csharp.StudentAdd(daniel);    will throw exception as expected
            csharp.StudentAdd(jack);



            foreach (Student s in csharp)
            {
                Console.WriteLine(s);
            }
        }
    }
}
