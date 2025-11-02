//lab1
// using System;
// using System.Collections;

// class Program
// {
//     static void Main()
//     {
//         ArrayList numbers = new ArrayList() { 5, 2, 9, 1, 7 };

//         Console.WriteLine("Առաջին ցուցակը՝");
//         foreach (int n in numbers)
//             Console.Write(n + " ");

//         // Տեսակավորում ենք հակառակ կարգով՝ օգտագործելով custom comparer
//         numbers.Sort(new DescendingComparer());

//         Console.WriteLine("\n\nՏեսակավորված (նվազող) ցուցակը՝");
//         foreach (int n in numbers)
//             Console.Write(n + " ");
//     }
// }

// // Custom comparer՝ հակառակ կարգով տեսակավորման համար
// class DescendingComparer : IComparer
// {
//     public int Compare(object x, object y)
//     {
//         // Փոխում ենք կարգը՝ հակառակ տեսակավորման համար
//         return ((IComparable)y).CompareTo(x);
//     }
// }


//lab2
// using System;
// using System.Collections.Generic;

// class Program
// {
//     static void Main()
//     {
//         Queue<string> queue = new Queue<string>();

//         while (true)
//         {
//             Console.WriteLine("\n=== Սպասարկման համակարգ ===");
//             Console.WriteLine("1. Ավելացնել հաճախորդ");
//             Console.WriteLine("2. Սպասարկել հաջորդ հաճախորդին");
//             Console.WriteLine("3. Ցուցադրել հերթը");
//             Console.WriteLine("4. Ելք");
//             Console.Write("Ընտրիր՝ ");
//             string choice = Console.ReadLine();

//             switch (choice)
//             {
//                 case "1":
//                     Console.Write("Գրի հաճախորդի անունը՝ ");
//                     string name = Console.ReadLine();
//                     queue.Enqueue(name);
//                     Console.WriteLine($"{name} ավելացվեց հերթին։");
//                     break;

//                 case "2":
//                     if (queue.Count > 0)
//                     {
//                         string served = queue.Dequeue();
//                         Console.WriteLine($"{served} սպասարկվեց։");
//                     }
//                     else
//                     {
//                         Console.WriteLine("Հերթը դատարկ է։");
//                     }
//                     break;

//                 case "3":
//                     Console.WriteLine("\nՆերկայիս հերթը՝");
//                     if (queue.Count == 0)
//                         Console.WriteLine("Դատարկ է։");
//                     else
//                         foreach (var q in queue)
//                             Console.WriteLine("- " + q);
//                     break;

//                 case "4":
//                     Console.WriteLine("Ծրագիրը ավարտվեց։");
//                     return;

//                 default:
//                     Console.WriteLine("Սխալ ընտրություն։");
//                     break;
//             }
//         }
//     }
// }


//lab3
// using System;
// using System.Collections.Generic;

// class Program
// {
//     static void Main()
//     {
//         Stack<string> commands = new Stack<string>();

//         Console.WriteLine("=== Stack Undo Demo ===");
//         Console.WriteLine("Գրիր հրաման (օր. 'draw', 'erase', ...)");
//         Console.WriteLine("Գրիր 'undo'՝ վերջին հրամանը չեղարկելու համար");
//         Console.WriteLine("Գրիր 'exit'՝ ծրագիրը փակելու համար\n");

//         while (true)
//         {
//             Console.Write(">> ");
//             string input = Console.ReadLine()?.Trim();

//             if (string.IsNullOrEmpty(input))
//                 continue;

//             if (input.Equals("exit", StringComparison.OrdinalIgnoreCase))
//             {
//                 Console.WriteLine("Ծրագիրը ավարտվեց։");
//                 break;
//             }
//             else if (input.Equals("undo", StringComparison.OrdinalIgnoreCase))
//             {
//                 if (commands.Count > 0)
//                 {
//                     string last = commands.Pop();
//                     Console.WriteLine($"Վերջին հրամանը չեղարկվեց՝ {last}");
//                 }
//                 else
//                 {
//                     Console.WriteLine("Չկա հրաման, որը կարելի է չեղարկել։");
//                 }
//             }
//             else
//             {
//                 commands.Push(input);
//                 Console.WriteLine($"Հրամանը '{input}' պահպանվեց stack-ում։");
//             }
//         }
//     }
// }


