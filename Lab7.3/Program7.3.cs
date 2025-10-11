//1
// using System;
// using System.Collections.Generic;

// // Product class for the dictionary value
// public class Product
// {
//     public string Name { get; set; }
//     public decimal Price { get; set; }
    
//     public Product(string name, decimal price)
//     {
//         Name = name;
//         Price = price;
//     }
    
//     public override string ToString() => $"{Name} (${Price})";
// }

// // Immutable ProductCode value object
// public sealed class ProductCode : IEquatable<ProductCode>
// {
//     public string Sku { get; }
//     public string? Country { get; }

//     public ProductCode(string sku, string? country)
//     {
//         Sku = sku;
//         Country = country;
//     }

//     // IEquatable<T> implementation
//     public bool Equals(ProductCode? other)
//     {
//         return other is not null &&
//                Sku == other.Sku &&
//                Country == other.Country;
//     }

//     public override bool Equals(object? obj)
//     {
//         return Equals(obj as ProductCode);
//     }

//     public override int GetHashCode()
//     {
//         return HashCode.Combine(Sku, Country);
//     }
    
//     public override string ToString()
//     {
//         return Country == null ? Sku : $"{Sku}-{Country}";
//     }
// }

// class Program
// {
//     static void Main()
//     {
//         // Create Dictionary with ProductCode as key
//         var productDictionary = new Dictionary<ProductCode, Product>();
        
//         // Add first product
//         var code1 = new ProductCode("LAPTOP123", "US");
//         productDictionary[code1] = new Product("Gaming Laptop", 999.99m);
//         Console.WriteLine($"Added: {code1} -> {productDictionary[code1]}");
        
//         // Add second product with different code
//         var code2 = new ProductCode("MOUSE456", "EU");
//         productDictionary[code2] = new Product("Wireless Mouse", 49.99m);
//         Console.WriteLine($"Added: {code2} -> {productDictionary[code2]}");
        
//         // Try to add product with same Sku/Country as code1 (should NOT create duplicate)
//         var code3 = new ProductCode("LAPTOP123", "US");
//         productDictionary[code3] = new Product("Business Laptop", 899.99m);
//         Console.WriteLine($"Added same key: {code3} -> {productDictionary[code3]}");
        
//         Console.WriteLine("\nFinal dictionary contents:");
//         foreach (var kvp in productDictionary)
//         {
//             Console.WriteLine($"Key: {kvp.Key} -> Value: {kvp.Value}");
//         }
        
//         // Demonstrate no duplicates
//         Console.WriteLine($"\nTotal items in dictionary: {productDictionary.Count}");
//         Console.WriteLine($"code1.Equals(code3): {code1.Equals(code3)}");
//         Console.WriteLine($"code1.GetHashCode() == code3.GetHashCode(): {code1.GetHashCode() == code3.GetHashCode()}");
        
//         // Test lookup with equal key
//         var lookupCode = new ProductCode("LAPTOP123", "US");
//         if (productDictionary.TryGetValue(lookupCode, out var foundProduct))
//         {
//             Console.WriteLine($"\nLookup with equal key found: {foundProduct}");
//         }
//     }
// }

//2
// using System;
// using System.Globalization;

// public sealed class Money : IFormattable
// {
//     public decimal Amount { get; }
//     public string Currency { get; }

//     public Money(decimal amount, string currency)
//     {
//         Amount = amount;
//         Currency = currency ?? throw new ArgumentNullException(nameof(currency));
//     }

//     // Default ToString
//     public override string ToString()
//     {
//         return $"{Amount:N2} {Currency}";
//     }

//     // IFormattable implementation
//     public string ToString(string? format, IFormatProvider? formatProvider)
//     {
//         if (string.IsNullOrEmpty(format))
//             return ToString();

//         return format.ToUpperInvariant() switch
//         {
//             "F" => $"{Amount:N2} {Currency}",  // Full: 1,234.56 USD
//             "S" => $"{Currency} {Amount:N2}",  // Short: USD 1234.56
//             "C" => $"{Currency} {Amount:#,##0.00}", // Compact: USD 1,234.56
//             "N" => Amount.ToString("N2", formatProvider), // Number only: 1,234.56
//             _ => ToString()
//         };
//     }
// }

// class Program
// {
//     static void Main()
//     {
//         var money = new Money(1234.56m, "USD");
        
//         Console.WriteLine("=== Money ToString Formats Demo ===");
        
//         // Default ToString
//         Console.WriteLine($"Default: {money}");
        
//         // Custom formats
//         Console.WriteLine($"Format 'F' (Full): {money.ToString("F", null)}");
//         Console.WriteLine($"Format 'S' (Short): {money.ToString("S", null)}");
//         Console.WriteLine($"Format 'C' (Compact): {money.ToString("C", null)}");
//         Console.WriteLine($"Format 'N' (Number only): {money.ToString("N", null)}");
//         Console.WriteLine($"Unknown format: {money.ToString("X", null)}");
        
