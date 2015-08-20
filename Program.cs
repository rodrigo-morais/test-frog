using System;
using System.Collections.Generic;
using System.Linq;

public class Frog
{
    enum Way { step = 1, jump = 2 };

    private static int getWay(Way way, int n, int distance, ref string path)
    {
        var ways = 0;
        path = path + "-" + way;
        distance = distance + (int)way;

        while (distance < n)
        {
            if (distance > n)
            {
                if (way == Way.jump)
                {
                    distance = distance - (int)way;
                    way = Way.step;
                    distance = distance + (int)way;
                }

                if (distance > n)
                {
                    ways += 0;
                }
                else
                {
                    ways += getWay(way, n, distance, ref path);
                }
            }
            else
            {
                var returned = getWay(way, n, distance, ref path);
                if(returned == 1){
                    ways += returned;
                    distance = distance - (int)way;
                    way = way == Way.step ? Way.jump : Way.step;
                    distance = distance + (int)way;
                }
            }
        }

        if (distance == n)
        {
            ways += 1;
        }

        return ways;
    }

    private static bool sameWay(Way way, int n)
    {
        var distance = 0;

        while (distance < n)
        {
            distance += (int)way;
        }

        return distance == n;
    }

    private static bool differentWay(Way way, int n)
    {
        var distance = 0;
        var count = 0;

        while (distance < n)
        {
            distance += (int)way;

            if(way == Way.step){
                way = Way.jump;
            }
            else{
                way = Way.step;
            }

            count++;
        }

        return distance == n && count > 1;
    }
    
    public static int NumberOfWays(int n)
    {
        var ways = 0;

        ways += sameWay(Way.step, n) ? 1 : 0;
        ways += sameWay(Way.jump, n) ? 1 : 0;

        ways += differentWay(Way.step, n) ? 1 : 0;
        ways += differentWay(Way.jump, n) ? 1 : 0;

        var path = "";
        var x = getWay(Way.step, n, 0, ref path);
                
        return ways;
    }

    public static void Main(String[] args)
    {
        Console.WriteLine(NumberOfWays(3));
        Console.WriteLine(NumberOfWays(1));
        Console.WriteLine(NumberOfWays(2));
    }
}