//lab4
// using System;
// using System.Collections;

// class Program
// {
//     static void Main()
//     {
//         Hashtable phoneBook = new Hashtable();

//         phoneBook["Անի"] = "094123456";
//         phoneBook["Դավիթ"] = "099654321";
//         phoneBook["Մարիա"] = "091111111";

//         Console.WriteLine("=== Հեռախոսագիր (Phone Book) ===");
//         Console.WriteLine("Գրիր անուն՝ հեռախոսահամարը գտնելու համար");
//         Console.WriteLine("Գրիր 'add'՝ նոր մարդ ավելացնելու համար");
//         Console.WriteLine("Գրիր 'list'՝ բոլորին ցուցադրելու համար");
//         Console.WriteLine("Գրիր 'exit'՝ դուրս գալու համար\n");

//         while (true)
//         {
//             Console.Write(">> ");
//             string input = Console.ReadLine()?.Trim();

//             if (string.IsNullOrEmpty(input))
//                 continue;

//             if (input.Equals("exit", StringComparison.OrdinalIgnoreCase))
//             {
//                 Console.WriteLine("Ծրագիրը ավարտվեց։");
//                 break;
//             }
//             else if (input.Equals("add", StringComparison.OrdinalIgnoreCase))
//             {
//                 Console.Write("Գրի անունը՝ ");
//                 string name = Console.ReadLine();
//                 Console.Write("Գրի հեռախոսահամարը՝ ");
//                 string phone = Console.ReadLine();

//                 if (phoneBook.ContainsKey(name))
//                 {
//                     Console.WriteLine("Այդ անունը արդեն կա, համարը թարմացվեց։");
//                     phoneBook[name] = phone;
//                 }
//                 else
//                 {
//                     phoneBook.Add(name, phone);
//                     Console.WriteLine($"{name} ավելացվեց հեռախոսագրքում։");
//                 }
//             }
//             else if (input.Equals("list", StringComparison.OrdinalIgnoreCase))
//             {
//                 Console.WriteLine("\n=== Բոլոր գրառումները ===");
//                 foreach (DictionaryEntry entry in phoneBook)
//                     Console.WriteLine($"{entry.Key} → {entry.Value}");
//             }
//             else
//             {
//                 // Փնտրում ենք անունը
//                 if (phoneBook.ContainsKey(input))
//                 {
//                     Console.WriteLine($"{input}-ի համարը՝ {phoneBook[input]}");
//                 }
//                 else
//                 {
//                     Console.WriteLine("Այդ անունը հեռախոսագրքում չկա։");
//                 }
//             }
//         }
//     }
// }


//lab5
// using System;
// using System.Collections.Specialized;

// class Program
// {
//     static void Main()
//     {
//         OrderedDictionary students = new OrderedDictionary();

//         Console.WriteLine("=== OrderedDictionary Demo ===");
//         Console.WriteLine("Գրիր ուսանողի անուն՝ ավելացնելու համար");
//         Console.WriteLine("Գրիր 'first'՝ առաջին մուտքագրված ուսանողին տեսնելու համար");
//         Console.WriteLine("Գրիր 'list'՝ բոլոր ուսանողներին ցուցադրելու համար");
//         Console.WriteLine("Գրիր 'exit'՝ դուրս գալու համար\n");

//         int id = 1;

//         while (true)
//         {
//             Console.Write(">> ");
//             string input = Console.ReadLine()?.Trim();

//             if (string.IsNullOrEmpty(input))
//                 continue;

