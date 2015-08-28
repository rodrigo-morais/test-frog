using System;
using System.Collections.Generic;
using System.Linq;

public class Frog
{
    enum Way { step = 1, jump = 2 };
    
    public static List<int> getOneStep(int n){

        var path = new List<int>();

        for (var count = 0; count < n; count++)
        {
            path.Add(1);
        }

        return path;
    }

    public static void jumpingInThePath(int position, List<int> path, ref List<string> paths)
    {
        while (position < path.Count - 1)
        {
            var newPath = new List<int>(path);

            newPath.Insert(position, (int)Way.jump);
            newPath.RemoveAt(position + 1);
            newPath.RemoveAt(position + 1);

            var strPath = string.Join(",", newPath);

            if (paths.Exists(s => s == strPath) == false)
            {
                paths.Add(strPath);
            }

            position++;
        }
    }

    public static List<string> replaceStepsToJumps(List<int> original, int n)
    {
        var paths = new List<string>();

        paths.Add(string.Join(",", original));
        
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

                    var strPath = string.Join(",", path);

                    if (paths.Exists(s => s == strPath) == false)
                    {
                        paths.Add(strPath);
                    }

                    jumpingInThePath(next + 1, path, ref paths);
                }

                next += 1;
            }

        }

        var reverses = new List<string>(paths);
        foreach (var list in reverses)
        {
            var newList = new string(list.Reverse().ToArray());

            if(paths.Exists(s => s == newList) == false)
            {
                paths.Add(newList);
            }
        }

        return paths;
    }

    private static void print(List<string> paths)
    {
        foreach (var s in paths.OrderByDescending(s => s).ToList())
        {
            Console.WriteLine(s);
        }
        Console.Read();
    }
    
    public static int NumberOfWays(int n)
    {
        var paths = new List<string>();
        var original = getOneStep(n);
        paths = replaceStepsToJumps(original, n);

        if (n == 11)
        {
            print(paths);
        }
           
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