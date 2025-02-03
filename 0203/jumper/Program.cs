using System;

class Game
{
    static int N = 25;
    static int[] Level = new int[N];
    static int T = 0;
    static double P = 0.15;
    static int[] Team_A = [1, 3, 5, 7, 9];
    static int[] Team_B = [2, 4, 6, 8, 10];
    static bool Exit = false;
    static ConsoleKeyInfo Input;
    static int MsTick = 1000;
    static void Main()
    {
        Prepare();
        while(!Exit)
        {
            if(Console.KeyAvailable)
            {
                Input = Console.ReadKey(true);
                if(Input.Key == ConsoleKey.Escape)
                {
                    Exit = true;
                }
            }
            Turn();
            Draw();
            Thread.Sleep(MsTick);
            T++;
        }
    }
    
    static void Prepare()
    {
        for (int i = 0; i < Level.Length; i++)
        {
            Level[i] = -1;
        }
    }

    static void Draw()
    {
        Console.BackgroundColor = ConsoleColor.Black;
        System.Console.WriteLine();
        Console.BackgroundColor = ConsoleColor.Magenta;
        System.Console.WriteLine("kör: " + T);
        for (int i = 0; i < Level.Length; i++)
        {
            Console.BackgroundColor = ConsoleColor.DarkGray;
            if(Level[i] != -1)
            {
                string Text = Level[i].ToString();
                System.Console.Write(Text[Text.Length-1]);
            }
            else
            {
                System.Console.Write("_");
            }
        }
        Console.ResetColor();
    }

    static int GetLevelPos(int x)
    {
        return Math.Clamp(x, 0, Level.Length-1);
    }

    static void Turn()
    {
        Random RNG = new Random();
        int RandomN = RNG.Next(2);
        int A = RNG.Next(0, Team_A.Length);
        int B = RNG.Next(0, Team_B.Length);
        int[] Changed = Level.Clone() as int[];
        if(RandomN < P)
        {
            //A
            if(Level[0] == -1)
            {
                Changed[0] = Team_A[A];
            }
            //B
            if(Level[Level.Length-1] == -1)
            {
                Changed[Level.Length-1] = Team_B[B];
            }
        }
        for (int i = 0; i < Level.Length; i++)
        {
            if(Level[i] != -1 && T % Level[i] == 0)
            {
                int delta = 1;
                if(Team_B.Contains(Level[i]))
                {
                    delta*=-1;
                }
                //EKKOR TUD LÉPNI
                Check:
                if(Level[GetLevelPos(i+delta)] == -1)
                {
                    Changed[GetLevelPos(i+delta)] = Level[i];
                    Changed[i] = -1;
                }
                else
                {
                    while(delta < Level[i])
                    {
                        delta++;
                        goto Check;
                    }
                }


                if(i == 1)
                {
                    if(Team_B.Contains(Level[i]))
                    {
                        Changed[i] = -1;
                    }
                }
                if(i == Level.Length-1)
                {
                    if(Team_A.Contains(Level[i]))
                    {
                        Changed[i] = -1;
                    }
                }
            }
        }
        Level = Changed;
    }
}