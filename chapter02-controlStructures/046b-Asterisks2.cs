// Display many asterisks (v2)

using System;

public class Asterisks2
{
    public static void Main()
    {
        Console.Write("How many asterisks? ");
        int amount = Convert.ToInt32(Console.ReadLine());
        
        int count = 0;
        while ( count < amount )
        {
            Console.Write("*");
            count = count + 1;
        }
        Console.WriteLine();
    }
}
