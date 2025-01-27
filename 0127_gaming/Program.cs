using System;
using System.Data;

class Program
{

    static ConsoleKeyInfo Input;
    static int Width = 50;
    static int Height = 25;
    static int[,] MAP_Terrain = new int[Width,Height];
    static ConsoleColor[] MAP_TerrainTypes = [ConsoleColor.Green, ConsoleColor.DarkGreen, ConsoleColor.Yellow];
    static string[,] MAP = new string[Width,Height];
    static int Turn = 0;
    static int TickRate = 10;

    static int PlayerY = MAP.GetLength(0)/2;
    static int PlayerX = MAP.GetLength(1)/2;
    static string Player = "☺";
    static int Power = 1;
    static int Level = 1;
    static void Main()
    {
        Console.Title = "hortobágy survival";
        Console.SetWindowSize(Width+1, Height+1);
        Console.SetBufferSize(Width+1, Height+1);
        Console.CursorVisible = false;
        bool Exit = false;
        Generate();
        Draw();
        while(!Exit)
        {
            if(Console.KeyAvailable)
            {
                Input = Console.ReadKey(true);
                if(Input.Key == ConsoleKey.Escape)
                {
                    Exit = true;
                }
                if(Power <= 0)
                {
                    return;
                }
                if(Input.Key == ConsoleKey.W || Input.Key == ConsoleKey.UpArrow)
                {
                    MAP[PlayerY, PlayerX] = " ";
                    PlayerX = Math.Clamp(PlayerX-1, 0, Height-1);
                    Collisions(PlayerY, PlayerX);
                    MAP[PlayerY, PlayerX] = Player;
                }
                if(Input.Key == ConsoleKey.S || Input.Key == ConsoleKey.DownArrow)
                {
                    MAP[PlayerY, PlayerX] = " ";
                    PlayerX = Math.Clamp(PlayerX+1, 0, Height-1);
                    Collisions(PlayerY, PlayerX);
                    MAP[PlayerY, PlayerX] = Player;
                }
                if(Input.Key == ConsoleKey.A || Input.Key == ConsoleKey.LeftArrow)
                {
                    MAP[PlayerY, PlayerX] = " ";
                    PlayerY = Math.Clamp(PlayerY-1, 0, Width-1);
                    Collisions(PlayerY, PlayerX);
                    MAP[PlayerY, PlayerX] = Player;
                }
                if(Input.Key == ConsoleKey.D || Input.Key == ConsoleKey.RightArrow)
                {
                    MAP[PlayerY, PlayerX] = " ";
                    PlayerY = Math.Clamp(PlayerY+1, 0, Width-1);
                    Collisions(PlayerY, PlayerX);
                    MAP[PlayerY, PlayerX] = Player;
                }
                if(Input.Key == ConsoleKey.Spacebar && Level > 1)
                {
                    Level-=1;
                    Decimate(PlayerY, PlayerX);
                }

                Draw();
                Thread.Sleep(TickRate);      
                Turn+=1;
            }
        }
    }

    static void Decimate(int sy, int sx)
    {
        for (int y = -1; y <= 1; y++)
        {
            for (int x = -1; x <= 1; x++)
            {
                if(int.TryParse(MAP[Math.Clamp(sy+y, 0, MAP.GetLength(0)-1), Math.Clamp(sx+x, 0, MAP.GetLength(1)-1)], out _))
                {
                    MAP[Math.Clamp(sy+y, 0, MAP.GetLength(0)-1), Math.Clamp(sx+x, 0, MAP.GetLength(1)-1)] = "C";
                }
            }
        }
    }
    static void Collisions(int y, int x)
    {
        string CollTarget = MAP[y, x];
        if(CollTarget == " ")
        {
            return;
        }
        else if(int.TryParse(CollTarget, out int result))
        {
            int Enemy = result;
            if(Enemy < Power)
            {
                Power -= Enemy;
                Level += 1;
            }
            else
            {
                Player = "O";
                Power = 0;
            }
        }
        else
        {
            Power += 1;
        }
    }
    static void Generate()
    {
        Random RNG = new Random();
        for (int y = 0; y < MAP.GetLength(0); y++)
        {
            for (int x = 0; x < MAP.GetLength(1); x++)
            {
                MAP_Terrain[y,x] = RNG.Next(0, 3);
                if(RNG.Next(0, 100) > 90)
                {
                    MAP[y,x] = RNG.Next(1, 10).ToString();
                }
                else if(RNG.Next(0, 100) < 8)
                {
                    MAP[y,x] = "C";
                }
                else
                {
                    MAP[y,x] = " ";
                }
            }
        }
        MAP[PlayerY, PlayerX] = Player;
    }

    static void Draw()
    {
        //Console.SetWindowSize(Width, Height);
        //Console.SetBufferSize(Width, Height);
        Console.CursorVisible = false;
        Console.Clear();
        for (int y = 0; y < MAP.GetLength(0)-1; y++)
        {
            for (int x = 0; x < MAP.GetLength(1)-1; x++)
            {
                Console.SetCursorPosition(y, x);
                Console.BackgroundColor = MAP_TerrainTypes[MAP_Terrain[y,x]];
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write(MAP[y,x]);
            }
        }
        Console.ForegroundColor = ConsoleColor.White;
        Console.BackgroundColor = ConsoleColor.Black;
        Console.SetCursorPosition(0,0);
        Console.Write(Turn);
        Console.SetCursorPosition(0,1);
        Console.Write("POW="+Power);
        Console.SetCursorPosition(0,2);
        Console.Write("LVL="+Level);
    }
}