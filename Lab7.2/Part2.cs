//1
// public partial class Person
// {
//     // Property #3
//     public int Age { get; set; }

//     // Property #4
//     public string City { get; set; }

//     public void ShowInfo()
//     {
//         Console.WriteLine($"Age: {Age}, City: {City}");
//     }
// }

//2 Containment Car
// public class Car
// {
//     // Containment: Car has an Engine
//     public Engine Engine { get; set; }
//     public string Model { get; set; }

//     public Car(string model, int hp)
//     {
//         Model = model;
//         Engine = new Engine { HorsePower = hp };
//     }

//     public void Drive()
//     {
//         Engine.Start();
//         Console.WriteLine($"{Model} is driving with {Engine.HorsePower} HP.");
//     }
// }


//2 Inheritance dog
// public class Dog : Animal
// {
//     public void Bark()
//     {
//         Console.WriteLine($"{Name} is barking!");
//     }
// }

//4 dog
// using System;

// public class Dog : Animal
// {
//     public void Bark()
//     {
//         Console.WriteLine($"{Name} is barking!");
//     }
// }

//5 circle
// using System;

// public class Circle : Shape
// {
//     public double Radius { get; set; }

//     public Circle(double radius)
//     {
//         Radius = radius;
//     }

//     public override double Area() => Math.PI * Radius * Radius;
// }

