//1
// using System;
// namespace Lab1
// {
//     class Rectangle
//     {
//         private double width;
//         private double height;
//         public double Width
//         {
//             get { return width; }
//             set
//             {
//                 if (value <= 0)
//                     throw new ArgumentOutOfRangeException(nameof(Width), "Width must be greater than 0.");
//                 width = value;
//             }
//         }

//         public double Height
//         {
//             get { return height; }
//             set
//             {
//                 if (value <= 0)
//                     throw new ArgumentOutOfRangeException(nameof(Height), "Height must be greater than 0.");
//                 height = value;
//             }
//         }

//         // Read-only Area property
//         public double Area => Width * Height;

//         // Method to calculate perimeter
//         public double Perimeter() => 2 * (Width + Height);

//         // Override ToString()
//         public override string ToString()
//         {
//             return $"Rectangle {Width}x{Height} (Area={Area}, Perimeter={Perimeter()})";
//         }
//     }

//     class Program
//     {
//         static void Main()
//         {
//             try
//             {
//                 Rectangle rect = new Rectangle
//                 {
//                     Width = 3,
//                     Height = 4
//                 };

//                 Console.WriteLine(rect);
//             }
//             catch (ArgumentOutOfRangeException ex)
//             {
//                 Console.WriteLine($"Error: {ex.Message}");
//             }

//             // Example with invalid value to show exception
//             try
//             {
//                 Rectangle invalidRect = new Rectangle
//                 {
//                     Width = -5,  // invalid
//                     Height = 2
//                 };
//             }
//             catch (ArgumentOutOfRangeException ex)
//             {
//                 Console.WriteLine($"Caught exception: {ex.Message}");
//             }
//         }
//     }
// }

//2
// using System;

// namespace Lab2
// {
//     class BankAccount
//     {
//         // Properties
//         public string Owner { get; set; }
//         public string Number { get; }  // read-only
//         public decimal Balance { get; private set; }  // read-only outside class

//         // Constructor
//         public BankAccount(string owner, string number, decimal initialBalance = 0)
//         {
//             if (string.IsNullOrWhiteSpace(owner))
//                 throw new ArgumentException("Owner cannot be empty.");
//             if (string.IsNullOrWhiteSpace(number))
//                 throw new ArgumentException("Account number cannot be empty.");
//             if (initialBalance < 0)
//                 throw new ArgumentOutOfRangeException(nameof(initialBalance), "Initial balance cannot be negative.");

//             Owner = owner;
//             Number = number;
//             Balance = initialBalance;
//         }

//         // Deposit method with validation
//         public void Deposit(decimal amount)
//         {
//             if (amount <= 0)
//                 throw new ArgumentOutOfRangeException(nameof(amount), "Deposit amount must be greater than zero.");
//             Balance += amount;
//             Console.WriteLine($"Deposited {amount:C}. New balance: {Balance:C}");
//         }

//         // Withdraw method with validation
//         public void Withdraw(decimal amount)
//         {
//             if (amount <= 0)
//                 throw new ArgumentOutOfRangeException(nameof(amount), "Withdraw amount must be greater than zero.");
//             if (amount > Balance)
//                 throw new InvalidOperationException("Insufficient balance.");
//             Balance -= amount;
//             Console.WriteLine($"Withdrew {amount:C}. New balance: {Balance:C}");
//         }
//     }

//     class Program
//     {
//         static void Main()
//         {
//             try
//             {
//                 // Create a bank account
//                 BankAccount account = new BankAccount("Ani", "123-456", 100);

//                 // Demo: 3 operations
//                 account.Deposit(50);   // Deposit 50
//                 account.Withdraw(30);  // Withdraw 30
//                 account.Deposit(20);   // Deposit 20

//                 // Final balance
//                 Console.WriteLine($"Final balance: {account.Balance:C}");
//             }
//             catch (Exception ex)
//             {
//                 Console.WriteLine($"Error: {ex.Message}");
//             }

//             // Example with invalid operations
//             try
//             {
//                 BankAccount acc2 = new BankAccount("Bob", "789-012");
//                 acc2.Deposit(-10);    // invalid deposit
//             }
//             catch (Exception ex)
//             {
//                 Console.WriteLine($"Caught exception: {ex.Message}");
//             }

//             try
//             {
//                 BankAccount acc3 = new BankAccount("Cathy", "345-678", 50);
//                 acc3.Withdraw(100);   // withdraw > balance
//             }
//             catch (Exception ex)
//             {
//                 Console.WriteLine($"Caught exception: {ex.Message}");
//             }
//         }
//     }
// }

//3
// using System;
// using System.Collections.Generic;

