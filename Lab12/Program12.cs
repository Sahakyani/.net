//lab1
// using System;
// using System.Collections.Generic;
// using System.Diagnostics;

// class BigObject
// {
//     private byte[] data = new byte[100 * 1024];

//     ~BigObject()
//     {
        
//     }
// }

// class Program
// {
//     static void Main()
//     {
//         Console.WriteLine("Garbage Collector Demo started.");
//         int total = 100000;           
//         int keep = 10;                
//         BigObject[] arr = new BigObject[total];

//         var sw = Stopwatch.StartNew();
//         Console.Write("Creating objects: ");
//         for (int i = 0; i < total; i++)
//         {
//             arr[i] = new BigObject();
//             if (i % 5000 == 0) Console.Write('.');
//         }
//         Console.WriteLine();
//         sw.Stop();
//         Console.WriteLine($"Created {total} objects in {sw.ElapsedMilliseconds} ms");

//         var survivors = new List<BigObject>(keep);
//         for (int i = 0; i < keep; i++) survivors.Add(arr[i]);

//         for (int i = keep; i < total; i++) arr[i] = null;

//         Console.WriteLine();
//         Console.WriteLine("Generations BEFORE GC.Collect() for kept objects:");
//         for (int i = 0; i < survivors.Count; i++)
//         {
//             Console.WriteLine($"survivor[{i}] generation = {GC.GetGeneration(survivors[i])}");
//         }

//         Console.WriteLine();
//         Console.WriteLine("GC statistics BEFORE collect:");
//         PrintGcInfo();

//         Console.WriteLine();
//         Console.WriteLine("Calling GC.Collect()...");
//         GC.Collect();
//         GC.WaitForPendingFinalizers();
//         GC.Collect();

//         Console.WriteLine();
//         Console.WriteLine("Generations AFTER GC.Collect() for kept objects:");
//         for (int i = 0; i < survivors.Count; i++)
//         {
//             Console.WriteLine($"survivor[{i}] generation = {GC.GetGeneration(survivors[i])}");
//         }

//         Console.WriteLine();
//         Console.WriteLine("GC statistics AFTER collect:");
//         PrintGcInfo();

//         Console.WriteLine();
//         Console.WriteLine("Dropping the kept references now and forcing GC again...");

//         for (int i = 0; i < survivors.Count; i++) survivors[i] = null;
//         GC.Collect();
//         GC.WaitForPendingFinalizers();
//         GC.Collect();

//         Console.WriteLine("Final GC statistics:");
//         PrintGcInfo();

//         Console.WriteLine("Demo finished. Press Enter to exit.");
//         Console.ReadLine();
//     }

//     static void PrintGcInfo()
//     {
//         long totalMemory = GC.GetTotalMemory(false);
//         Console.WriteLine($"TotalMemory (bytes): {totalMemory:N0}");
//         Console.WriteLine($"Gen0 collections: {GC.CollectionCount(0)}");
//         Console.WriteLine($"Gen1 collections: {GC.CollectionCount(1)}");
//         Console.WriteLine($"Gen2 collections: {GC.CollectionCount(2)}");
//     }
// }


//lab2
// using System;
// using System.IO;

// public class TempFileManager : IDisposable
// {
//     private bool _disposed = false;
//     public string TempFilePath { get; }

//     public TempFileManager()
//     {
//         TempFilePath = Path.GetTempFileName();

//         File.WriteAllText(TempFilePath, "Temporary team data...");

//         Console.WriteLine($"[TempFileManager] Created: {TempFilePath}");
//     }

//     public void Dispose()
//     {
//         Dispose(true);
//         GC.SuppressFinalize(this);
//     }

//     protected virtual void Dispose(bool disposing)
//     {
//         if (_disposed) return;

//         if (disposing)
//         {
            
//         }

//         if (File.Exists(TempFilePath))
//         {
//             File.Delete(TempFilePath);
//             Console.WriteLine($"[TempFileManager] Deleted: {TempFilePath}");
//         }

//         _disposed = true;
//     }

//     ~TempFileManager()
//     {
//         Dispose(false);
//     }
// }

// class Program
// {
//     static void Main()
//     {
//         Console.WriteLine("== Disposable Pattern Demo ==");

//         using (var manager = new TempFileManager())
//         {
//             Console.WriteLine("Working with the temp file...");
//             Console.WriteLine($"Temp file path: {manager.TempFilePath}");
//         }

//         Console.WriteLine("Dispose completed. Temp file removed.");
//         Console.WriteLine("Press Enter to exit.");
//         Console.ReadLine();
//     }
// }


//lab3
// using System;
// using System.Data.SqlClient;

// public class DatabaseManager : IDisposable
// {
//     private readonly Lazy<SqlConnection> _lazyConnection;

//     public DatabaseManager(string connectionString)
//     {
//         _lazyConnection = new Lazy<SqlConnection>(() =>
//         {
//             Console.WriteLine("Initializing SQL Connection...");
//             var conn = new SqlConnection(connectionString);
//             conn.Open();
//             return conn;
//         });
//     }

//     public SqlConnection Connection => _lazyConnection.Value;

//     public void Dispose()
//     {
//         if (_lazyConnection.IsValueCreated)
//         {
//             Console.WriteLine("Closing SQL Connection...");
//             Connection.Close();
//             Connection.Dispose();
//         }

//         Console.WriteLine("DatabaseManager disposed.");
//     }
// }

// class Program
// {
//     static void Main()
//     {
//         Console.WriteLine("== Lazy Initialization Demo ==");

//         string connStr = "Server=localhost;Database=TestDB;Integrated Security=True;";

//         using (var db = new DatabaseManager(connStr))
//         {
//             Console.WriteLine("DatabaseManager created.");

//             Console.WriteLine("Accessing connection for the first time...");

//             var conn = db.Connection;

//             Console.WriteLine("SQL Connection is now open.");
//             Console.WriteLine("Connection State: " + conn.State);
//         }

//         Console.WriteLine("Disposed. Press Enter to exit.");
//         Console.ReadLine();
//     }
// }
