using System;
namespace jeanPatterns.Prototype
{
    public class Person
    {
        public int Age;
        public DateTime BirthDate;
        public string Name;
        public IdInfo IdInfo;

        public Person ShallowCopy()
        {
            return (Person) this.MemberwiseClone();
        }

        public Person DeepCopy()
        {
            Person clone = (Person) this.MemberwiseClone();
            clone.IdInfo = new IdInfo(IdInfo.IdNumber);
            clone.Name = String.Copy(Name);
            return clone;
        }
    }

    public class IdInfo
    {
        public int IdNumber;

        public IdInfo(int idNumber)
        {
            this.IdNumber = idNumber;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Person p1 = new Person();
            p1.Age = 25;
            p1.BirthDate = Convert.ToDateTime("1995-01-01");
            p1.Name = "Carlos";
            p1.IdInfo = new IdInfo(666);

            Person p2 = p1.ShallowCopy();
            Person p3 = p1.DeepCopy();


            Console.WriteLine("Original values of p1, p2, p3:");
            Console.WriteLine("  valores de p1: ");
            DisplayValues(p1);
            Console.WriteLine("   valores de p2:");
            DisplayValues(p2);
            Console.WriteLine("   valores de p3:");
            DisplayValues(p3);

            p1.Age = 19;
            p1.BirthDate = Convert.ToDateTime("2000-12-20");
            p1.Name = "Jean";
            p1.IdInfo.IdNumber = 7878;
            Console.WriteLine("\nValores  de p1, p2 y p3 despues de  cambiar p1:");
            Console.WriteLine("   valores p1: ");
            DisplayValues(p1);
            Console.WriteLine("   valores p2:");
            DisplayValues(p2);
            Console.WriteLine("   valores p3 :");
            DisplayValues(p3);
        }

        public static void DisplayValues(Person p)
        {
            Console.WriteLine("      Nombre: {0:s}, edad: {1:d}, Fecha de Nacimiento: {2:MM/dd/yy}",
                p.Name, p.Age, p.BirthDate);
            Console.WriteLine("      ID#: {0:d}", p.IdInfo.IdNumber);
        }
    }
}