// namespace Lab3
// {
//     // Student class
//     class Student
//     {
//         private string name;
//         private int age;

//         public string Name
//         {
//             get => name;
//             set
//             {
//                 if (string.IsNullOrWhiteSpace(value))
//                     throw new ArgumentException("Name cannot be empty.");
//                 name = value;
//             }
//         }

//         public int Age
//         {
//             get => age;
//             set
//             {
//                 if (value <= 0)
//                     throw new ArgumentOutOfRangeException(nameof(Age), "Age must be positive.");
//                 age = value;
//             }
//         }

//         public Student(string name, int age)
//         {
//             Name = name;
//             Age = age;
//         }

//         public override string ToString() => $"{Name} ({Age} y.o.)";
//     }

//     // Course class
//     class Course
//     {
//         private string title;
//         private int credits;

//         public string Title
//         {
//             get => title;
//             set
//             {
//                 if (string.IsNullOrWhiteSpace(value))
//                     throw new ArgumentException("Title cannot be empty.");
//                 title = value;
//             }
//         }

//         public int Credits
//         {
//             get => credits;
//             set
//             {
//                 if (value < 1 || value > 15)
//                     throw new ArgumentOutOfRangeException(nameof(Credits), "Credits must be between 1 and 15.");
//                 credits = value;
//             }
//         }

//         public Course(string title, int credits)
//         {
//             Title = title;
//             Credits = credits;
//         }

//         public override string ToString() => $"{Title} ({Credits} credits)";
//     }

//     // Enrollment class
//     class Enrollment
//     {
//         public Student Student { get; }
//         public Course Course { get; }
//         public DateTime EnrolledAt { get; }

//         public Enrollment(Student student, Course course)
//         {
//             Student = student ?? throw new ArgumentNullException(nameof(student), "Student cannot be null.");
//             Course = course ?? throw new ArgumentNullException(nameof(course), "Course cannot be null.");
//             EnrolledAt = DateTime.Now;
//         }

//         public override string ToString()
//         {
//             return $"{Student.Name} enrolled in {Course.Title} on {EnrolledAt}";
//         }
//     }

//     class Program
//     {
//         static void Main()
//         {
//             // Create students
//             Student s1 = new Student("Ani", 20);
//             Student s2 = new Student("Aram", 22);

//             // Create courses
//             Course c1 = new Course("Math", 5);
//             Course c2 = new Course("Programming", 10);

//             // Create enrollments
//             List<Enrollment> enrollments = new List<Enrollment>
//             {
//                 new Enrollment(s1, c1),
//                 new Enrollment(s1, c2),
//                 new Enrollment(s2, c2)
//             };

//             // Print all enrollments
//             foreach (var e in enrollments)
//             {
//                 Console.WriteLine(e);
//             }
//         }
//     }
// }


//homework1
// using System;

// namespace LabPoint2D
// {
//     class Point
//     {
//         // Read-only properties
//         public int X { get; }
//         public int Y { get; }

//         // Constructor
//         public Point(int x, int y)
//         {
//             X = x;
//             Y = y;
//         }

//         // Override Equals
//         public override bool Equals(object obj)
//         {
//             if (obj == null || obj.GetType() != typeof(Point))
//                 return false;

//             Point other = (Point)obj;
//             return this.X == other.X && this.Y == other.Y;
//         }

//         // Override GetHashCode
//         public override int GetHashCode()
//         {
//             // Simple hash code combining X and Y
//             return HashCode.Combine(X, Y);
//         }

//         // Override ToString
//         public override string ToString()
//         {
//             return $"Point({X}, {Y})";
//         }
//     }

//     class Program
//     {
//         static void Main()
//         {
//             Point p1 = new Point(3, 4);
//             Point p2 = new Point(3, 4);
//             Point p3 = new Point(5, 6);

//             Console.WriteLine(p1);           // Output: Point(3, 4)
//             Console.WriteLine(p2);           // Output: Point(3, 4)
//             Console.WriteLine(p3);           // Output: Point(5, 6)

//             // Check equality
//             Console.WriteLine($"p1.Equals(p2) = {p1.Equals(p2)}"); // True
//             Console.WriteLine($"p1.Equals(p3) = {p1.Equals(p3)}"); // False

//             // Check hash codes
//             Console.WriteLine($"p1.GetHashCode() = {p1.GetHashCode()}");
//             Console.WriteLine($"p2.GetHashCode() = {p2.GetHashCode()}");
//             Console.WriteLine($"p3.GetHashCode() = {p3.GetHashCode()}");
//         }
//     }
// }

//homework2
// using System;

// namespace LabEmail
// {
//     class Email
//     {
//         private string address;

