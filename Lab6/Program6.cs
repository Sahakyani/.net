//1
// using System;
// class Counter
// {
//     // Static field shared by all objects
//     public static int TotalCreated { get; private set; }
//     // Instance field with auto-increment ID
//     public int Id { get; private set; }
//     // Static constructor – runs once before any object is created
//     static Counter()
//     {
//         TotalCreated = 0;
//         Console.WriteLine("Static constructor executed once.");
//     }
//     public Counter()
//     {
//         TotalCreated++;
//         Id = TotalCreated;
//     }
// }
// class Program
// {
//     static void Main()
//     {
//         Console.WriteLine("=== Counter Demo ===");
//         Counter c1 = new Counter();
//         Counter c2 = new Counter();
//         Counter c3 = new Counter();

//         Console.WriteLine($"c1.Id = {c1.Id}, Total = {Counter.TotalCreated}");
//         Console.WriteLine($"c2.Id = {c2.Id}, Total = {Counter.TotalCreated}");
//         Console.WriteLine($"c3.Id = {c3.Id}, Total = {Counter.TotalCreated}");
//     }
// }


//2
// using System;

// class LibraryBook
// {
//     // Properties – գրքի տվյալներ
//     public string Title { get; set; }
//     public string Author { get; set; }
//     public int Year { get; set; }

//     // Default constructor
//     public LibraryBook()
//         : this("Unknown Title", "Unknown Author", 2000) // Chaining to 3-param
//     { }

//     // Two-parameter constructor
//     public LibraryBook(string title, string author)
//         : this(title, author, 2000) // Chaining to 3-param
//     { }

//     // Three-parameter constructor – իրական գործը
//     public LibraryBook(string title, string author, int year)
//     {
//         Title  = title.Trim();
//         Author = author.Trim();
//         Year   = (year >= 1450) ? year : 1450; // Books didn't exist before printing press
//     }

//     public override string ToString()
//     {
//         return $"\"{Title}\" by {Author} ({Year})";
//     }
// }

// class Program
// {
//     static void Main()
//     {
//         Console.WriteLine("=== LibraryBook Demo ===");
//         // Ստեղծում ենք տարբեր տարբերակներով
//         LibraryBook b1 = new LibraryBook();                                   // default
//         LibraryBook b2 = new LibraryBook("The Hobbit", "J.R.R. Tolkien");      // 2-param
//         LibraryBook b3 = new LibraryBook("1984", "George Orwell", 1949);       // 3-param

//         // Տպում ենք արդյունքները
//         Console.WriteLine(b1);
//         Console.WriteLine(b2);
//         Console.WriteLine(b3);
//     }
// }


//3
// using System;

// class BankAccount
// {
//     // Փակ դաշտ՝ պահում է հաշվեկշիռը
//     private decimal balance;

//     // Public read-only property – միայն կարդալու համար
//     public decimal Balance => balance;

//     // Static property – բոլոր հաշիվների ընդհանուր քանակը
//     public static int TotalAccounts { get; private set; }

//     // Constructor – յուրաքանչյուր նոր հաշվի ստեղծման ժամանակ
//     public BankAccount(decimal initial = 0)
//     {
//         if (initial < 0)
//             throw new ArgumentException("Initial balance cannot be negative.");

//         balance = initial;
//         TotalAccounts++; // աճեցնում ենք ընդհանուր քանակը
//     }

//     // Deposit – գումար ավելացնել
//     public void Deposit(decimal amount)
//     {
//         if (amount <= 0)
//             throw new ArgumentException("Deposit amount must be positive.");
//         balance += amount;
//     }

//     // Withdraw – գումար հանել
//     public void Withdraw(decimal amount)
//     {
//         if (amount <= 0)
//             throw new ArgumentException("Withdraw amount must be positive.");
//         if (amount > balance)
//             throw new InvalidOperationException("Insufficient funds.");
//         balance -= amount;
//     }

//     public override string ToString()
//     {
//         return $"Balance: {balance:C}";
//     }
// }

