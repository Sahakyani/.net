//1
// using System;
// class Program
// {
//     static void Main()
//     {
//         Person person = new Person
//         {
//             FirstName = "Ani",
//             LastName = "Sahakyan",
//             Age = 21,
//             City = "Yerevan"
//         };

//         person.ShowFullName();
//         person.ShowInfo();
//     }
// }

//2Containment
// using System;
// class Program
// {
//     static void Main()
//     {
//         Car car = new Car("BMW", 250);
//         car.Drive();
//     }
// }

//2 Inheritance 
// using System;
// class Program
// {
//     static void Main()
//     {
//         Dog dog = new Dog { Name = "Buddy" };
//         dog.Eat();  // Inherited from Animal
//         dog.Bark(); // Defined in Dog
//     }
// }

//3 
// using System;
// class Program
// {
//     static void Main()
//     {
//         //Օբյեկտ արտաքին class-ից
//         Outer outer = new Outer("OuterObject");
//         outer.ShowOuter();

//         //Օբյեկտ ներքին (Nested) class-ից
//         Outer.Nested nested = new Outer.Nested("NestedObject");
//         nested.ShowNested();
//     }
// }


//4
// using System;
// class Program
// {
//     static void Main()
//     {
//         //Dog → Animal (Upcasting)
//         Dog dog = new Dog { Name = "Buddy" };
//         Animal animal = dog; // Upcasting — always safe
//         animal.Eat();
//         // animal.Bark(); չի կարելի, որովհետև Animal-ին չի պատկանում Bark()

//         //Animal → Dog (Downcasting)
//         Animal anotherAnimal = new Dog { Name = "Charlie" };
//         Dog sameDog = (Dog)anotherAnimal; // Downcast — works if actual type is Dog
//         sameDog.Bark();

//         //Սխալ Downcast
//         Animal cat = new Animal { Name = "Mittens" };
//         // Dog wrongDog = (Dog)cat; //InvalidCastException

//         //Օգտագործելով "is"
//         if (cat is Dog)
//         {
//             Console.WriteLine("cat is actually a Dog");
//         }
//         else
//         {
//             Console.WriteLine("cat is NOT a Dog");
//         }

//         //Օգտագործելով "as"
//         Dog dog2 = cat as Dog;
//         if (dog2 == null)
//         {
//             Console.WriteLine("Downcast failed: 'cat as Dog' returned null");
//         }

//         //Ճիշտ օրինակ "as"-ով
//         Animal animal2 = new Dog { Name = "Rex" };
//         Dog dog3 = animal2 as Dog; // cast succeeds
//         dog3.Bark();
//     }
// }


//5
// using System;
// class Program
// {
//     static void Main()
//     {
//         Shape s1 = new Circle(5);
//         Shape s2 = new Rectangle(4, 6);
//         Shape s3 = null;

//         Console.WriteLine(GetShapeDescription(s1));
//         Console.WriteLine(GetShapeDescription(s2));
//         Console.WriteLine(GetShapeDescription(s3));
//     }

//     //Pattern Matching switch expression
//     static string GetShapeDescription(Shape shape) =>
//         shape switch
//         {
//             Circle c when c.Radius > 0 => $"Circle with radius {c.Radius}, Area = {c.Area():F2}",
//             Rectangle r => $"Rectangle {r.Width}x{r.Height}, Area = {r.Area():F2}",
//             null => "No shape (null)",
//             _ => "Unknown shape type"
//         };
// }
