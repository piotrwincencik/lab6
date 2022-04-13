using System;
using System.Collections.Generic;

namespace lab6
{
    class Program
    {
        class Student: IComparable<Student>
        {
            public string Name { get; set; }
            public int Ects { get; set; }

            public int CompareTo(Student other)
            {
                if (Name.CompareTo(other.Name) == 0)
                {
                    return Ects.CompareTo(other.Ects);
                }else
                return Name.CompareTo(other.Name);
            }

            public override bool Equals(object obj)
            {
                return obj is Student student &&
                       Name == student.Name &&
                       Ects == student.Ects;
            }

            public override int GetHashCode()
            {
                Console.WriteLine("Student HashCode");
                return HashCode.Combine(Name, Ects);
            }

            public override string ToString()
            {
                return $"Name = (Name), Ects = (Ects)";
            }
        }
        static void Main(string[] args)
        {
            ICollection<string> names = new List<string>();
            names.Add("Piotr");
            names.Add("Magda");
            names.Add("Łukasz");
            names.Add("Adam");

            foreach(string name in names)
            {
                Console.WriteLine(name);
            }
            Console.WriteLine(names.Contains("Adam"));

            ICollection<Student> students = new List<Student>();
            students.Add(new Student() { Name = "Adam", Ects = 12 });
            students.Add(new Student() { Name = "Piotr", Ects = 14 });
            students.Add(new Student() { Name = "Magda", Ects = 17 });
            students.Add(new Student() { Name = "Łukasz", Ects = 22 });
            students.Remove(new Student() { Name = "Adam", Ects = 12 });

            foreach (Student name in students)
            {
                Console.WriteLine(name.Name + " " + name.Ects);
            }
            Console.WriteLine(students.Contains(new Student() { Name = "Adam", Ects = 12 }));
            List<Student> list = (List<Student>)students;
            Console.WriteLine(list[0]);
            list.Insert(1, new Student() { Name = "Robert", Ects = 13 });
            foreach (Student name in students)
            {
                Console.WriteLine(name.Name + " " + name.Ects);
            }
            int index = list.IndexOf(new Student() { Name="Piotr", Ects = 14});
            Console.WriteLine("Piotr ma pozycje " + index);
            list.RemoveAt(0);
            Console.WriteLine("--------------------------SET--------------------------");

            ISet<string> set = new HashSet<string>();
            set.Add("Piotr");
            set.Add("Magda");
            set.Add("Łukasz");
            set.Add("Adam");
            foreach(string name in set)
            {
                Console.WriteLine(name);
            }
            ISet<Student> studentGroup = new HashSet<Student>();
            studentGroup.Add(new Student() { Name = "Ewa", Ects = 23 });
            studentGroup.Add(new Student() { Name = "Ewa", Ects = 23 });
            studentGroup.Add(new Student() { Name = "Mariusz", Ects = 18 });
            studentGroup.Add(new Student() { Name = "Julia", Ects = 13 });

            foreach (Student name in studentGroup)
            {
                Console.WriteLine(name.Name + " " + name.Ects);
            }
            studentGroup.Contains(new Student() { Name = "Adam", Ects = 17 });

           // studentGroup.Remove(new Student() { Name = "Łukasz", Ects = 12 });
            studentGroup = new SortedSet<Student>(studentGroup);
            studentGroup.Add(new Student() { Name = "Ewa", Ects = 56 });
            foreach (Student name in studentGroup)
            {
                Console.WriteLine(name.Name + " " + name.Ects);
            }

            Console.WriteLine( studentGroup.Contains(new Student() { Name = "Ewa", Ects = 56 }));
            Dictionary<Student, string> phoneBook = new Dictionary<Student, string>();
            phoneBook[list[0]] = "232323232";
            phoneBook[list[1]] = "343434343";
            phoneBook[list[2]] = "454545454";
            
            Console.WriteLine(phoneBook.Keys);
            if (phoneBook.ContainsKey(new Student() { Name = "Ewa", Ects = 23 })) 
            {
                Console.WriteLine("Jest numer telefonu!");
            } else
            {
                Console.WriteLine("Brak numeru telefonu.");
            }
            foreach(var item in phoneBook)
            {
                Console.WriteLine(item.Key + " " + item.Value);
            }
        }
    }
}
