﻿/**
 * DamGame.cs - Basic Game Skeleton
 * 
 * Changes:
 * 0.02, 29-11-2018: Split into functions
 * 0.01, 01-nov-2014: Initial version, drawing player 2, enemies, 
 *   allowing the user to move to the right
 */

using System;

class Game
{
    struct typeEnemy
    {
        public int x;
        public int y;
        public int speed;
    }

    static bool fullScreen;

    static Image player;
    static int playerX, playerY, playerSpeed;
    static int playerWidth, playerHeight;

    static int numEnemies;
    static Image enemy;
    static int enemyWidth;
    static int enemyHeight;
    static typeEnemy[] enemies;

    static bool finished;

    static void Init()
    {
        fullScreen = false;

        SdlHardware.Init(1024, 768, 24, fullScreen);

        player = new Image("data/player.png");
        playerX = 50;
        playerY = 120;
        playerSpeed = 8;
        playerWidth = 32;
        playerHeight = 64;

        numEnemies = 2;
        enemies = new typeEnemy[numEnemies];

        enemy = new Image("data/enemy.png");
        enemyWidth = 64;
        enemyHeight = 64;

        finished = false;

        Random rnd = new Random();
        for (int i = 0; i < numEnemies; i++)
        {
            enemies[i].x = rnd.Next(200, 800);
            enemies[i].y = rnd.Next(50, 600);
            enemies[i].speed = rnd.Next(1, 5);
        }
    }

    static void UpdateScreen()
    {
        Font font18 = new Font("data/Joystix.ttf", 18);
        SdlHardware.ClearScreen();

        SdlHardware.WriteHiddenText("Score: ",
            40, 10,
            0xCC, 0xCC, 0xCC,
            font18);

        SdlHardware.DrawHiddenImage(player, playerX, playerY);
        for (int i = 0; i < numEnemies; i++)
            SdlHardware.DrawHiddenImage(enemy, enemies[i].x, enemies[i].y);
        SdlHardware.ShowHiddenScreen();
    }

    static void CheckUserInput()
    {
        if (SdlHardware.KeyPressed(SdlHardware.KEY_RIGHT))
            playerX += playerSpeed;
        if (SdlHardware.KeyPressed(SdlHardware.KEY_LEFT))
            playerX -= playerSpeed;
        if (SdlHardware.KeyPressed(SdlHardware.KEY_UP))
            playerY -= playerSpeed;
        if (SdlHardware.KeyPressed(SdlHardware.KEY_DOWN))
            playerY += playerSpeed;

        if (SdlHardware.KeyPressed(SdlHardware.KEY_ESC))
            finished = true;
    }

    static void UpdateWorld()
    {
        // Move enemies, background, etc 
        // TO DO
    }

    static void CheckGameStatus()
    {
        // Check collisions and apply game logic
        // TO DO
    }

    static void PauseUntilNextFrame()
    {
        SdlHardware.Pause(40);
    }

    static void UpdateHighscore()
    {
        // Save highest score
        // TO DO
    }

    static void Main(string[] args)
    {
        Init();

        do
        {
            UpdateScreen();
            CheckUserInput();
            UpdateWorld();
            PauseUntilNextFrame();
            CheckGameStatus();
        }
        while (!finished);

        UpdateHighscore();
    }
}