//         public string Address
//         {
//             get => address;
//             private set
//             {
//                 if (string.IsNullOrWhiteSpace(value))
//                     throw new ArgumentNullException(nameof(value), "Email cannot be null or empty.");

//                 // Normalize: trim and lower-case
//                 address = value.Trim().ToLower();
//             }
//         }

//         // Constructor
//         public Email(string? address)
//         {
//             Address = address ?? throw new ArgumentNullException(nameof(address), "Email cannot be null.");
//         }

//         // Simple validity check
//         public bool IsValid()
//         {
//             // Basic validation: contains '@'
//             return address.Contains('@');
//         }

//         // Override ToString
//         public override string ToString()
//         {
//             return Address;
//         }
//     }

//     class Program
//     {
//         static void Main()
//         {
//             try
//             {
//                 Email e1 = new Email("  Ani.Sahakyan@Example.COM ");
//                 Console.WriteLine($"Normalized: {e1}"); // ani.sahakyan@example.com
//                 Console.WriteLine($"Is valid? {e1.IsValid()}"); // True

//                 Email e2 = new Email(null); // Will throw
//             }
//             catch (Exception ex)
//             {
//                 Console.WriteLine($"Caught exception: {ex.Message}");
//             }

//             try
//             {
//                 Email e3 = new Email("invalidemail.com"); // no '@'
//                 Console.WriteLine($"Is valid? {e3.IsValid()}"); // False
//             }
//             catch (Exception ex)
//             {
//                 Console.WriteLine($"Caught exception: {ex.Message}");
//             }
//         }
//     }
// }


//homework3
// using System;

// namespace LabLibraryBook
// {
//     class LibraryBook
//     {
//         // Properties
//         public string Title { get; private set; }
//         public string Author { get; private set; }
//         public int Year { get; private set; }

//         // Constructor 1: Title only
//         public LibraryBook(string title)
//             : this(title, "Unknown") // chain to constructor 2
//         {
//         }

//         // Constructor 2: Title + Author
//         public LibraryBook(string title, string author)
//             : this(title, author, DateTime.Now.Year) // chain to constructor 3
//         {
//         }

//         // Constructor 3: Title + Author + Year
//         public LibraryBook(string title, string author, int year)
//         {
//             // Trim and default
//             Title = string.IsNullOrWhiteSpace(title) ? "Untitled" : title.Trim();
//             Author = string.IsNullOrWhiteSpace(author) ? "Unknown" : author.Trim();

//             // Validate year
//             if (year < 1450 || year > DateTime.Now.Year)
//                 throw new ArgumentOutOfRangeException(nameof(year), $"Year must be between 1450 and {DateTime.Now.Year}.");

//             Year = year;
//         }

//         public override string ToString()
//         {
//             return $"{Title} by {Author} ({Year})";
//         }
//     }

//     class Program
//     {
//         static void Main()
//         {
//             // Demo: three ways to create a book
//             LibraryBook b1 = new LibraryBook("  War and Peace  ");
//             LibraryBook b2 = new LibraryBook("1984", "George Orwell");
//             LibraryBook b3 = new LibraryBook("C# in Depth", "Jon Skeet", 2019);

//             Console.WriteLine(b1); // War and Peace by Unknown (2025)
//             Console.WriteLine(b2); // 1984 by George Orwell (2025)
//             Console.WriteLine(b3); // C# in Depth by Jon Skeet (2019)
//         }
//     }
// }


//homework4
// using System;

// namespace LabAppSettings
// {
//     enum EnvironmentType
//     {
//         Dev,
//         Stage,
//         Prod
//     }

//     class AppSettings
//     {
//         // Immutable properties with init-only (can be set only in object creation time) setters
//         public EnvironmentType Environment { get; init; }
//         public string Version { get; init; }

//         public AppSettings(EnvironmentType environment, string version)
//         {
//             Environment = environment;
//             Version = version ?? throw new ArgumentNullException(nameof(version), "Version cannot be null.");
//         }

//         public override string ToString()
//         {
//             return $"Environment={Environment}, Version={Version}";
//         }
//     }

//     class Program
//     {
//         static void Main()
//         {
//             // Create immutable AppSettings using init-only properties
//             AppSettings settings = new AppSettings(EnvironmentType.Prod, "1.2.0");

//             Console.WriteLine(settings); // Output: Environment=Prod, Version=1.2.0

//             // The following line would cause compile-time error:
//             // settings.Version = "2.0.0";

//             // Another way using object initializer syntax (works with init)
//             AppSettings settings2 = new AppSettings(EnvironmentType.Dev, "0.9.1")
//             {
//                  Environment = EnvironmentType.Stage // allowed only here during initialization
//             };
//             Console.WriteLine(settings2);
//         }
//     }
// }
