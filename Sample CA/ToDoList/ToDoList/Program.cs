using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public enum Priority
{
    Low, Medium, High
}

namespace ToDoList
{
    class ToDo
    {
        private string Subject { get; set; }
        private DateTime DueDate { get; set; }
        private Priority NotePriority { get; set; }

        public ToDo (string subject, DateTime dueDate, Priority notePriority)
        {
            Subject = subject;
            DueDate = dueDate;
            NotePriority = notePriority;
        }

        public override string ToString()
        {
            return DueDate.Day +"-" +DueDate.Month +"-" +DueDate.Year +"\nPriority: " +NotePriority +"\n"+Subject+"\n";
        }
    }

    class ToDoList
    {
        private string Owner { get; set; }
        private List<ToDo> todolist;

        public ToDoList(string owner)
        {
            Owner = owner;
            todolist = new List<ToDo>();
        }

        public void AddToDo(ToDo t) => todolist.Add(t);

        public override string ToString()
        {
            Console.WriteLine(Owner + "'s Todo List");
            foreach (var s in todolist)
            {
                Console.WriteLine(s.ToString());
            }

            return "Finish";
        }
    }

    class Test
    {
        public static void Main()
        {
            ToDo t1 = new ToDo("Lipo lisur laso darius", DateTime.Now, Priority.Low);
            ToDo t2 = new ToDo("Lipo lisur laso darius", DateTime.Now, Priority.High);
            ToDo t3 = new ToDo("Lipo lisur laso darius", DateTime.Now, Priority.Medium);

            ToDoList tdl1 = new ToDoList("Daniel");

            try
            {
                tdl1.AddToDo(t1);
                tdl1.AddToDo(t2);
                tdl1.AddToDo(t3);
            }
            catch
            {
                throw new ArgumentException("Adding to todolist failed");
            }
            

            Console.WriteLine(tdl1.ToString());

        }
    }
}
