﻿/**
 * NodesOfYesod.cs - Nodes Of Yesod, main class
 * 
 * Changes:
 * 0.03, 14-01-2019: Main & Hardware init moved from Game. Added WelcomeScreen
 */

class NodesOfYesod
{
    static void Main()
    {
        bool fullScreen = false;
        SdlHardware.Init(1024, 768, 24, fullScreen);

        WelcomeScreen w = new WelcomeScreen();
        w.Run();

        Game g = new Game();
        g.Run();
    }
}