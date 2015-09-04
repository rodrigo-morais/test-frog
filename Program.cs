using System;
using System.Collections.Generic;
using System.Linq;

public class Frog
{
    public enum Way { step = 1, jump = 2 };
    
    public static List<int> getOneStep(int n)
    {

        var path = new List<int>();

        for (var count = 0; count < n; count++)
        {
            path.Add(1);
        }

        return path;
    }

    public static List<int> addJump(List<int> path, int n)
    {
        var position = path.LastIndexOf((int)Way.step);

        if (position < 0)
        {
            return null;
        }

        path[position] = (int)Way.jump;

        if (position > 0)
        {
            path.RemoveAt(position - 1);
        }

        return path.Sum() == n ? path : null;
    }

    public static void walking(List<int> path, ref int accum)
    {
        var first = path.IndexOf((int)Way.jump);

        if (first > 0)
        {
            accum += 1;
            path[first - 1] = (int)Way.jump;
            path[first] = (int)Way.step;
            walking(path.Skip(first).Take(path.Count - first).ToList<int>(), ref accum);
            walking(new List<int>(path), ref accum);
        }
    }
    
    public static int NumberOfWays(int n)
    {
        var path = getOneStep(n);
        var accum = 1;

        while (path != null)
        {
            path = addJump(path, n);
            if (path != null)
            {
                accum++;
                walking(new List<int>(path), ref accum);
            }
        }


        return accum;
    }

    public static void Main(String[] args)
    {
        Console.WriteLine(NumberOfWays(3));
        Console.WriteLine(NumberOfWays(1));
        Console.WriteLine(NumberOfWays(2));
        Console.WriteLine(NumberOfWays(5));
        Console.WriteLine(NumberOfWays(11));

        Console.Read();
    }
}