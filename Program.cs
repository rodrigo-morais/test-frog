using System;
using System.Collections.Generic;
using System.Linq;

public class Frog
{
    public enum Way { step = 1, jump = 2 };
    /*
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

    public static void walkingInThePath(int position, List<int> path, ref List<string> paths)
    {
        while (position < path.Count - 1)
        {
            var newPath = new List<int>(path);

            newPath.Insert(position, (int)Way.step);
            newPath.Insert(position + 1, (int)Way.step);
            newPath.RemoveAt(position + 2);

            var strPath = string.Join(",", newPath);

            if (paths.Exists(s => s == strPath) == false)
            {
                paths.Add(strPath);
            }

            position += 2;
        }
    }

    public static void replacePath(List<int> original, int n, Way type, ref List<string> paths)
    {
        if (paths.Exists(s => s == string.Join(",", original)) == false)
        {
            paths.Add(string.Join(",", original));
        }
        
        for (var count = 0; count < original.Count - 1; count++)
        {
            var next = count;
            var path = new List<int>(original);
                        
            while (next < path.Count - 1)
            {
                if (path.Count >= next + 1)
                {
                    if (type == Way.step)
                    {
                        path.Insert(next, (int)Way.jump);
                        path.RemoveAt(next + 1);
                        path.RemoveAt(next + 1);
                    }
                    else
                    {
                        path.Insert(next, (int)Way.step);
                        path.Insert(next + 1, (int)Way.step);
                        path.RemoveAt(next + 2);
                    }

                    var strPath = string.Join(",", path);

                    if (paths.Exists(s => s == strPath) == false)
                    {
                        paths.Add(strPath);
                    }

                    if (type == Way.step)
                    {
                        jumpingInThePath(next + 1, path, ref paths);
                        next += 1;
                    }
                    else
                    {
                        walkingInThePath(next + 2, path, ref paths);
                        next += 2;
                    }
                }
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
    }

    private static void print(List<string> paths)
    {
        foreach (var s in paths.OrderByDescending(s => s).ToList())
        {
            Console.WriteLine(s);
        }
        Console.Read();
    }

    public static void replacePath(List<int> path, ref int acum)
    {
        Console.WriteLine(string.Join(",", path));

        if (path.LastIndexOf((int)Way.step) <= 0 && path.Count > 1)
        {
            acum += 1;
        }
        else if(path.Count > 1)
        {
            var position = path.LastIndexOf((int)Way.step);
            path[position] = (int)Way.jump;
            path.RemoveAt(position - 1);
            replacePath(path, ref acum);
        }

    }
    */

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

    public static void walkingOnThePath(List<int> path, ref int accum){
        var lastStep = path.LastIndexOf((int)Way.step);

        if (path.Count > 1 && lastStep >= 0)
        {
            if (lastStep == path.Count - 1)
            {
                path.RemoveAt(lastStep);
                walkingOnThePath(path, ref accum);
            }
            else
            {
                var oldPath = new List<int>(path);
                accum = accum + 1;
                path[lastStep] = (int)Way.jump;
                path[lastStep + 1] = (int)Way.step;
                Console.WriteLine(string.Join(",", path));
                walkingOnThePath(path, ref accum);
            }
        }
    }
    
    public static int NumberOfWays(int n)
    {
        Console.WriteLine("Tamanho: " + n);

        var path = getOneStep(n);
        var accum = 1;

        Console.WriteLine(string.Join(",", path));

        while (path != null)
        {
            path = addJump(path, n);
            if (path != null)
            {
                Console.WriteLine(string.Join(",", path));
                accum++;
                walkingOnThePath(new List<int>(path), ref accum);
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