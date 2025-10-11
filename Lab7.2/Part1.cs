//1
// using System;

// public partial class Person
// {
//     // Property #1
//     public string FirstName { get; set; }

//     // Property #2
//     public string LastName { get; set; }

//     public void ShowFullName()
//     {
//         Console.WriteLine($"Full Name: {FirstName} {LastName}");
//     }
// }

//2 Containment Engine
// public class Engine
// {
//     public int HorsePower { get; set; }

//     public void Start()
//     {
//         Console.WriteLine("Engine started!");
//     }
// }

//2 Inheritance animal
// public class Animal
// {
//     public string Name { get; set; }

//     public void Eat()
//     {
//         Console.WriteLine($"{Name} is eating.");
//     }
// }


//3 outer
// using System;

// public class Outer
// {
//     public string OuterName { get; set; }

//     public Outer(string name)
//     {
//         OuterName = name;
//     }

//     public void ShowOuter()
//     {
//         Console.WriteLine($"This is the outer class: {OuterName}");
//     }

//     //Nested class
//     public class Nested
//     {
//         public string NestedName { get; set; }

//         public Nested(string name)
//         {
//             NestedName = name;
//         }

//         public void ShowNested()
//         {
//             Console.WriteLine($"This is the nested class: {NestedName}");
//         }
//     }
// }

//4 animal
// using System;

// public class Animal
// {
//     public string Name { get; set; }

//     public void Eat()
//     {
//         Console.WriteLine($"{Name} is eating.");
//     }
// }

//5 Shape
// using System;

// public abstract class Shape
// {
//     public abstract double Area();
// }


