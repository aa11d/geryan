using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security.Claims;

class MS
{
    static int Width = 10;
    static int Height = 5;
    static int[,] Map = new int[Height,Width];
    static string[,] ObfMap = new string[Height,Width];

    static int Density = 10;

    static int LastX = -1;
    static int LastY = -1;

    static bool Dead = false;

    static void Main()
    {
        MakeMap();
        Draw();
        while (!Dead && !IsWinner())
        {
            Ask();
            Draw();
        }
        System.Console.WriteLine();
        Console.ResetColor();
        if(Dead)
        {
            Console.BackgroundColor = ConsoleColor.Red;
            System.Console.WriteLine("boom.");
        }
        if(IsWinner())
        {
            Console.BackgroundColor = ConsoleColor.DarkGreen;
            System.Console.WriteLine("pro gamer");
        }
        Console.ResetColor();
    }   
    static void Draw()
    {
        Console.BackgroundColor = ConsoleColor.White;
        Console.ForegroundColor = ConsoleColor.Black;
        System.Console.Write("x");
        for (int column = 0; column < Map.GetLength(1); column++)
        {
            System.Console.Write(column);
        }
        System.Console.Write("x");
        Console.ResetColor();
        System.Console.WriteLine();
        for (int y = 0; y < Map.GetLength(0); y++)
        {
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;
            System.Console.Write(y);
            Console.ResetColor();
            for (int x = 0; x < Map.GetLength(1); x++)
            {    
                if(x == LastX && y == LastY)
                {
                    Console.BackgroundColor = ConsoleColor.DarkGray;
                    if(ObfMap[y,x] == "*")
                    {
                        Console.BackgroundColor = ConsoleColor.Red;
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                }
                else
                {
                    Console.ResetColor();
                }

                Console.Write(ObfMap[y,x]);

            }
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;
            System.Console.Write(y);
            Console.ResetColor();
            System.Console.WriteLine();
        }
        Console.BackgroundColor = ConsoleColor.White;
        Console.ForegroundColor = ConsoleColor.Black;
        System.Console.Write("x");
        for (int column = 0; column < Map.GetLength(1); column++)
        {
            System.Console.Write(column);
        }
        System.Console.Write("x");
        Console.ResetColor();
        System.Console.WriteLine("\naknák: " + NumberOfMines());
    }
    static void Ask()
    {
        System.Console.WriteLine();
        System.Console.Write("X Y:");
        string[] Input = Console.ReadLine().Trim().Split(" ");
        int InputX = Math.Clamp(int.Parse(Input[0]), 0, Map.GetLength(1)-1);
        int InputY = Math.Clamp(int.Parse(Input[1]), 0, Map.GetLength(0)-1);
        LastX = InputX;
        LastY = InputY;
        if(Map[InputY, InputX] == 0)
        {
            ObfMap[InputY, InputX] = Collisions(InputX, InputY).ToString();
            if(Collisions(InputX, InputY) == 0)
            {
                Reveal(InputX, InputY);
            }   
        }
        else
        {
            ObfMap[InputY, InputX] = "*";
            Dead = true;
        }
    }

    static bool IsWinner()
    {
        for (int y = 0; y < Map.GetLength(0); y++)
        {
            for (int x = 0; x < Map.GetLength(1); x++)
            {
                if(Map[y,x] == 0 && ObfMap[y,x] == ".")
                {
                    return false;
                }
            }
        }
        return true;
    }

    static int Collisions(int posx, int posy)
    {
        int Amount = 0;
        for (int y = -1; y <= 1; y++)
        {
            for (int x = -1; x <= 1; x++)
            {
                if(posy+y >= 0 && posy+y < Map.GetLength(0) && posx+x >= 0 && posx+x < Map.GetLength(1))
                {
                    if(Map[posy+y, posx+x] != 0)
                    {
                        Amount += 1;
                    }
                }
            }   
        }

        return Amount;
    }

    static void Reveal(int posx, int posy)
    {
        for (int y = -1; y <= 1; y++)
        {
            for (int x = -1; x <= 1; x++)
            {
                int posy_c = Math.Clamp(posy+y, 0, Map.GetLength(0)-1);
                int posx_c = Math.Clamp(posx+x, 0, Map.GetLength(1)-1);
                if(ObfMap[posy_c, posx_c] == "." && Map[posy_c, posx_c] != 1)
                {
                    ObfMap[posy_c, posx_c] = Collisions(posx_c, posy_c).ToString();
                    if(Collisions(posx_c, posy_c) == 0)
                    {
                        Reveal(posx_c, posy_c);
                    }
                }
            }   
        }
    }

    static int NumberOfMines()
    {
        int Amount = 0;
        for (int y = 0; y < Map.GetLength(0); y++)
        {
            for (int x = 0; x < Map.GetLength(1); x++)
            {
                if(Map[y, x] == 1)
                {
                    Amount += 1;
                }
            }
        }
        return Amount;
    }

    static void MakeMap()
    {
        for (int y = 0; y < Map.GetLength(0); y++)
        {
            for (int x = 0; x < Map.GetLength(1); x++)
            {
                Random RNG = new Random();
                if(RNG.Next(0,100) < Density)
                {
                    Map[y, x] = 1;
                }
                else
                {
                    Map[y, x] = 0;
                }
                ObfMap[y,x] = ".";
            }
        }
    }
}