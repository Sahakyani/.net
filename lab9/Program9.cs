//1
// using System;
// using System.Collections.Generic;

// interface IShape
// {
//     double GetArea();
// }
// class Circle : IShape
// {
//     public double Radius { get; set; }

//     public Circle(double radius)
//     {
//         Radius = radius;
//     }

//     public double GetArea()
//     {
//         return Math.PI * Radius * Radius;
//     }
// }

// class Rectangle : IShape
// {
//     public double Width { get; set; }
//     public double Height { get; set; }

//     public Rectangle(double width, double height)
//     {
//         Width = width;
//         Height = height;
//     }

//     public double GetArea()
//     {
//         return Width * Height;
//     }
// }

// class Program
// {
//     static void Main()
//     {
//         List<IShape> shapes = new List<IShape>
//         {
//             new Circle(5),
//             new Rectangle(4, 6),
//             new Circle(2.5)
//         };

//         foreach (var shape in shapes)
//         {
//             Console.WriteLine($"Shape area = {shape.GetArea():0.00}");
//         }
//     }
// }


//2
// using System;
// interface IFoo
// {
//     void Show();
// }

// interface IBar
// {
//     void Show();
// }

// class MyClass : IFoo, IBar
// {
//     void IFoo.Show()
//     {
//         Console.WriteLine("IFoo Show called");
//     }

//     void IBar.Show()
//     {
//         Console.WriteLine("IBar Show called");
//     }
// }

// class Program
// {
//     static void Main()
//     {
//         MyClass obj = new MyClass();

//         ((IFoo)obj).Show();

//         ((IBar)obj).Show();
//     }
// }

//3
// using System;
// using System.Collections.Generic;

// class Program
// {
//     //Method, որը վերադարձնում է prime թվերը մինչև N
//     static IEnumerable<int> GetPrimes(int N)
//     {
//         for (int num = 2; num <= N; num++)
//         {
//             if (IsPrime(num))
//                 yield return num; // return-ով մեկ մեկ է վերադարձնում prime
//         }
//     }
//     static bool IsPrime(int number)
//     {
//         if (number < 2) return false;

//         for (int i = 2; i * i <= number; i++)
//         {
//             if (number % i == 0)
//                 return false;
//         }
//         return true;
//     }

//     static void Main()
//     {
//         Console.Write("Enter N: ");
//         int N = int.Parse(Console.ReadLine()!);

//         Console.WriteLine($"Prime numbers up to {N}:");
//         foreach (int prime in GetPrimes(N))
//         {
//             Console.Write(prime + " ");
//         }
//         Console.WriteLine();
//     }
// }

//4
// using System;
// using System.Collections.Generic;

// class Student : IComparable<Student>
// {
//     public string Name { get; set; }
//     public double Grade { get; set; }

//     public Student(string name, double grade)
//     {
//         Name = name;
//         Grade = grade;
//     }

//     // IComparable<Student>՝ Grade-ով sorting (default)
//     public int CompareTo(Student? other)
//     {
//         if (other == null) return 1;
//         return Grade.CompareTo(other.Grade); // ascending order
//     }

//     public override string ToString() => $"{Name}: {Grade}";
// }
// class NameComparer : IComparer<Student>
// {
//     public int Compare(Student? x, Student? y)
//     {
//         if (x == null) return -1;
//         if (y == null) return 1;
//         return string.Compare(x.Name, y.Name, StringComparison.OrdinalIgnoreCase);
//     }
// }

// class Program
// {
//     static void Main()
//     {
//         List<Student> students = new List<Student>
//         {
//             new Student("Ani", 90),
//             new Student("Beni", 75),
//             new Student("Sona", 90),
//             new Student("David", 60)
//         };

//         // Default sorting՝ Grade (IComparable)
//         students.Sort();
//         Console.WriteLine("Sorted by Grade:");
//         foreach (var s in students) Console.WriteLine(s);

//         Console.WriteLine();

//         // Custom sorting՝ Name (IComparer)
//         students.Sort(new NameComparer());
//         Console.WriteLine("Sorted by Name:");
//         foreach (var s in students) Console.WriteLine(s);
//     }
// }


