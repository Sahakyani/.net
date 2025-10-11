using System; 
using System.Threading; 
 
class Program 
{ 
    static void Main() 
    { 
        Console.Clear(); 
 
        Console.ForegroundColor = ConsoleColor.Cyan; 
        Console.WriteLine("Մուտքագրեք ուղղանկյան տվյալները․"); 
 
        Console.Write("Լայնություն: "); 
        int width = int.Parse(Console.ReadLine()); 
 
        Console.Write("Բարձրություն: "); 
        int height = int.Parse(Console.ReadLine()); 
 
        Console.Write("Սկզբնական X կոորդինատ (Left): "); 
        int startX = int.Parse(Console.ReadLine()); 
 
        Console.Write("Սկզբնական Y կոորդինատ (Top): "); 
        int startY = int.Parse(Console.ReadLine()); 
 
        Console.Clear(); 
 
        // Գույների զանգված 
        ConsoleColor[] colors =  
        { 
            ConsoleColor.Red, 
            ConsoleColor.Green, 
            ConsoleColor.Yellow, 
            ConsoleColor.Blue, 
            ConsoleColor.Magenta, 
            ConsoleColor.Cyan, 
            ConsoleColor.White 
        }; 
 
        int colorIndex = 0; // սկզբնական գույնի ինդեքսը 
 
        // --- Վերին կողմ --- 
        Console.SetCursorPosition(startX, startY); 
        for (int i = 0; i < width; i++) 
        { 
            Console.ForegroundColor = colors[colorIndex % colors.Length]; 
            Console.Write("*"); 
            colorIndex++; 
            Thread.Sleep(30); 
        } 
 
        // --- Աջ կողմ --- 
        for (int i = 1; i < height; i++) 
        { 
            Console.SetCursorPosition(startX + width - 1, startY + i); 
            Console.ForegroundColor = colors[colorIndex % colors.Length]; 
            Console.Write("*"); 
            colorIndex++; 
            Thread.Sleep(30); 
        } 
 
        // --- Ստորին կողմ --- 
        Console.SetCursorPosition(startX, startY + height - 1); 
        for (int i = 0; i < width; i++) 
        { 
            Console.ForegroundColor = colors[colorIndex % colors.Length]; 
            Console.Write("*"); 
            colorIndex++; 
            Thread.Sleep(30); 
        } 
 
        // --- Ձախ կողմ --- 
        for (int i = 1; i < height; i++) 
        { 
            Console.SetCursorPosition(startX, startY + i); 
            Console.ForegroundColor = colors[colorIndex % colors.Length]; 
            Console.Write("*"); 
            colorIndex++; 
            Thread.Sleep(30); 
        } 
 
        // Նոր տող 
        Console.WriteLine(); 
 
        // Արդյունքի տեքստ 
        Console.ForegroundColor = ConsoleColor.Yellow; 
        Console.WriteLine("Ուղղանկյունը հաջողությամբ արտածվեց։"); 
 
        Console.ResetColor(); 
    } 
} 
