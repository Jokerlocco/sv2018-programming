// Galaxian Console

// Version + Date   Author + Changes
// --------------   --------------------------------------
// 015, 15-Nov-18   A.Navarro, C.Francés, K.Marín: several enemies (struct)
// 014, 08-Nov-18   A.Navarro, J.Rebollo: several enemies (array)
// 013, 25-Oct-18   A.Navarro, M.Isidro: collisions between fire and enemies
// 012, 18-Oct-18   I.Lazcano, J.Benajes: "fire" only when spacebar is pressed
// 011, 18-Oct-18   K.Marín A.Navarro: "fire" (always moving upwards)
// 010, 18-Oct-18   Nacho: "finished" is boolean
// 009, 11-Oct-18   María González Martínez: Two enemies
// 008, 04-Oct-18   Nacho: Slowing down
// 007, 04-Oct-18   Nacho: Simultaneous movement (too fast)
// 006, 04-Oct-18   J.Calzada, JC.Mendoza: Enemy moves to both sides (2: speed)
// 005, 04-Oct-18   S.Ruescas, S.Canovas: Enemy moves to both sides (1: flag)
// 004, 04-Oct-18   J.Rebollo, I.Lazcano: Enemy moves to the right
// 003, 27-Sep-18   J.V.Anton, D.Contreras: Console.ReadKey
// 002, 27-Sep-18   K.Marín A.Navarro: Moving the spaceship (4, 6, 0)
// 001, 26-Sep-18   Nacho: Positioning on screen, changing colors

using System;
using System.Threading;

public class GalaxianConsole
{
    struct enemy
    {
        public int x;
        public int y;
        public bool alive;
    }
    
    public static void Main()
    {
        const int SIZEENEMY = 20;
        
        enemy[] e = new enemy [SIZEENEMY];
        
        for ( int i = 0; i < SIZEENEMY; i++ )
        {
            e[i].x = 10+3*i;
            e[i].y = 10;
            e[i].alive = true;
        }
        
        int xShip = 40;
        int speedForAllEnemies = 1;
        int xFire = xShip, yFire = 21;
        int fireSpeed = 1;
        bool activeFire = false;

        ConsoleKeyInfo key;
        bool finished = false;
        int finishedCount = 0;

        do
        {
            // Draw elements
            Console.Clear();
            for(int i = 0; i < SIZEENEMY; i++)
            {
                if (e[i].alive)
                {
                    Console.SetCursorPosition(e[i].x, e[i].y);
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("W");
                }
            }

            Console.SetCursorPosition(xShip, 22);
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("A");

            if (activeFire)
            {
                Console.SetCursorPosition(xFire, yFire);
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("|");
            }

            // Process user input
            if (Console.KeyAvailable)
            {
                key = Console.ReadKey();
                if (key.Key == ConsoleKey.LeftArrow)
                    xShip = xShip - 3;
                if (key.Key == ConsoleKey.RightArrow)
                    xShip = xShip + 3;
                if (key.Key == ConsoleKey.Escape)
                    finished = true;
                if (key.Key == ConsoleKey.Spacebar)
                {
                    xFire = xShip;
                    activeFire = true;
                }
            }

            // Update world
            // First, let's move all the enemies
            for(int i = 0; i < SIZEENEMY; i++)
            {
                e[i].x = e[i].x + speedForAllEnemies;
            }
            
            // Then let's see if all of them must change direction
            for(int i = 0; i < SIZEENEMY; i++)
            {
                if (e[i].x <= 5)
                {
                    speedForAllEnemies = 1;
                }
                else if (e[i].x >= 75)
                {
                    speedForAllEnemies = -1;
                }
            }

            // Finally, let's move the fire
            if (yFire <= 2)
            {
                yFire = 21;
                activeFire = false;
            }
            if (activeFire)
                yFire = yFire - fireSpeed;

            // Check game status
            for(int i = 0; i <SIZEENEMY; i++)
            {
                if (e[i].alive && e[i].y == yFire && e[i].x == xFire)
                {
                    e[i].alive = false;
                    finishedCount++;
                }
                if (finishedCount == e.Length - 1)
                    finished = true;
            }

            // Pause until next frame
            Thread.Sleep(100);
        }
        while (!finished);

        Console.Clear();
        if (finishedCount == e.Length - 1)
            Console.WriteLine("You won!");
        else
            Console.WriteLine("You quitted :-(");
    }
}