//             if (input.Equals("exit", StringComparison.OrdinalIgnoreCase))
//             {
//                 Console.WriteLine("Ծրագիրը ավարտվեց։");
//                 break;
//             }
//             else if (input.Equals("first", StringComparison.OrdinalIgnoreCase))
//             {
//                 if (students.Count > 0)
//                 {
//                     // Առաջին մուտքագրված ուսանողը index = 0
//                     string firstName = students[0].ToString();
//                     Console.WriteLine($"Առաջին ուսանողը՝ {firstName}");
//                 }
//                 else
//                 {
//                     Console.WriteLine("Չկան ուսանողներ։");
//                 }
//             }
//             else if (input.Equals("list", StringComparison.OrdinalIgnoreCase))
//             {
//                 Console.WriteLine("\n=== Բոլոր ուսանողները ===");
//                 foreach (string key in students.Keys)
//                     Console.WriteLine($"{key}: {students[key]}");
//             }
//             else
//             {
//                 students.Add($"student{id}", input);
//                 Console.WriteLine($"Ավելացվեց ուսանող #{id}: {input}");
//                 id++;
//             }
//         }
//     }
// }


//homework1
// using System;
// using System.Collections;

// class Program
// {
//     static void Main()
//     {
//         SortedList students = new SortedList();

//         Console.WriteLine("=== SortedList Demo ===");
//         Console.WriteLine("Գրիր ուսանողի անուն և գնահատական (օր. Անի 95)");
//         Console.WriteLine("Գրիր 'list'՝ բոլոր ուսանողներին տեսնելու համար");
//         Console.WriteLine("Գրիր 'exit'՝ դուրս գալու համար\n");

//         while (true)
//         {
//             Console.Write(">> ");
//             string input = Console.ReadLine()?.Trim();

//             if (string.IsNullOrEmpty(input))
//                 continue;

//             if (input.Equals("exit", StringComparison.OrdinalIgnoreCase))
//             {
//                 Console.WriteLine("Ծրագիրը ավարտվեց։");
//                 break;
//             }
//             else if (input.Equals("list", StringComparison.OrdinalIgnoreCase))
//             {
//                 Console.WriteLine("\n=== Sorted ըստ անունների ===");
//                 foreach (DictionaryEntry entry in students)
//                     Console.WriteLine($"{entry.Key} → {entry.Value}");
//             }
//             else
//             {
//                 // Մուտքը բաժանում ենք անունի և գնահատականի
//                 string[] parts = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
//                 if (parts.Length != 2)
//                 {
//                     Console.WriteLine("Խնդրում եմ գրիր ձևաչափով՝ [Անուն Գնահատական]");
//                     continue;
//                 }

//                 string name = parts[0];
//                 if (int.TryParse(parts[1], out int grade))
//                 {
//                     if (students.ContainsKey(name))
//                     {
//                         students[name] = grade;
//                         Console.WriteLine($"{name}-ի գնահատականը թարմացվեց՝ {grade}");
//                     }
//                     else
//                     {
//                         students.Add(name, grade);
//                         Console.WriteLine($"{name} ավելացվեց գնահատականով՝ {grade}");
//                     }
//                 }
//                 else
//                 {
//                     Console.WriteLine("Գնահատականը պետք է լինի թիվ։");
//                 }
//             }
//         }
//     }
// }


//homework2
// using System;
// using System.Collections.Generic;

// class Program
// {
//     static void Main()
//     {
//         Stack<string> undoStack = new Stack<string>();

//         string text = "";

//         Console.WriteLine("=== Text Editor Undo Demo ===");
//         Console.WriteLine("Գրիր տեքստ՝ ավելացնելու համար");
//         Console.WriteLine("Գրիր 'undo'՝ վերջին փոփոխությունը չեղարկելու համար");
//         Console.WriteLine("Գրիր 'show'՝ ներկա տեքստը ցուցադրելու համար");
//         Console.WriteLine("Գրիր 'exit'՝ դուրս գալու համար\n");

//         while (true)
//         {
//             Console.Write(">> ");
//             string input = Console.ReadLine()?.Trim();

//             if (string.IsNullOrEmpty(input))
//                 continue;

