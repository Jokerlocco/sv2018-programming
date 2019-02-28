// Comparing two (big) lists of words (354,985 words vs 235,886)
// Ivan Lazcano

// V2: SortedList
// Time taken: near 0.88sec on i7 7700HQ

using System;
using System.IO;
using System.Collections;

class ComparatorV1
{

    public  static void Main()
    {
        int differences = 0;
        
        Console.WriteLine("Loading...");
        string[] s1 = File.ReadAllLines("words.txt");
        string[] s2 = File.ReadAllLines("words2.txt");

        Console.WriteLine("Populating lists...");
        SortedList l1 = new SortedList();
        SortedList l2 = new SortedList();
        foreach(string s in s1 )
            if (! l1.Contains(s))
                l1.Add(s, s);
        foreach(string s in s2 )
            if (! l2.Contains(s))
                l2.Add(s, s);
        
        Console.WriteLine("Finding differences...");
        DateTime start = DateTime.Now;
        foreach(string s in l1.Keys)
        {
            if (!l2.Contains(s))
                differences++;
        }
        
        Console.WriteLine();
        Console.WriteLine("Differences: " + differences);
        Console.WriteLine("Time taken: " + (DateTime.Now - start));
    }
}
