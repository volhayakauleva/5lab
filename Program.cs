using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab5
{
    enum Uni { BSUIR, BSU, BNTU};

    struct Faculty
    {
        public string name;
        public string uni;

        public Faculty(string name, int university)
        {
            this.name = name;
            this.uni = Enum.GetName(typeof(Uni), university);
        }
        public void displayInfo()
        {
            Console.WriteLine($"Название факультета: {name}  Университет: {uni}\n");
        }
    }

    class Person
    {
        protected static int personCounter;

        protected string Name { get; set; }

        public Person(string name)
        {
            Name = name;
            personCounter++;
        }

        public static void peopleAmount()
        {
            Console.WriteLine("Общее количество людей: " + personCounter);
        }
        public void Show()
        {
            Console.WriteLine("Имя: " + Name);
        }
    }

    class Student : Person
    {
        protected string University { get; set; }

        public Student(string name, int university) : base(name)
        {
            this.University = Enum.GetName(typeof(Uni), university);
        }
        public new void Show()
        {
            Console.WriteLine("Имя студента: " + Name + "\nУниверситет: " + University);
        }
    }

    class Worker : Person
    {
        protected string Job { get; set; }

        public Worker(string name, string job) : base(name)
        {
            Job = job;
        }
        public new void Show()
        {
            Console.WriteLine("Имя работника: " + Name + "\nРабота: " + Job + "\n");
        }
    }

    class StudentWithSpecialty : Student
    {
        protected string Specialty { get; set; }

        public StudentWithSpecialty(string name, int university, string specialty) : base(name, university)
        {
            Specialty = specialty;
        }
        public new void Show()
        {
            Console.WriteLine("Имя студента: " + Name + "\nУниверситет: " + University + "\nСпециальность: " + Specialty + "\n");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Faculty FRE = new Faculty("ФРЭ", 0 );
            StudentWithSpecialty prog = new StudentWithSpecialty("Ваня", 0, "Программист");
            StudentWithSpecialty math = new StudentWithSpecialty("Маша", 1, "Математик");
            StudentWithSpecialty paint = new StudentWithSpecialty("Петя", 2, "Художник");         
            Worker worker1 = new Worker("Александр", "Директор");

            FRE.displayInfo();
            prog.Show();
            worker1.Show();
            Person.peopleAmount();

            Console.ReadKey();
        }
    }
}