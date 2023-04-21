using Microsoft.VisualBasic;
using System.Collections.Generic;
using System.Xml.Linq;

namespace DZ13
{
    internal class Program
    {
        static void Main()
        {
            var List = new List <int>{ 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            int c = 0;
            Console.WriteLine("1.Введите количество процентов");
            while (c == 0)
            {
                var Parse = int.TryParse(Console.ReadLine(), out c) && c<101 && c>0;
                if (!Parse) Console.WriteLine("Число должно быть от 1 до 100");
            }
            var Result = List.Top(c);
            Console.WriteLine(string.Join(", ", Result));


            var List1 = new List<Person>
            {
                new Person ( "Андрей", 15 ), new Person ( "Галя", 25 ), new Person ( "Вася", 13 ),
                new Person ( "Надя", 11 ), new Person ( "Петя", 53 ), new Person ( "Коля", 21 ), 
                new Person ( "Толя", 34 ), new Person ( "Зина", 61 ), new Person ( "Катя", 21 )
            };
            c = 0;
            Console.WriteLine("2.Введите количество процентов");
            while (c == 0)
            {
                var Parse = int.TryParse(Console.ReadLine(), out c) && c < 101 && c > 0;
                if (!Parse) Console.WriteLine("Число должно быть от 1 до 100");
            }
            var Result1 = List1.Top(c, Person => Person.Age);
            foreach (var t in Result1)
                Console.Write(t.Name + " " + t.Age + ", ");


            Console.ReadKey();
        }
        
    }
    public static class MyExtensions
    {
        public static IEnumerable<T> Top<T>(this IEnumerable<T> collection, int procent = 100)

        {
            var ResultList = (int)Math.Ceiling(collection.Count<T>() * procent / 100.0);

            return collection.OrderByDescending(x => x).Take(ResultList);
        }

        public static IEnumerable<T> Top<T>(this IEnumerable<T> collection, int procent, Func<T, int> func)

        {
            var ResultList = (int)Math.Ceiling(collection.Count<T>() * procent / 100.0);

            return collection.OrderByDescending(func).Take(ResultList);
        }
    }

    public class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public Person(string name, int age)
        {
            Name = name;
            Age = age;
        }
    }
}