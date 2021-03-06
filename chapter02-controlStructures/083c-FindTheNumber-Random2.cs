// Find the hidden number (6 attempts + Random.Next)

using System;

public class HiddenNumber
{
    public static void Main()
    {
        int hidden = new Random().Next(0,101);
        int num;
        int attempts = 0;
        do
        {
            Console.Write("Enter a number: ");
            num = Convert.ToInt32(Console.ReadLine());
            
            if (num == hidden)
                Console.WriteLine("Congratulations!");
            else if (num > hidden)
                Console.WriteLine("Too Big");
            else
                Console.WriteLine("Too Small");
            
            attempts ++;
        }
        while ((num != hidden) && (attempts < 6));
        
        if (num != hidden)
            Console.WriteLine("Sorry. It was {0}", hidden);
    }
}