//         // Using in string interpolation
//         Console.WriteLine($"\nString interpolation:");
//         Console.WriteLine($"Price: {money:F}");
//         Console.WriteLine($"Currency first: {money:S}");
        
//         // Multiple money instances
//         Console.WriteLine($"\nMultiple amounts:");
//         var amounts = new[]
//         {
//             new Money(99.99m, "USD"),
//             new Money(1500m, "EUR"),
//             new Money(50000m, "AMD")
//         };
        
//         foreach (var amount in amounts)
//         {
//             Console.WriteLine($"Full: {amount:F} | Short: {amount:S}");
//         }
        
//         // Large number demonstration
//         var largeAmount = new Money(1234567.89m, "USD");
//         Console.WriteLine($"\nLarge amount:");
//         Console.WriteLine($"Full: {largeAmount:F}");
//         Console.WriteLine($"Short: {largeAmount:S}");
//     }
// }

//3
// using System;
// using System.Runtime.InteropServices;
// using Microsoft.Win32.SafeHandles;
// // SafeHandle for file operations
// public sealed class SafeFileHandle : SafeHandleZeroOrMinusOneIsInvalid
// {
//     public SafeFileHandle() : base(true) { }

//     public SafeFileHandle(IntPtr preexistingHandle, bool ownsHandle) : base(ownsHandle)
//     {
//         SetHandle(preexistingHandle);
//     }

//     protected override bool ReleaseHandle()
//     {
//         Console.WriteLine("SafeFileHandle.ReleaseHandle() called - closing OS handle");
//         return CloseHandle(handle);
//     }

//     [DllImport("kernel32.dll", SetLastError = true)]
//     private static extern bool CloseHandle(IntPtr hObject);
// }

// // Class demonstrating Dispose pattern with SafeHandle
// public class FileProcessor : IDisposable
// {
//     private SafeFileHandle _fileHandle;
//     private bool _disposed = false;
//     private readonly string _fileName;

//     public FileProcessor(string fileName)
//     {
//         _fileName = fileName;
//         _fileHandle = CreateFileHandle(fileName);
//         Console.WriteLine($"    FileProcessor created for: {fileName}");
//         Console.WriteLine($"    Handle: 0x{_fileHandle.DangerousGetHandle():X}");
//     }

//     private SafeFileHandle CreateFileHandle(string fileName)
//     {
//         // Simulate creating a file handle (in real scenario, use File API)
//         Console.WriteLine($"    Creating simulated file handle for: {fileName}");
//         return new SafeFileHandle((IntPtr)0x1234, true); // Simulated handle
//     }

//     public void ProcessData()
//     {
//         if (_disposed)
//             throw new ObjectDisposedException(nameof(FileProcessor));

//         Console.WriteLine($"    Processing data from: {_fileName}");
//     }

//     // Dispose pattern implementation
//     protected virtual void Dispose(bool disposing)
//     {
//         Console.WriteLine($"    Dispose({disposing}) called");
        
//         if (!_disposed)
//         {
//             if (disposing)
//             {
//                 Console.WriteLine("   Cleaning up MANAGED resources");
//                 // Clean up managed resources here
//             }

//             Console.WriteLine("    Cleaning up UNMANAGED resources");
//             _fileHandle?.Dispose();
//             _fileHandle = null;

//             _disposed = true;
//         }
//     }

//     public void Dispose()
//     {
//         Console.WriteLine("Dispose() called explicitly by user");
//         Dispose(true);
//         GC.SuppressFinalize(this);
//         Console.WriteLine("   Finalizer suppressed");
//     }

//     // Finalizer (safety net)
//     ~FileProcessor()
//     {
//         Console.WriteLine("FINALIZER called by GC - Resource was NOT properly disposed!");
//         Dispose(false);
//     }
// }

// class Program
// {
//     static void Main()
//     {
//         Console.WriteLine("=== Dispose Pattern + SafeHandle Demo ===\n");

//         // Scenario 1: Proper disposal
//         Console.WriteLine("1. PROPER DISPOSAL SCENARIO:");
//         using (var processor1 = new FileProcessor("proper.txt"))
//         {
//             processor1.ProcessData();
//         } // Automatically calls Dispose()
//         Console.WriteLine("Properly disposed via 'using' statement\n");

//         // Scenario 2: Manual disposal
//         Console.WriteLine("2. MANUAL DISPOSAL SCENARIO:");
//         var processor2 = new FileProcessor("manual.txt");
//         processor2.ProcessData();
//         processor2.Dispose();
//         Console.WriteLine("Manually disposed via Dispose() method\n");

