//1
// using System;
// using System.IO;

// class FileReaderDemo
// {
//     static void Main()
//     {
//         StreamReader? reader = null;

//         try
//         {
//             string path = "example.txt";

//             if (!File.Exists(path))
//             {
//                 Console.WriteLine("File not found, creating a new one...");
//                 File.WriteAllText(path, "This is a new file created automatically.");
//             }

//             reader = new StreamReader(path);
//             string content = reader.ReadToEnd();
//             Console.WriteLine("File content:");
//             Console.WriteLine(content);
//         }
//         catch (FileNotFoundException)
//         {
//             Console.WriteLine("Error: File not found!");
//         }
//         finally
//         {
//             if (reader != null)
//             {
//                 reader.Close();
//                 Console.WriteLine("Reader closed.");
//             }
//         }
//     }
// }

//2
// using System;

// // Սեփական (custom) բացառություն
// class InvalidGradeException : Exception
// {
//     public InvalidGradeException(string message) : base(message)
//     {
//     }
// }

// class Program
// {
//     static void Main()
//     {
//         try
//         {
//             Console.Write("Enter grade (0-100): ");
//             int grade = int.Parse(Console.ReadLine()!);

//             if (grade < 0 || grade > 100)
//             {
//                 throw new InvalidGradeException($"Invalid grade: {grade}. Grade must be between 0 and 100.");
//             }

//             Console.WriteLine($"Grade {grade} is valid ");
//         }
//         catch (InvalidGradeException ex)
//         {
//             Console.WriteLine($"Error: {ex.Message}");
//         }
//         catch (FormatException)
//         {
//             Console.WriteLine("Error: Please enter a valid number!");
//         }
//     }
// }

//3
// using System;
// using System.IO;

// class InnerExceptionDemo
// {
//     static void Main()
//     {
//         try
//         {
//             try
//             {
//                 // Փորձում ենք բացել ֆայլ, որը գոյություն չունի
//                 using StreamReader reader = new StreamReader("data.txt");
//                 Console.WriteLine(reader.ReadToEnd());
//             }
//             catch (FileNotFoundException ex)
//             {
//                 // Նետում ենք նոր ApplicationException՝ ներքին exception-ով
//                 throw new ApplicationException("Failed to load file in Main().", ex);
//             }
//         }
//         catch (ApplicationException ex)
//         {
//             Console.WriteLine($"Outer Exception: {ex.Message}");

//             if (ex.InnerException != null)
//             {
//                 Console.WriteLine($"Inner Exception: {ex.InnerException.Message}");
//             }
//         }
//     }
// }


//4
// using System;

// class ExceptionFilterDemo
// {
//     static void Main()
//     {
//         try
//         {
//             Console.Write("Enter error type (DB/IO/Other): ");
//             string? input = Console.ReadLine();

//             if (input == null)
//                 throw new Exception("No input provided!");

//             if (input.Equals("DB", StringComparison.OrdinalIgnoreCase))
//                 throw new Exception("DB connection failed!");
//             else if (input.Equals("IO", StringComparison.OrdinalIgnoreCase))
//                 throw new Exception("IO read error!");
//             else
//                 throw new Exception("Unknown error occurred!");
//         }
//         catch (Exception ex) when (ex.Message.Contains("DB", StringComparison.OrdinalIgnoreCase))
//         {
//             Console.WriteLine($"Caught DB-related error: {ex.Message}");
//         }
//         catch (Exception ex)
//         {
//             Console.WriteLine($"Other error (not DB): {ex.Message}");
//         }
//     }
// }
