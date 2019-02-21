﻿// Galaxian SDL

// Version + Date   Author + Changes
// --------------   --------------------------------------
// 015, 21-Feb-19   Marín + Rebollo: Cheats
// 014, 21-Feb-19   Ivan y Pablo: Ships move with joystick
// 013, 21-Feb-19   Sergio y Diego: Use Enemy class
// 010, 21-Feb-19   Ivan y Pablo: Ships move with mouse
// 009, 21-Feb-19   Nacho: Static background
// 008, 04-Ene-19   Nacho: Class created, content extracted from GalaxianSDL
// 007, 06-Dic-18   S. Ruescas: Score, Welcome, EndSCreen, 2 sprites for enemies
// 006, 05-Dic-18   Nacho: Functions
// 005, 15-Nov-18   A.Navarro, C.Francés, K.Marín: Many enemies (struct)
// 004, 09-Nov-18   María Gonzáles: Many enemies
// 003, 25-Oct-18   Ivan Lazcano: Game can end, fire, enemies can die
// 002, 11-Oct-18   Jorge Calzada: Two enemys
// 001, 08-Oct-18   Nacho: Almost empty skeleton

class Game
{
    const int SIZEENEMY = 20;

    int speedForAllEnemies;
    int xShip, yShip;
    int xEnemy, yEnemy;
    int xFire, yFire, fireSpeed;
    bool activeFire, finished;
    int aliveEnemies;
    int score;
    int spriteCount;
    bool activeMouse;
    bool activeJoystick;

    Image shipImage;
    Image enemyImage;
    Image enemyImage2;
    Image fireImage;
    Image backgroundImage;
    Font font18;
    Enemy[] e;

    string cheatInfo;
    int cheatTime;

    public Game()
    {
        activeMouse = false;
        activeJoystick = false;
        xShip = 500;
        yShip = 500;

        const int SIZEENEMY = 20;
        e = new Enemy[SIZEENEMY];

        for (int i = 0; i < SIZEENEMY; i++)
        {
            if (i % 2 == 0)
                yEnemy = 200;
            else
                yEnemy = 300;

            xEnemy = 100 + 30 * i;
            e[i] = new Enemy(xEnemy, yEnemy);
        }

        speedForAllEnemies = 3;

        xFire = xShip;
        yFire = yShip + 25;
        fireSpeed = 5;
        activeFire = false;
        finished = false;
        aliveEnemies = SIZEENEMY;
        score = 0;
        spriteCount = 0;

        shipImage = new Image("data/ship.png");//45x51p
        enemyImage = new Image("data/enemy1a.png");//33x24p
        enemyImage2 = new Image("data/enemy1b.png");//33x24p
        fireImage = new Image("data/fire.png");//3x12p
        font18 = new Font("data/Joystix.ttf", 18);
        backgroundImage = new Image("data/background.png");
    }


    public void DrawElements()
    {
        SdlHardware.ClearScreen();

        SdlHardware.DrawHiddenImage(backgroundImage, 100, 50);

        SdlHardware.WriteHiddenText(("Score: " + score),
                40, 10,
                0xCC, 0xCC, 0xCC,
                font18);

        if (cheatTime > 0)
        {
            SdlHardware.WriteHiddenText(cheatInfo,
                   40, 720,
                   0xCC, 0xCC, 0xCC,
                   font18);
            cheatTime--;
        }

        for (int i = 0; i < SIZEENEMY; i++)
        {
            if (e[i].IsVisible())
            {
                if (spriteCount > 0)
                    SdlHardware.DrawHiddenImage(enemyImage, e[i].GetX(), e[i].GetY());
                else
                    SdlHardware.DrawHiddenImage(enemyImage2, e[i].GetX(), e[i].GetY());
            }
        }

        SdlHardware.DrawHiddenImage(shipImage, xShip, yShip);

        if (activeFire)
            SdlHardware.DrawHiddenImage(fireImage, xFire, yFire);


        SdlHardware.ShowHiddenScreen();
    }


