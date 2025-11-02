//lab1
// using System;
// using System.Collections.Generic;
// using System.Linq;

// namespace StudentListDemo
// {
//     class Student
//     {
//         public string Name { get; set; }
//         public int Grade { get; set; }

//         public Student(string name, int grade)
//         {
//             Name = name;
//             Grade = grade;
//         }
//     }

//     class Program
//     {
//         static void Main(string[] args)
//         {
//             List<Student> students = new List<Student>
//             {
//                 new Student("Ani", 95),
//                 new Student("Tatev", 78),
//                 new Student("Aram", 82),
//                 new Student("Gor", 67),
//                 new Student("Lilith", 88)
//             };

//             Console.WriteLine("Students whose Grade > 80:");

//             foreach (var student in students.Where(s => s.Grade > 80))
//             {
//                 Console.WriteLine($"{student.Name} - Grade: {student.Grade}");
//             }
//             Console.ReadLine();
//         }
//     }
// }

//lab2
// using System;
// using System.Collections.Generic;

// namespace PhoneBookDemo
// {
//     class Program
//     {
//         static void Main(string[] args)
//         {
//             Dictionary<string, string> phoneBook = new Dictionary<string, string>
//             {
//                 { "Ani", "091234567" },
//                 { "Tatev", "099876543" },
//                 { "Aram", "093112233" },
//                 { "Gor", "094556677" }
//             };

//             Console.Write("Enter name՝ ");
//             string name = Console.ReadLine();

//             if (phoneBook.ContainsKey(name))
//             {
//                 Console.WriteLine($"Phone number՝ {phoneBook[name]}");
//             }
//             else
//             {
//                 Console.WriteLine("There is no contact in that name ։");
//             }
//             Console.ReadLine();
//         }
//     }
// }

//lab3
// using System;
// using System.Collections.Generic;

// namespace QueueSimulation
// {
//     class Program
//     {
//         static void Main(string[] args)
//         {
//             Queue<string> customers = new Queue<string>();

//             while (true)
//             {
//                 Console.WriteLine("1. Add customer");
//                 Console.WriteLine("2. Serve customer");
//                 Console.WriteLine("3. watch queue");
//                 Console.WriteLine("4. exit");
//                 Console.Write("Enter 1-4: ");

//                 string choice = Console.ReadLine();
//                 Console.WriteLine();

//                 switch (choice)
//                 {
//                     case "1":
//                         Console.Write("Enter customer name:  ");
//                         string name = Console.ReadLine();
//                         customers.Enqueue(name);//add in the end of queue
//                         Console.WriteLine($"{name} added to queue։");
//                         break;

//                     case "2":
//                         if (customers.Count > 0)
//                         {
//                             string served = customers.Dequeue(); // delete first in queue
//                             Console.WriteLine($"{served} was served։");
//                         }
//                         else
//                         {
//                             Console.WriteLine("Queue is empty։");
//                         }
//                         break;

//                     case "3":
//                         if (customers.Count > 0)
//                         {
//                             Console.WriteLine("Watching queue: ");
//                             foreach (var c in customers)
//                                 Console.WriteLine($"- {c}");
//                         }
//                         else
//                         {
//                             Console.WriteLine("There is no one in queue։");
//                         }
//                         break;

//                     case "4":
//                         Console.WriteLine("Program was ended։");
//                         return;

//                     default:
//                         Console.WriteLine("Something went wrong, try again։");
//                         break;
//                 }
//             }
//         }
//     }
// }

//lab4
// using System;
// using System.Collections.Generic;

// namespace UniqueWordsDemo
// {
//     class Program
//     {
//         static void Main(string[] args)
//         {
//             Console.WriteLine("Enter text: ");
//             string text = Console.ReadLine();

//             char[] separators = { ' ', ',', '.', '!', '?', ';', ':', '\t', '\n' };
//             string[] words = text.Split(separators, StringSplitOptions.RemoveEmptyEntries);

//             HashSet<string> uniqueWords = new HashSet<string>(StringComparer.OrdinalIgnoreCase);

//             foreach (string word in words)
//             {
//                 uniqueWords.Add(word);
//             }

//             Console.WriteLine($"\nunique word count {uniqueWords.Count}");
//             Console.WriteLine("unique words: ");

//             foreach (var word in uniqueWords)
//             {
//                 Console.WriteLine(word);
//             }
//             Console.ReadLine();
//         }
//     }
// }

//homework1
// using System;
// using System.Collections.Generic;

// namespace ProductPriceDictionary
// {
//     class Program
//     {
//         static void Main(string[] args)
//         {
//             Dictionary<string, double> products = new Dictionary<string, double>
//             {
//                 { "Bread", 450.0 },
//                 { "Milk", 650.0 },
//                 { "Cheese", 2800.0 },
//                 { "Shugar", 550.0 },
//                 { "Egg", 120.0 }
//             };

