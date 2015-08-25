using System;
using System.Collections.Generic;
using System.Linq;

public class Frog
{
    enum Way { step = 1, jump = 2 };
    
    private static List<int> getOneStep(int n){

        var path = new List<int>();

        for (var count = 0; count < n; count++)
        {
            path.Add(1);
        }

        return path;
    }

    private static List<List<int>> replaceStepsToJumps(List<int> original, int n)
    {
        var paths = new List<List<int>>();

        paths.Add(original);
        
        for (var count = 0; count < original.Count - 1; count++)
        {
            var next = count;
            var path = new List<int>(original);
            
            while (next < path.Count - 1)
            {
                if (path.Count >= next + 1)
                {
                    path.Insert(next, (int)Way.jump);
                    path.RemoveAt(next + 1);
                    path.RemoveAt(next + 1);
                    
                    paths.Add(path);
                }

                next += 1;
            }

        }

        var reverses = new HashSet<List<int>>(paths);
        foreach (var list in reverses)
        {
            var newList = list.Reverse<int>().ToList<int>();
            var isNew = true;
            var count = 0;

            while (isNew && count < paths.Count)
            {
                if(newList.SequenceEqual(paths.ElementAt(count)))
                {
                    isNew = false;
                }
                count++;
            }

            if (isNew)
            {
                paths.Add(newList);
            }
        }

        return paths;
    }
    
    public static int NumberOfWays(int n)
    {
        var paths = new List<List<int>>();
        var original = getOneStep(n);
        paths.Add(original);
        paths = replaceStepsToJumps(original, n);
           
        return paths.Count;
    }

    public static void Main(String[] args)
    {
        Console.WriteLine(NumberOfWays(3));
        Console.WriteLine(NumberOfWays(1));
        Console.WriteLine(NumberOfWays(2));
        Console.WriteLine(NumberOfWays(5));
        Console.WriteLine(NumberOfWays(11));
    }
}