    public void ProcessUserInput()
    {
        if (SdlHardware.KeyPressed(SdlHardware.KEY_ESC))
            finished = true;
        if (SdlHardware.KeyPressed(SdlHardware.KEY_RIGHT)
            || SdlHardware.JoystickMovedRight())
            xShip += 10;
        if (SdlHardware.KeyPressed(SdlHardware.KEY_LEFT)
            || SdlHardware.JoystickMovedLeft())
            xShip -= 10;
        if ((SdlHardware.KeyPressed(SdlHardware.KEY_SPC)
             || SdlHardware.JoystickMovedUp()
             || (SdlHardware.MouseClicked() && activeMouse))
            && (!activeFire))
        {
            activeFire = true;
            xFire = xShip + 21;//Fires from the center of the ship
            yFire = yShip + 1;
        }

        if (SdlHardware.KeyPressed(SdlHardware.KEY_T))
        {
            if (SdlHardware.KeyPressed(SdlHardware.KEY_V))
                ApplyCheat('V');
            if (SdlHardware.KeyPressed(SdlHardware.KEY_N))
                ApplyCheat('N');
            if (SdlHardware.KeyPressed(SdlHardware.KEY_R))
                ApplyCheat('R');
            if (SdlHardware.KeyPressed(SdlHardware.KEY_P))
                ApplyCheat('P');
            if (SdlHardware.KeyPressed(SdlHardware.KEY_D))
                ApplyCheat('D');
        }

        if (activeMouse)
            xShip = SdlHardware.GetMouseX();

        if (SdlHardware.KeyPressed(SdlHardware.KEY_O))
        {
            if (activeMouse)
            {
                activeMouse = false;
                activeJoystick = true;
            }
            else if (activeJoystick)
            {
                activeJoystick = false;
            }
            else
                activeMouse = true;
        }


    }

    public void ApplyCheat(char code)
    {
        switch (code)
        {
            case 'V':
                //TO DO...
                break;
            case 'N':
                //TO DO...
                break;
            case 'R':
                cheatInfo = "Despacito y con buena letra";
                foreach (Enemy ene in e)
                    ene.SetSpeed(1, 1);
                break;
            case 'P':
                cheatInfo = "Vamos a poner esto por aqui...";
                score += 1000;
                break;
            case 'D':
                cheatInfo = "¡Paro! Espera, ¿esto no era Final Fantasy?";
                foreach (Enemy ene in e)
                    ene.SetSpeed(0,0);
                break;
        }
        cheatTime = 40;
    }

    public void UpdateWorld()
    {
        for (int i = 0; i < SIZEENEMY; i++)
        {
            if (e[i].IsVisible())
                e[i].Move();
        }

        if (yFire <= 2)
        {
            yFire = 21;
            activeFire = false;
        }
        if (activeFire)
            yFire -= fireSpeed;
        spriteCount++;
        if (spriteCount > 20)
            spriteCount = -20;
    }


    public void CheckGameStatus()
    {
        if (yFire < 20)  //  Fire must disappear?
            activeFire = false;

        for (int i = 0; i < SIZEENEMY; i++)  // Fire hits any enemy?
            if (activeFire && e[i].IsVisible() &&
                (e[i].GetX() < (xFire + 3) && (e[i].GetX() + 33) > xFire) &&
                ((e[i].GetY() + 24) > yFire && (e[i].GetY() < (yFire + 12))))
            {
                e[i].Hide();
                activeFire = false;
                aliveEnemies--;
                score += 10;
                if (aliveEnemies == 0)
                    finished = true;
            }
    }


    public void PauseUntilNextFrame()
    {
        SdlHardware.Pause(20);
    }


    public void Run()
    {
        do
        {
            DrawElements();
            ProcessUserInput();
            UpdateWorld();
            CheckGameStatus();
            PauseUntilNextFrame();
        }
        while (!finished);
    }

}
