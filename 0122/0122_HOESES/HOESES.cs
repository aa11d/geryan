using System;
using System.Security.Cryptography;
class HOHOHO{
    static int N = 10;
    static int M = 30;
    static string[,] Map = new string[N, M];

    static int Tick = 250;

    static void Main()
    {
        F_Start();
    }
    static void F_Start()
    {
        for (int y = 0; y < Map.GetLength(0); y++)
        {
            for (int x = 0; x < Map.GetLength(1); x++)
            {
                Map[y,x] = " ";
            }
        }
        while (F_CanRun())
        {
            F_Loop();
            F_AddNew(10);
            F_Draw();
            Thread.Sleep(Tick);
        }
    }

    static bool F_CanRun()
    {
        bool Filled = true;
        for (int i = 0; i < Map.GetLength(1)-1; i++)
        {
            if(Map[0, i] == " ")
            {
                Filled = false;
                break;
            }
        }
        return !Filled;
    }

    static void F_Loop()
    {
        string[,] New = Map.Clone() as string[,];
        for (int y = Map.GetLength(0)-1; y >= 0; y--)
        {
            for (int x = Map.GetLength(1)-1; x >= 0; x--)
            {
                if(Map[y,x] == "*" && y < Map.GetLength(0)-1)
                {
                    New[y,x] = " ";
                    if(New[y+1,x] == "■")
                    {
                        New[y, x] = "■";
                    }
                    else
                    {
                        New[y+1, x] = "*";
                    }
                }
                if(y == Map.GetLength(0)-1 && New[y,x] == "*")
                {
                    New[y,x] = "■";
                }
            }
        }
        Map = New;
    }
    static void F_Draw()
    {
        System.Console.WriteLine("\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n");
        for (int i = 0; i < M-1; i++)
        {
            System.Console.Write("-");
        }
        System.Console.WriteLine();
        for (int y = 0; y < Map.GetLength(0); y++)
        {
            for (int x = 0; x < Map.GetLength(1); x++)
            {
                System.Console.Write(Map[y, x]);
            }
            System.Console.WriteLine();
        }
    }
    static void F_AddNew(int percent = 10)
    {
        var RNG = new Random();
        for (int x = 0; x < M-1; x++)
        {
            var RanInt = RNG.Next(0, 100);
            if(Map[0, x] == " " && RanInt <= percent)
            {
                Map[0, x] = "*";
            }
        }
    }
}