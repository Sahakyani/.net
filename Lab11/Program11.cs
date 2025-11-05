//lab1
// using System;
// using System.Collections.Generic;
// using System.Linq;

// namespace EvenNumbersLINQ
// {
//     class Program
//     {
//         static void Main(string[] args)
//         {
//             List<int> numbers = Enumerable.Range(1, 20).ToList();

//             var evenNumbers = from n in numbers
//                               where n % 2 == 0
//                               select n;

//             Console.WriteLine("Even numbers (1-20):");
//             foreach (var num in evenNumbers)
//             {
//                 Console.Write(num + " ");
//             }
//             Console.ReadLine();
//         }
//     }
// }


//lab2
// using System;
// using System.Collections.Generic;
// using System.Linq;

// namespace NameFilterLINQ
// {
//     class Program
//     {
//         static void Main(string[] args)
//         {
//             List<string> names = new List<string>
//             {
//                 "Ani", "Aram", "Mariam", "Arthur", "Bella", "Anna", "David", "Arsen"
//             };

//             var filteredNames = from name in names
//                                 where name.StartsWith("A", StringComparison.OrdinalIgnoreCase)
//                                 select name;

//             Console.WriteLine("Names that stars with A:");
//             foreach (var name in filteredNames)
//             {
//                 Console.WriteLine(name);
//             }

//             Console.ReadLine();
//         }
//     }
// }


//lab3
// using System;
// using System.Collections.Generic;
// using System.Linq;

// namespace PriceFilterLINQ
// {
//     class Product
//     {
//         public string Name { get; set; }
//         public int Price { get; set; }
//     }

//     class Program
//     {
//         static void Main(string[] args)
//         {
//             List<Product> products = new List<Product>
//             {
//                 new Product { Name = "Phone", Price = 2500 },
//                 new Product { Name = "Mouse", Price = 800 },
//                 new Product { Name = "Keyboard", Price = 950 },
//                 new Product { Name = "Monitor", Price = 3000 },
//                 new Product { Name = "USB", Price = 600 }
//             };

//             var cheapProducts = from p in products
//                                 where p.Price < 1000
//                                 select p;

//             Console.WriteLine("Products that price is lower than 1000 :");
//             foreach (var p in cheapProducts)
//             {
//                 Console.WriteLine($"{p.Name} - {p.Price} dram");
//             }

//             Console.ReadLine();
//         }
//     }
// }


//lab4
// using System;
// using System.Collections.Generic;
// using System.Linq;

// namespace AverageGradeLINQ
// {
//     class Student
//     {
//         public string Name { get; set; }
//         public double Grade { get; set; }
//     }

//     class Program
//     {
//         static void Main(string[] args)
//         {
//             List<Student> students = new List<Student>
//             {
//                 new Student { Name = "Ani", Grade = 18.5 },
//                 new Student { Name = "Aram", Grade = 15.0 },
//                 new Student { Name = "Mariam", Grade = 19.2 },
//                 new Student { Name = "David", Grade = 13.8 },
//                 new Student { Name = "Sona", Grade = 17.0 }
//             };

//             double averageGrade = students.Average(s => s.Grade);

//             Console.WriteLine($"Average grade: {averageGrade:F2}");
//             Console.ReadLine();
//         }
//     }
// }


//homework1
// using System;
// using System.Collections.Generic;
// using System.Linq;

// namespace ListStatistics
// {
//     class Program
//     {
//         static void Main(string[] args)
//         {
//             List<int> numbers = new List<int> { 5, 12, 8, 21, 3, 14, 7, 10 };

//             int maxNumber = numbers.Max();
//             int minNumber = numbers.Min();
//             int sum = numbers.Sum();
//             double average = numbers.Average();

//             Console.WriteLine("List: " + string.Join(", ", numbers));
//             Console.WriteLine($"Max: {maxNumber}");
//             Console.WriteLine($"Min: {minNumber}");
//             Console.WriteLine($"Sum: {sum}");
//             Console.WriteLine($"Average: {average:F2}");

//             Console.ReadLine();
//         }
//     }
// }


//homework2
// using System;
// using System.Collections.Generic;
// using System.Linq;

// namespace WordLengthFilter
// {
//     class Program
//     {
//         static void Main(string[] args)
//         {
//             List<string> words = new List<string>
//             {
//                 "apple", "banana", "cherry", "kiwi", "strawberry", "melon", "grape"
//             };

//             var longWords = from w in words
//                             where w.Length > 5
//                             select w;

//             Console.WriteLine("Words that are longer > 5:");
//             foreach (var word in longWords)
//             {
//                 Console.WriteLine(word);
//             }
//             Console.ReadLine();
//         }
//     }
// }


//homework3
// using System;
// using System.Collections.Generic;
// using System.Linq;

// namespace EmployeeSalaryFilter
// {
//     class Employee
//     {
//         public string Name { get; set; }
//         public int Salary { get; set; }
//     }
//     class Program
//     {
//         static void Main(string[] args)
//         {
//             List<Employee> employees = new List<Employee>
//             {
//                 new Employee { Name = "Ani", Salary = 450000 },
//                 new Employee { Name = "Aram", Salary = 520000 },
//                 new Employee { Name = "Mariam", Salary = 600000 },
//                 new Employee { Name = "David", Salary = 480000 },
//                 new Employee { Name = "Sona", Salary = 750000 }
//             };

//             var highSalaryEmployees = from e in employees
//                                       where e.Salary > 500000
//                                       select e;

//             double averageSalary = employees.Average(e => e.Salary);

//             Console.WriteLine("EMployees whose salary > 500000:");
//             foreach (var e in highSalaryEmployees)
//             {
//                 Console.WriteLine($"{e.Name} - {e.Salary} dram");
//             }

//             Console.WriteLine($"\nSalaries average value: {averageSalary:F2} dram");
//             Console.ReadLine();
//         }
//     }
// }


//homework4
// using System;
// using System.Collections.Generic;
// using System.Linq;

// namespace GroupByExample
// {
//     class Student
//     {
//         public string Name { get; set; }
//         public int Grade { get; set; }
//     }
//     class Program
//     {
//         static void Main(string[] args)
//         {
//             List<Student> students = new List<Student>
//             {
//                 new Student { Name = "Ani", Grade = 90 },
//                 new Student { Name = "Aram", Grade = 75 },
//                 new Student { Name = "Mariam", Grade = 90 },
//                 new Student { Name = "David", Grade = 85 },
//                 new Student { Name = "Sona", Grade = 75 }
//             };

//             var groupedStudents = from s in students
//                                   group s by s.Grade into g
//                                   select new
//                                   {
//                                       Grade = g.Key,
//                                       Count = g.Count()
//                                   };

//             foreach (var group in groupedStudents)
//             {
//                 Console.WriteLine($"Grade {group.Grade}: {group.Count} students");
//             }
//             Console.ReadLine();
//         }
//     }
// }