//         // Scenario 3: FORGETTING to dispose - finalizer demo
//         Console.WriteLine("3. FORGOTTEN DISPOSAL SCENARIO (Finalizer demo):");
//         CreateAndForget();
        
//         Console.WriteLine("    Forcing garbage collection for DEMONSTRATION...");
//         Console.WriteLine("    WARNING: This is for EDUCATIONAL purposes only!");
//         Console.WriteLine("    NEVER call GC.Collect() in PRODUCTION code!");
        
//         GC.Collect();
//         GC.WaitForPendingFinalizers();
        
//         Console.WriteLine("GC completed - Finalizer was called\n");

//         // Scenario 4: Using with exception handling
//         Console.WriteLine("4. EXCEPTION SAFETY SCENARIO:");
//         try
//         {
//             using (var processor3 = new FileProcessor("exception.txt"))
//             {
//                 processor3.ProcessData();
//                 throw new InvalidOperationException("Simulated exception!");
//             }
//         }
//         catch (Exception ex)
//         {
//             Console.WriteLine($"    Exception caught: {ex.Message}");
//             Console.WriteLine("    File handle was still properly disposed despite exception!");
//         }

//         Console.WriteLine("\n=== Demo Summary ===");
//         Console.WriteLine("SafeHandle automatically handles OS resource cleanup");
//         Console.WriteLine("Dispose pattern ensures timely resource release");
//         Console.WriteLine("Finalizer acts as safety net for forgotten disposal");
//         Console.WriteLine("'using' statements provide exception-safe cleanup");
//         Console.WriteLine("NEVER call GC.Collect() in production - for DEMO only!");
//     }

//     static void CreateAndForget()
//     {
//         var forgotten = new FileProcessor("forgotten.txt");
//         forgotten.ProcessData();
//         // INTENTIONALLY not calling Dispose() to demonstrate finalizer
//         Console.WriteLine("   Dispose() was NOT called - object will be finalized");
//     }
// }


//4
using System;
using System.Text.Json;

// Reference type class for demonstration
public class Address
{
    public string City { get; set; } = "";
    public string Street { get; set; } = "";
    public int Number { get; set; }

    public Address() { }

    public Address(string city, string street, int number)
    {
        City = city;
        Street = street;
        Number = number;
    }

    public override string ToString() => $"{Street} {Number}, {City}";

    public Address DeepClone()
    {
        return new Address(City, Street, Number);
    }
}

// Main class with reference fields
public class Person
{
    public string Name { get; set; } = "";
    public int Age { get; set; }
    public Address Address { get; set; }  // Reference field
    public List<string> PhoneNumbers { get; set; }  // Another reference field

    public Person()
    {
        Address = new Address();
        PhoneNumbers = new List<string>();
    }

    public Person(string name, int age, Address address, List<string> phoneNumbers)
    {
        Name = name;
        Age = age;
        Address = address;
        PhoneNumbers = phoneNumbers;
    }

    // Shallow clone using MemberwiseClone
    public Person ShallowClone()
    {
        Console.WriteLine("Creating SHALLOW clone...");
        return (Person)this.MemberwiseClone();
    }

    // Deep clone - creating new instances of reference types
    public Person DeepClone()
    {
        Console.WriteLine("Creating DEEP clone...");
        
        var clonedPerson = (Person)this.MemberwiseClone();
        
        // Create new instance of Address
        clonedPerson.Address = new Address(
            this.Address.City,
            this.Address.Street,
            this.Address.Number
        );
        
        // Create new list with copied elements
        clonedPerson.PhoneNumbers = new List<string>(this.PhoneNumbers);
        
        return clonedPerson;
    }

    // Alternative deep clone using serialization (for complex objects)
    public Person DeepCloneJson()
    {
        Console.WriteLine("Creating DEEP clone via JSON serialization...");
        var json = JsonSerializer.Serialize(this);
        return JsonSerializer.Deserialize<Person>(json)!;
    }

    public void PrintInfo(string label)
    {
        Console.WriteLine($"{label}:");
        Console.WriteLine($"  Name: {Name}");
        Console.WriteLine($"  Age: {Age}");
        Console.WriteLine($"  Address: {Address} (Hash: {Address.GetHashCode()})");
        Console.WriteLine($"  Phone Numbers: {string.Join(", ", PhoneNumbers)}");
        Console.WriteLine($"  List Reference: {PhoneNumbers.GetHashCode()}");
        Console.WriteLine();
    }
}

