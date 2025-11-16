//lab1
// using System;
// using System.IO;
// using System.Collections.Generic;

// public delegate void Notifier(string msg);

// class Program
// {
//     static List<string> memoryLog = new List<string>();
//     const string filePath = "log.txt";

//     static void LogToConsole(string msg)
//     {
//         Console.WriteLine("[Console] " + msg);
//     }

//     static void LogToFile(string msg)
//     {
//         File.AppendAllText(filePath, "[File] " + msg + Environment.NewLine);
//     }

//     static void LogToMemory(string msg)
//     {
//         memoryLog.Add("[Memory] " + msg);
//     }

//     static void Main()
//     {
//         Console.WriteLine("Delegate Basics & Invocation List");

//         // Compose multicast delegate
//         Notifier notify = LogToConsole;
//         notify += LogToFile;
//         notify += LogToMemory;

//         Console.WriteLine("\nFirst Notification");
//         notify("Hello from delegate!");

//         // Remove one target
//         notify -= LogToFile;

//         Console.WriteLine("\nSecond Notification (after -= LogToFile)");
//         notify("Second message!");

//         Console.WriteLine("\nIterating Invocation List (with try/catch)");

//         foreach (var d in notify.GetInvocationList())
//         {
//             try
//             {
//                 d.DynamicInvoke("Iterating message...");
//             }
//             catch (Exception ex)
//             {
//                 Console.WriteLine("Error in target: " + ex.Message);
//             }
//         }

//         Console.WriteLine("\nMemory Log Content");
//         foreach (var line in memoryLog)
//             Console.WriteLine(line);

//         Console.WriteLine("\nCheck log.txt for file output.");
//         Console.WriteLine("Done. Press Enter to exit.");
//         Console.ReadLine();
//     }
// }


//lab2
// using System;
// using System.IO;

// public class TempEventArgs : EventArgs
// {
//     public double Current { get; }
//     public double Threshold { get; }

//     public TempEventArgs(double current, double threshold)
//     {
//         Current = current;
//         Threshold = threshold;
//     }
// }

// public class TemperatureSensor
// {
//     public event EventHandler<TempEventArgs> Overheated;

//     public double Current { get; private set; }
//     public double Threshold { get; }

//     public TemperatureSensor(double threshold)
//     {
//         Threshold = threshold;
//     }

//     public void Update(double newValue)
//     {
//         Current = newValue;

//         Console.WriteLine($"[Sensor] Current: {Current}");

//         if (Current > Threshold)
//         {
//             // Raise event using ?.Invoke
//             Overheated?.Invoke(
//                 this,
//                 new TempEventArgs(Current, Threshold)
//             );
//         }
//     }
// }

// class Program
// {
//     static void Main()
//     {
//         Console.WriteLine("Lab 2 — Events with EventHandler");

//         var sensor = new TemperatureSensor(threshold: 50);

//         //Console handler — lambda
//         sensor.Overheated += (sender, args) =>
//         {
//             Console.WriteLine(
//                 $"[Console Handler] OVERHEATED! Current={args.Current}, Threshold={args.Threshold}"
//             );
//         };

//         //File handler — lambda
//         sensor.Overheated += (sender, args) =>
//         {
//             File.AppendAllText(
//                 "overheat.log",
//                 $"[File Handler] OVERHEATED: Current={args.Current}, Threshold={args.Threshold}\n"
//             );
//         };

//         // Simulate sensor updates
//         sensor.Update(20);
//         sensor.Update(45);
//         sensor.Update(55);  // triggers event
//         sensor.Update(70);  // triggers event again

//         Console.WriteLine("Check overheat.log for file output.");
//         Console.WriteLine("Done. Press Enter to exit.");
//         Console.ReadLine();
//     }
// }


//lab3
// using System;
// class Program
// {
//     static Action MakeCounter(int start)
//     {
//         int count = start;  // captured variable (closure)

//         return () =>
//         {
//             count++;
//             Console.WriteLine("Counter value: " + count);
//         };
//     }

//     static void Main()
//     {
//         Console.WriteLine("Lab 3 — Anonymous Methods & Closures");

//         var counterA = MakeCounter(0);
//         var counterB = MakeCounter(10);

//         Console.WriteLine("\nCounter A");
//         counterA();   
//         counterA();   
//         counterA();   

//         Console.WriteLine("\nCounter B");
//         counterB();   
//         counterB();   

//         Console.WriteLine("\nCounter A again (continues from its own state)");
//         counterA();   

//         Console.WriteLine("\nDone. Press Enter to exit.");
//         Console.ReadLine();
//     }
// }


//lab4
// using System;
// using System.Collections.Generic;

// class Program
// {
//     static IEnumerable<T> Transform<T>(IEnumerable<T> src, Func<T, T> map)
//     {
//         foreach (var item in src)
//             yield return map(item);
//     }

//     // Helper method for method group example
//     static string ToUpperInvariantWrapper(string s)
//     {
//         return s.ToUpperInvariant();
//     }

//     static void Main()
//     {
//         Console.WriteLine("Lab 4 — Func/Action & Method Group Conversion");

//         // Example 1 — string list + method group (correct)
//         var words = new List<string> { "apple", "banana", "cSharp" };

//         // Use a wrapper method as method group
//         var upper = Transform(words, ToUpperInvariantWrapper);

//         Console.WriteLine("\nUppercase words");
//         foreach (var w in upper)
//             Console.WriteLine(w);

//         // Example 2 — numbers + lambda (square)
//         var nums = new List<int> { 1, 2, 3, 4, 5 };

//         var squares = Transform(nums, x => x * x);  // lambda

//         Console.WriteLine("\nSquares");
//         foreach (var n in squares)
//             Console.WriteLine(n);

//         Console.WriteLine("\nDone. Press Enter to exit.");
//         Console.ReadLine();
//     }
// }
