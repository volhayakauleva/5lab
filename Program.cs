using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab56
{
    enum Uni { BSUIR, BSU, BNTU};

    interface IHeight
    {
        int Height { get; }                       
        bool isMoreThanAverege();                       
    }
    interface ISayHeight : IHeight
    {
        void sayIfMoreThanAverege();
    }

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
            Console.WriteLine("Название факультета: " + name + "  Университет: " + uni + "\n");
        }
    }

    class Person : ISayHeight
    {
        protected static int personCounter;

        public string Name { get; set; }
        public int Height { get; }
        public Person(string name, int height)
        {
            Name = name;
            Height = height;
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
        public bool isMoreThanAverege()
        {
            if (Height > 175) return true;
            else return false;
        }
        public void sayIfMoreThanAverege()
        {
            if (isMoreThanAverege())
                Console.WriteLine(Name + ": рост выше среднего - " + Height + " см\n");
        }
        
        public virtual void newVoid() { Console.WriteLine("from person"); }
    }

    class Student : Person , IComparable
        {
        public string University { get; set; }

        public Student(string name, int height, int university) : base(name, height)
        {
            this.University = Enum.GetName(typeof(Uni), university);
        }
        public new void Show()
        {
            Console.WriteLine("Имя студента: " + Name + "\nУниверситет: " + University);
        }
        public int CompareTo(object o)
        {
            Student s = o as Student;
            return this.University.CompareTo(s.University);
        }
    }

    class Worker : Person
    {
        protected string Job { get; set; }

        public Worker(string name, int height, string job) : base(name, height)
        {
            Job = job;
        }
        public new void Show()
        {
            Console.WriteLine("Имя работника: " + Name + "\nРабота: " + Job + "\n");
        }
                
        public override void newVoid()
        { Console.WriteLine("from worker"); }
    }

    class StudentWithSpecialty : Student
    {
        protected string Specialty { get; set; }

        public StudentWithSpecialty(string name, int height, int university, string specialty) : base(name, height, university)
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
            StudentWithSpecialty prog = new StudentWithSpecialty("Ваня", 180, 0, "Программист");
            StudentWithSpecialty math = new StudentWithSpecialty("Маша", 160, 0, "Математик");
            StudentWithSpecialty paint = new StudentWithSpecialty("Петя", 200, 2, "Художник");         
            Worker worker1 = new Worker("Александр", 190, "Директор");

            FRE.displayInfo();
            prog.Show();
            worker1.Show();
            paint.sayIfMoreThanAverege();
            Person.peopleAmount();
            if (prog.CompareTo(math) == 0)
            {
                Console.WriteLine(prog.Name + " и " + math.Name + " учатся в одном университете:" + prog.University + " \n");
            } else
            {
                Console.WriteLine(prog.Name + " и " + math.Name + " учатся в разных университетах\n");
            }            

            
            Person newPersWork = new Worker("newWorker", 200, "newWork");
            newPersWork.Show();     //new, метод из person
            newPersWork.newVoid();  //override, метод из worker
                   
            Console.ReadKey();
        }
    }
}
