//lab1
// using System;
// using System.Collections.Generic;

// public static class Extensions
// {
//     //int.IsEven()
//     public static bool IsEven(this int value)
//     {
//         return value % 2 == 0;
//     }

//     //string.WordCount()
//     public static int WordCount(this string str)
//     {
//         if (string.IsNullOrWhiteSpace(str))
//             return 0;

//         var words = str.Split(new char[] { ' ', '\t', '\n', '\r' },
//                               StringSplitOptions.RemoveEmptyEntries);
//         return words.Length;
//     }

//     //List<T>.Shuffle() — Fisher-Yates
//     public static void Shuffle<T>(this List<T> list)
//     {
//         if (list == null || list.Count < 2) return;

//         Random rnd = new Random();
//         for (int i = list.Count - 1; i > 0; i--)
//         {
//             int j = rnd.Next(i + 1);
//             // Swap
//             T temp = list[i];
//             list[i] = list[j];
//             list[j] = temp;
//         }
//     }
// }

// class Program
// {
//     static void Main()
//     {
//         Console.WriteLine("Extension Methods Demo");

//         // int.IsEven()
//         int num = 42;
//         Console.WriteLine($"{num} IsEven? {num.IsEven()}");

//         // string.WordCount()
//         string sentence = "Hello world! This is C# extension methods demo.";
//         Console.WriteLine($"Sentence: \"{sentence}\"");
//         Console.WriteLine($"Word count: {sentence.WordCount()}");

//         // List<T>.Shuffle()
//         var list = new List<int> { 1, 2, 3, 4, 5, 6, 7 };
//         Console.WriteLine("Original list: " + string.Join(", ", list));

//         list.Shuffle();
//         Console.WriteLine("Shuffled list: " + string.Join(", ", list));

//         Console.WriteLine("Done. Press Enter to exit.");
//         Console.ReadLine();
//     }
// }


//lab2
// using System;
// using System.Collections.Generic;
// using System.Linq;

// class Student
// {
//     public string Name { get; set; }
//     public int Age { get; set; }
// }

// class Program
// {
//     static void Main()
//     {
//         // Sample data
//         var students = new List<Student>
//         {
//             new Student { Name = "Alice", Age = 17 },
//             new Student { Name = "Bob", Age = 18 },
//             new Student { Name = "Charlie", Age = 20 },
//             new Student { Name = "Diana", Age = 16 }
//         };

//         // LINQ query with anonymous type
//         var result = from s in students
//                      select new
//                      {
//                          s.Name,
//                          IsAdult = s.Age >= 18
//                      };

//         // Display results
//         Console.WriteLine("Name\tIsAdult");
//         foreach (var r in result)
//         {
//             Console.WriteLine($"{r.Name}\t{r.IsAdult}");
//         }

//         Console.WriteLine("Done. Press Enter to exit.");
//         Console.ReadLine();
//     }
// }


//lab3
// using System;

// class Program
// {
//     // Unsafe function to reverse array in-place
//     unsafe static void ReverseArray(int* arr, int length)
//     {
//         int* start = arr;
//         int* end = arr + length - 1;

//         while (start < end)
//         {
//             int temp = *start;
//             *start = *end;
//             *end = temp;

//             start++;
//             end--;
//         }
//     }

//     unsafe static void Main()
//     {
//         int[] numbers = { 1, 2, 3, 4, 5, 6 };

//         Console.WriteLine("Original array: " + string.Join(", ", numbers));

//         // fixed pins the array in memory and provides pointer
//         fixed (int* ptr = numbers)
//         {
//             ReverseArray(ptr, numbers.Length);
//         }

//         Console.WriteLine("Reversed array: " + string.Join(", ", numbers));

//         Console.WriteLine("Done. Press Enter to exit.");
//         Console.ReadLine();
//     }
// }

//lab4
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Student
{
    public string Name { get; set; }
    public int Age { get; set; }
}

public class StudentCollection
{
    private List<Student> _students = new List<Student>();

    // Indexer
    public Student this[int index]
    {
        get => _students[index];
        set => _students[index] = value;
    }

    public int Count => _students.Count;

    // Add student
    public void Add(Student s) => _students.Add(s);

    // + operator overload — combine two collections
    public static StudentCollection operator +(StudentCollection a, StudentCollection b)
    {
        var result = new StudentCollection();
        result._students.AddRange(a._students);
        result._students.AddRange(b._students);
        return result;
    }

    // Implicit conversion to List<Student>
    public static implicit operator List<Student>(StudentCollection c) => c._students;
}

public static class StudentExtensions
{
    // ToCsvString extension method for IEnumerable<Student>
    public static string ToCsvString(this IEnumerable<Student> students)
    {
        var sb = new StringBuilder();
        sb.AppendLine("Name,Age");
        foreach (var s in students)
        {
            sb.AppendLine($"{s.Name},{s.Age}");
        }
        return sb.ToString();
    }
}
class Program
{
    static void Main()
    {
        Console.WriteLine("Custom Collection System Demo");

        // Create first collection
        var groupA = new StudentCollection();
        groupA.Add(new Student { Name = "Alice", Age = 17 });
        groupA.Add(new Student { Name = "Bob", Age = 19 });

        // Create second collection
        var groupB = new StudentCollection();
        groupB.Add(new Student { Name = "Charlie", Age = 18 });
        groupB.Add(new Student { Name = "Diana", Age = 16 });

        // Combine collections using + operator
        var combined = groupA + groupB;

        Console.WriteLine("\nCombined Collection");
        for (int i = 0; i < combined.Count; i++)
        {
            var s = combined[i]; // indexer
            Console.WriteLine($"{i}: {s.Name}, {s.Age}");
        }

        // Implicit conversion to List<Student>
        List<Student> studentList = combined;

        // Use ToCsvString extension
        Console.WriteLine("\nCSV Output");
        Console.WriteLine(studentList.ToCsvString());

        // LINQ query returning anonymous type
        var adults = from s in studentList
                     select new
                     {
                         s.Name,
                         IsAdult = s.Age >= 18
                     };

        Console.WriteLine("\nLINQ Anonymous Type Output");
        foreach (var a in adults)
        {
            Console.WriteLine($"{a.Name}\tIsAdult: {a.IsAdult}");
        }

        Console.WriteLine("\nDone. Press Enter to exit.");
        Console.ReadLine();
    }
}