class Program
{
    static void Main()
    {
        Console.WriteLine("=== Shallow vs Deep Clone Demo ===\n");

        // Create original person
        var original = new Person(
            "Anna",
            25,
            new Address("Yerevan", "Abovyan", 15),
            new List<string> { "010-123456", "055-789012" }
        );

        original.PrintInfo("ORIGINAL Person");

        // SHALLOW CLONE DEMO
        Console.WriteLine("1. SHALLOW CLONE DEMONSTRATION:");
        Console.WriteLine("=" .PadRight(40, '='));
        
        var shallowCopy = original.ShallowClone();
        shallowCopy.PrintInfo("SHALLOW COPY (before modifications)");

        // Modify the shallow copy
        Console.WriteLine("MODIFYING shallow copy...");
        shallowCopy.Name = "Armen";  // Value type - affects only copy
        shallowCopy.Age = 30;        // Value type - affects only copy
        shallowCopy.Address.City = "Gyumri";  // Reference type - affects BOTH!
        shallowCopy.Address.Street = "Tigran Mets";  // Reference type - affects BOTH!
        shallowCopy.PhoneNumbers.Add("077-555555");  // Reference type - affects BOTH!

        Console.WriteLine("After modifications:");
        original.PrintInfo("ORIGINAL Person");
        shallowCopy.PrintInfo("SHALLOW COPY");
        
        Console.WriteLine("PROBLEM: Both original and copy share the SAME Address and List objects!");
        Console.WriteLine("Modifying reference types in one affects the other!\n");

        // Reset original for deep clone demo
        original.Address.City = "Yerevan";
        original.Address.Street = "Abovyan";
        original.PhoneNumbers.Remove("077-555555");

        // DEEP CLONE DEMO
        Console.WriteLine("2. DEEP CLONE DEMONSTRATION:");
        Console.WriteLine("=" .PadRight(40, '='));
        
        var deepCopy = original.DeepClone();
        deepCopy.PrintInfo("DEEP COPY (before modifications)");

        // Modify the deep copy
        Console.WriteLine("MODIFYING deep copy...");
        deepCopy.Name = "Narek";  // Value type - affects only copy
        deepCopy.Age = 35;        // Value type - affects only copy
        deepCopy.Address.City = "Vanadzor";  // Reference type - affects only copy!
        deepCopy.Address.Street = "Kirov";    // Reference type - affects only copy!
        deepCopy.PhoneNumbers.Add("094-999999");  // Reference type - affects only copy!

        Console.WriteLine("After modifications:");
        original.PrintInfo("ORIGINAL Person");
        deepCopy.PrintInfo("DEEP COPY");
        
        Console.WriteLine("SUCCESS: Original and deep copy have SEPARATE Address and List objects!");
        Console.WriteLine("Modifying reference types in one does NOT affect the other!\n");

        // JSON SERIALIZATION CLONE DEMO
        Console.WriteLine("3. JSON SERIALIZATION CLONE DEMONSTRATION:");
        Console.WriteLine("=" .PadRight(40, '='));
        
        var jsonClone = original.DeepCloneJson();
        jsonClone.PrintInfo("JSON CLONE (before modifications)");

        // Modify the JSON clone
        Console.WriteLine("MODIFYING JSON clone...");
        jsonClone.Address.City = "Dilijan";
        jsonClone.PhoneNumbers.Add("091-111111");

        Console.WriteLine("After modifications:");
        original.PrintInfo("ORIGINAL Person");
        jsonClone.PrintInfo("JSON CLONE");
        
        Console.WriteLine("JSON serialization also creates proper deep clone!\n");

        // SUMMARY
        Console.WriteLine("4. SUMMARY:");
        Console.WriteLine("=" .PadRight(40, '='));
        Console.WriteLine("SHALLOW CLONE:");
        Console.WriteLine("   - Copies value types (Name, Age)");
        Console.WriteLine("   - Copies REFERENCES to reference types (Address, List)");
        Console.WriteLine("   - Both objects share the same reference type instances");
        Console.WriteLine("   - Changes to reference types affect both objects");
        
        Console.WriteLine("\nDEEP CLONE:");
        Console.WriteLine("   - Copies value types (Name, Age)");
        Console.WriteLine("   - Creates NEW INSTANCES of reference types");
        Console.WriteLine("   - Each object has separate reference type instances");
        Console.WriteLine("   - Changes to reference types don't affect other objects");
        
        Console.WriteLine("\nDEEP CLONE (JSON):");
        Console.WriteLine("   - Uses serialization to create complete copy");
        Console.WriteLine("   - Creates completely independent object graph");
        Console.WriteLine("   - Requires serializable objects, slower performance");

        Console.WriteLine($"\nMemory addresses demonstration:");
        Console.WriteLine($"Original Address: {original.Address.GetHashCode()}");
        Console.WriteLine($"Shallow Copy Address: {shallowCopy.Address.GetHashCode()} (SAME!)");
        Console.WriteLine($"Deep Copy Address: {deepCopy.Address.GetHashCode()} (DIFFERENT!)");
        Console.WriteLine($"JSON Clone Address: {jsonClone.Address.GetHashCode()} (DIFFERENT!)");
    }
}