// class Program
// {
//     static void Main()
//     {
//         Console.WriteLine("=== BankAccount Demo ===");

//         // Ստեղծում ենք հաշիվներ
//         BankAccount a1 = new BankAccount(100);
//         BankAccount a2 = new BankAccount();
//         BankAccount a3 = new BankAccount(50);

//         // Կատարում ենք գործողություններ
//         a1.Deposit(25);     // 100 + 25
//         a2.Deposit(200);    // 0 + 200
//         a3.Deposit(10);     // 50 + 10
//         a3.Withdraw(20);    // 60 - 20

//         // Տպում ենք արդյունքները
//         Console.WriteLine($"Account 1 → {a1}");
//         Console.WriteLine($"Account 2 → {a2}");
//         Console.WriteLine($"Account 3 → {a3}");
//         Console.WriteLine($"Total Accounts: {BankAccount.TotalAccounts}");
//     }
// }


//Homework1
// using System;
// class Student
// {
//     // Properties – յուրաքանչյուր ուսանողի տվյալներ
//     public string Name { get; set; }
//     public int Age { get; set; }
//     public string StudentId { get; set; }

//     // Static field – ստեղծված ուսանողների ընդհանուր քանակը
//     public static int Count { get; private set; }

//     // Default constructor – չի ստանում պարամետրեր
//     public Student()
//         : this("Unknown", 18, "0000")   // Constructor chaining
//     { }

//     // Constructor Name, Age
//     public Student(string name, int age)
//         : this(name, age, "0000")       // Chain to 3-param
//     { }

//     // Constructor Name, Age, StudentId
//     public Student(string name, int age, string studentId)
//     {
//         Name = name.Trim();
//         Age = (age >= 0) ? age : 0;
//         StudentId = studentId.Trim();
//         Count++;    // Ամեն նոր օբյեկտի ստեղծման ժամանակ աճեցնում ենք ընդհանուր քանակը
//     }

//     public override string ToString()
//     {
//         return $"Name: {Name}, Age: {Age}, ID: {StudentId}";
//     }
// }

// class Program
// {
//     static void Main()
//     {
//         Console.WriteLine("=== Student Demo ===");

//         // Ստեղծում ենք տարբեր տարբերակներով
//         Student s1 = new Student();                           // default
//         Student s2 = new Student("Ani", 20);                   // 2-param
//         Student s3 = new Student("David", 22, "ST12345");      // 3-param

//         // Տպում ենք արդյունքները
//         Console.WriteLine(s1);
//         Console.WriteLine(s2);
//         Console.WriteLine(s3);

//         // Տպում ենք ընդհանուր քանակը
//         Console.WriteLine($"Total Students: {Student.Count}");
//     }
// }


//Homework2
// using System;
// class Car
// {
//     // Properties
//     public string Model { get; set; }
//     public int Year
//     {
//         get => year;
//         set
//         {
//             if (value < 1900)
//                 throw new ArgumentOutOfRangeException(nameof(Year),
//                     "Year must be 1900 or later.");
//             year = value;
//         }
//     }
//     public int Speed { get; private set; }   // current speed, read-only outside

//     private int year; // backing field for Year

//     // Constructor
//     public Car(string model, int year)
//     {
//         Model = model.Trim();
//         Year = year;   // setter will validate
//         Speed = 0;     // default starting speed
//     }

//     // Accelerate → increase speed by given amount (default +10)
//     public void Accelerate(int amount = 10)
//     {
//         if (amount <= 0)
//             throw new ArgumentException("Acceleration must be positive.");
//         Speed += amount;
//     }

//     // Brake → decrease speed by given amount (default -10)
//     public void Brake(int amount = 10)
//     {
//         if (amount <= 0)
//             throw new ArgumentException("Brake amount must be positive.");
//         Speed -= amount;
//         if (Speed < 0) Speed = 0; // no negative speed
//     }

