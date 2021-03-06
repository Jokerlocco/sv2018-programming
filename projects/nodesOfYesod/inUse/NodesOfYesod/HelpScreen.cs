﻿/**
 * HelpScreen.cs - Nodes Of Yesod, Help screen
 * 
 * Changes:
 * 0.13, 15-02-2019: The user can move a player in the help screen -> scroll
 * 0.10, 08-02-2019: Displays the background image and some text
 * 0.03, 14-01-2019: Help screen created (empty skeleton)
 */

class HelpScreen
{
    public void Run()
    {
        string[] text =
        {
            "Use arrow keys to move right or left",
            "Use spacebar to jump",
            "Arrows + spacebar to jump sidewards",
            "Beware of the moving enemies",
            "Press Q to quit the game",
            " ",
            "Press R to Return"
        };

        Image background = new Image("data/help.png");
        Font font18 = new Font("data/Joystix.ttf", 18);

        Player player = new Player();
        player.MoveTo(510, 558);
        short playerSpeed = 4;

        byte grey = 200;
        short x = 300;
        short y = 250;
        short spacing = 40;

        do
        { 
            // Draw items on screen
            SdlHardware.ClearScreen();
            SdlHardware.DrawHiddenImage(background, 0, 0);
            

            grey = 200;
            y = 250;
            for (int i = 0; i < text.Length; i++)
            {
                SdlHardware.WriteHiddenText(text[i],
                    x, y,
                    grey, grey, grey,
                    font18);
                grey -= 20;
                y += spacing;
            }
            player.DrawOnHiddenScreen();
            SdlHardware.ShowHiddenScreen();

            // Animate the player (it is must fall or jump)
            player.Move();

            // Get user input to move the player as desired

            if (SdlHardware.KeyPressed(SdlHardware.KEY_RIGHT)
                && (player.GetX() < 700))
            {
                player.ChangeDirection(Sprite.RIGHT);
                SdlHardware.ScrollHorizontally((short) (-playerSpeed));
                player.MoveTo(player.GetX() + playerSpeed, player.GetY());
                player.NextFrame();
            }
            if (SdlHardware.KeyPressed(SdlHardware.KEY_LEFT)
                && (player.GetX() > 300))
            {
                player.ChangeDirection(Sprite.LEFT);
                SdlHardware.ScrollHorizontally(playerSpeed);
                player.MoveTo(player.GetX() - playerSpeed, player.GetY());
                player.NextFrame();
            }

            // And pause (25 fps)
            SdlHardware.Pause(40);
        }
        while (!SdlHardware.KeyPressed(SdlHardware.KEY_R));
        SdlHardware.ResetScroll();
    }
}