//             Console.Write("Enter product name:  ");
//             string name = Console.ReadLine();

//             if (products.ContainsKey(name))
//             {
//                 Console.WriteLine($"{name} price is {products[name]}");
//             }
//             else
//             {
//                 Console.WriteLine("That kind of product doesn't exist։");
//             }

//             Console.ReadLine();
//         }
//     }
// }


//homework2
// using System;
// using System.Collections.Generic;

// namespace TaskQueueDemo
// {
//     class Program
//     {
//         static void Main(string[] args)
//         {
//             Queue<string> tasks = new Queue<string>();

//             while (true)
//             {
//                 Console.WriteLine("1. Add Task");
//                 Console.WriteLine("2. do next Task");
//                 Console.WriteLine("3. watch queue");
//                 Console.WriteLine("4. exit");
//                 Console.Write("Choose number (1-4): ");

//                 string choice = Console.ReadLine();
//                 Console.WriteLine();

//                 switch (choice)
//                 {
//                     case "1":
//                         Console.Write("Enter task name:  ");
//                         string taskName = Console.ReadLine();
//                         tasks.Enqueue(taskName); 
//                         Console.WriteLine($"Task '{taskName}' added to queue։");
//                         break;

//                     case "2":
//                         if (tasks.Count > 0)
//                         {
//                             string done = tasks.Dequeue(); // delete first
//                             Console.WriteLine($"Task '{done}' is done։");
//                         }
//                         else
//                         {
//                             Console.WriteLine("There is no task in queue։");
//                         }
//                         break;

//                     case "3":
//                         if (tasks.Count > 0)
//                         {
//                             Console.WriteLine("Current queue: ");
//                             foreach (var t in tasks)
//                                 Console.WriteLine($"- {t}");
//                         }
//                         else
//                         {
//                             Console.WriteLine("There is no task in queue։ ");
//                         }
//                         break;

//                     case "4":
//                         Console.WriteLine("Program ended։");
//                         return;

//                     default:
//                         Console.WriteLine("Something went wrong, try again։");
//                         break;
//                 }
//             }
//         }
//     }
// }

//homework3
// using System;
// using System.Collections.Generic;

// namespace BrowserHistoryDemo
// {
//     class Program
//     {
//         static void Main(string[] args)
//         {
//             Stack<string> history = new Stack<string>();

//             while (true)
//             {
//                 Console.WriteLine("1. Open new page (Push)");
//                 Console.WriteLine("2. Return to previous page (Undo / Pop)");
//                 Console.WriteLine("3. Watch history");
//                 Console.WriteLine("4. Exit");
//                 Console.Write("Choose number (1-4): ");

//                 string choice = Console.ReadLine();
//                 Console.WriteLine();

//                 switch (choice)
//                 {
//                     case "1":
//                         Console.Write("Enter page name: ");
//                         string page = Console.ReadLine();
//                         history.Push(page); // Adding to the top of the stack
//                         Console.WriteLine($"Page '{page}' opened։");
//                         break;

//                     case "2":
//                         if (history.Count > 0)
//                         {
//                             string lastPage = history.Pop(); // Delete last one
//                             Console.WriteLine($"returned from '{lastPage}' page։");
//                         }
//                         else
//                         {
//                             Console.WriteLine("History is empty։");
//                         }
//                         break;

//                     case "3":
//                         if (history.Count > 0)
//                         {
//                             Console.WriteLine("history of browser: ");
//                             foreach (var p in history)
//                                 Console.WriteLine($"- {p}");
//                         }
//                         else
//                         {
//                             Console.WriteLine("There is no history yet։");
//                         }
//                         break;

//                     case "4":
//                         Console.WriteLine("Program ended։");
//                         return;

//                     default:
//                         Console.WriteLine("Something went wrong, try again։");
//                         break;
//                 }
//             }
//         }
//     }
// }

//homework4
// using System;
// using System.Collections.Generic;

// namespace UniqueEmailsDemo
// {
//     class Program
//     {
//         static void Main(string[] args)
//         {
//             HashSet<string> emails = new HashSet<string>(StringComparer.OrdinalIgnoreCase);

//             while (true)
//             {
//                 Console.Write("\nEnter email or exit for logg out: ");
//                 string input = Console.ReadLine();

//                 if (input.ToLower() == "exit")
//                     break;

//                 if (!emails.Add(input))
//                 {
//                     Console.WriteLine("Duplicate — this email are already exist։");
//                 }
//                 else
//                 {
//                     Console.WriteLine("Email added successfully։");
//                 }
//             }

//             Console.WriteLine("\nUnique emails: ");
//             foreach (var email in emails)
//             {
//                 Console.WriteLine($"- {email}");
//             }

//             Console.WriteLine($"\nUnique emails count: {emails.Count}");
//             Console.ReadLine();
//         }
//     }
// }