//     public override string ToString()
//     {
//         return $"Model: {Model}, Year: {Year}, Speed: {Speed} km/h";
//     }
// }

// class Program
// {
//     static void Main()
//     {
//         Console.WriteLine("=== Car Demo ===");

//         try
//         {
//             Car car1 = new Car("Toyota Corolla", 2010);
//             Car car2 = new Car("Ford Mustang", 1967);
//             Car car3 = new Car("Tesla Model S", 2023);

//             // Փորձարկում ենք մեթոդները
//             car1.Accelerate();       // +10
//             car1.Accelerate(20);     // +20
//             car1.Brake(5);           // -5

//             car2.Accelerate(15);
//             car2.Brake(30);          // will clamp to 0

//             car3.Accelerate(50);

//             Console.WriteLine(car1);
//             Console.WriteLine(car2);
//             Console.WriteLine(car3);

//             // Ստուգենք Year < 1900 դեպքում
//             Car badCar = new Car("Old Timer", 1880); // սա կգցի սխալ
//         }
//         catch (Exception ex)
//         {
//             Console.WriteLine($"Exception: {ex.Message}");
//         }
//     }
// }


//Homework3
// using System;

// class Logger
// {
//     // Static field → պահպանում է ծրագրի մեկնարկի պահը
//     private static readonly DateTime startTime;

//     // Static constructor → աշխատում է միայն 1 անգամ,
//     // երբ առաջին անգամ Logger class-ը օգտագործվում է
//     static Logger()
//     {
//         startTime = DateTime.Now;
//         Console.WriteLine($"[Logger] Started at: {startTime}");
//     }

//     // Method → տպում է հաղորդագրությունը ընթացիկ ժամով
//     public static void Log(string msg)
//     {
//         DateTime now = DateTime.Now;
//         Console.WriteLine($"[{now:HH:mm:ss}] {msg}");
//     }

//     // Օպցիոնալ մեթոդ՝ ծրագրի մեկնարկի պահը ստանալու համար
//     public static DateTime GetStartTime() => startTime;
// }

// class Program
// {
//     static void Main()
//     {
//         // Երբ առաջին անգամ Logger-ը կանչվում է,
//         // static constructor-ը ավտոմատ կաշխատի
//         Logger.Log("Application is running...");
//         Logger.Log("Processing data...");
//         Logger.Log("Application finished.");

//         Console.WriteLine($"Program started at: {Logger.GetStartTime()}");
//     }
// }


//Homework4
// using System;
// using System.IO;

// class FileWrapper : IDisposable
// {
//     private StreamReader reader;
//     private bool disposed = false;

//     // Constructor – բացում է ֆայլը
//     public FileWrapper(string path)
//     {
//         if (!File.Exists(path))
//             throw new FileNotFoundException("File not found.", path);

//         reader = new StreamReader(path);
//         Console.WriteLine($"File '{path}' opened.");
//     }

//     // Method – կարդում և վերադարձնում հաջորդ տողը
//     public string ReadLine()
//     {
//         if (disposed)
//             throw new ObjectDisposedException("FileWrapper");
//         return reader.ReadLine();
//     }

//     // IDisposable – փակում է ֆայլը
//     public void Dispose()
//     {
//         if (!disposed)
//         {
//             reader?.Dispose();
//             disposed = true;
//             Console.WriteLine("File closed.");
//         }
//     }
// }

// class Program
// {
//     static void Main()
//     {
//         string filePath = "sample.txt";

//         // Ստեղծում ենք ֆայլ՝ օրինակ purposes-ի համար
//         File.WriteAllText(filePath, "Line 1\nLine 2\nLine 3");

//         // Օգտագործում ենք FileWrapper-ը using block-ի միջոցով
//         using (FileWrapper fw = new FileWrapper(filePath))
//         {
//             string line;
//             while ((line = fw.ReadLine()) != null)
//             {
//                 Console.WriteLine(line);
//             }
//         }

//         // Այժմ ֆայլը ավտոմատ փակվել է using-ի ավարտին
//     }
// }