//             if (input.Equals("exit", StringComparison.OrdinalIgnoreCase))
//             {
//                 Console.WriteLine("Ծրագիրը ավարտվեց։");
//                 break;
//             }
//             else if (input.Equals("undo", StringComparison.OrdinalIgnoreCase))
//             {
//                 if (undoStack.Count > 0)
//                 {
//                     text = undoStack.Pop();
//                     Console.WriteLine("Վերջին փոփոխությունը չեղարկվեց։");
//                 }
//                 else
//                 {
//                     Console.WriteLine("Չկան undo գործողություններ։");
//                 }
//             }
//             else if (input.Equals("show", StringComparison.OrdinalIgnoreCase))
//             {
//                 Console.WriteLine($"\nՆերկա տեքստը՝ \"{text}\"\n");
//             }
//             else
//             {
//                 // Յուրաքանչյուր փոփոխությունից առաջ պահպանում ենք նախորդ տարբերակը
//                 undoStack.Push(text);
//                 text += input + " ";
//                 Console.WriteLine("Տեքստը թարմացվեց։");
//             }
//         }
//     }
// }


//homework3
// using System;
// using System.Collections.Specialized;

// class Program
// {
//     static void Main()
//     {
//         HybridDictionary products = new HybridDictionary();

//         products["milk"] = 300;
//         products["cheese"] = 1200;
//         products["bread"] = 600;
//         products["sugar"] = 500;

//         Console.WriteLine("=== HybridDictionary Product→Price Demo ===");
//         Console.WriteLine("Գրիր ապրանքի անունը՝ գինը տեսնելու համար");
//         Console.WriteLine("Գրիր 'add'՝ նոր ապրանք ավելացնելու համար");
//         Console.WriteLine("Գրիր 'list'՝ բոլոր ապրանքները ցուցադրելու համար");
//         Console.WriteLine("Գրիր 'exit'՝ դուրս գալու համար\n");

//         while (true)
//         {
//             Console.Write(">> ");
//             string input = Console.ReadLine()?.Trim();

//             if (string.IsNullOrEmpty(input))
//                 continue;

//             if (input.Equals("exit", StringComparison.OrdinalIgnoreCase))
//             {
//                 Console.WriteLine("Ծրագիրը ավարտվեց։");
//                 break;
//             }
//             else if (input.Equals("add", StringComparison.OrdinalIgnoreCase))
//             {
//                 Console.Write("Ապրանքի անունը՝ ");
//                 string name = Console.ReadLine();
//                 Console.Write("Գինը՝ ");
//                 string priceInput = Console.ReadLine();

//                 if (int.TryParse(priceInput, out int price))
//                 {
//                     products[name] = price;
//                     Console.WriteLine($"{name} ավելացվեց գներով՝ {price} դրամ։");
//                 }
//                 else
//                 {
//                     Console.WriteLine("Գինը պետք է լինի թիվ։");
//                 }
//             }
//             else if (input.Equals("list", StringComparison.OrdinalIgnoreCase))
//             {
//                 Console.WriteLine("\n=== Ապրանքների ցուցակ ===");
//                 foreach (string key in products.Keys)
//                     Console.WriteLine($"{key} → {products[key]} դրամ");
//             }
//             else
//             {
//                 if (products.Contains(input))
//                 {
//                     Console.WriteLine($"{input}-ի գինը՝ {products[input]} դրամ");
//                 }
//                 else
//                 {
//                     Console.WriteLine("Այդ ապրանքը չի գտնվել։");
//                 }
//             }
//         }
//     }
// }

//homework4
// using System;
// using System.Collections;

// class StringLengthComparer : IComparer
// {
//     public int Compare(object x, object y)
//     {
//         string a = x as string;
//         string b = y as string;

//         if (a == null || b == null)
//             throw new ArgumentException("Both arguments must be strings.");

//         // Տեսակավորում է ըստ երկարության
//         return a.Length.CompareTo(b.Length);
//     }
// }

// class Program
// {
//     static void Main()
//     {
//         ArrayList words = new ArrayList() { "apple", "kiwi", "banana", "pear", "watermelon" };

//         Console.WriteLine("Before sort:");
//         foreach (string word in words)
//             Console.WriteLine(word);

//         // Օգտագործում ենք custom comparer
//         words.Sort(new StringLengthComparer());

//         Console.WriteLine("\nAfter sort (by length):");
//         foreach (string word in words)
//             Console.WriteLine(word);
//     }
// }
