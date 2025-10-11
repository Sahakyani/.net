//1
// using System;
// class Program
// {
//     static void Main()
//     {
//         int[,] matrix = {
//             {5, 6, 7},
//             {1, 3, 5}
//         };

//         int rows = matrix.GetLength(0);
//         int cols = matrix.GetLength(1);

//         for (int r = 0; r < rows; r++)
//         {
//             int rowSum = 0;

//             for (int c = 0; c < cols; c++)
//             {
//                 rowSum += matrix[r, c];
//             }

//             Console.WriteLine($"Row {r + 1} Sum = {rowSum}");
//         }
//     }
// }


//2
// using System;
// class Program
// {
//     static bool Divide(double a, double b, out double result)
//     {
//         if (b == 0)
//         {
//             result = 0;
//             return false;
//         }
//         else
//         {
//             result = (double)a / b;
//             return true;
//         }
//     }
//     static void Main()
//     {
//         Console.Write("Enter a: ");
//         double a = double.Parse(Console.ReadLine());
//         Console.Write("Enter b: ");
//         double b = double.Parse(Console.ReadLine());

//         if (Divide(a, b, out double result))
//         {
//             Console.WriteLine($"Result = {result}");
//         }
//         else
//         {
//             Console.WriteLine("Cannot divide by zero!");
//         }
//     }
// }

//3
// using System;

// namespace MyProgram
// {
//     enum UserRole { Admin, Editor, Viewer }

//     class Program
//     {
//         static void Main()
//         {
//             Console.Write("Enter your role number: ");

//             if (int.TryParse(Console.ReadLine(), out int input) && input >= 0 && input <= 2)
//             {
//                 UserRole role = (UserRole)input;

//                 switch (role)
//                 {
//                     case UserRole.Admin:
//                         Console.WriteLine("You have full access!");
//                         break;
//                     case UserRole.Editor:
//                         Console.WriteLine("You can only edit content!");
//                         break;
//                     case UserRole.Viewer:
//                         Console.WriteLine("You can only view content!");
//                         break;
//                 }
//             }
//             else
//             {
//                 Console.WriteLine("Invalid input");
//             }  
//         }
//     }
// }

//4
// using System;

// namespace MyProgram
// {
//     struct Rectangle
//     {
//         public double Width { get; set; }
//         public double Height { get; set; }

//         public double GetArea()
//         {
//             return Width * Height;
//         }
//     }

//     class Program
//     {
//         static void Main()
//         {
//             Rectangle rect = new Rectangle { Width = 8, Height = 5 };
//             Console.WriteLine($"Rectangle Area is: {rect.GetArea()}");
//         }
//     }
// }

//5
// using System;
// using System.Linq;
// namespace MyProgram
// {
//     class Program
//     {
//         static (int Min, int Max) FindMinMax(int[] numbers)
//         {
//             int min = numbers.Min();
//             int max = numbers.Max();

//             return (min, max);
//         }

//         static void Main()
//         {
//             int[] numbers = { 5, 6, 2, 0, 4, 12 };

//             var result = FindMinMax(numbers);
//             Console.WriteLine($"Min = {result.Min}, Max = {result.Max}");
//         }
//     }
// }