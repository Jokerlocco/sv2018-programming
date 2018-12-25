//Kevin Marín Romero
//Navidad avanzado 01 - Banner

using System;

public class Banner
{ 
    public static void Main()
    {
       string[] body =  {
            "         ###  ### ###  # #   ##### ###   #  ##     ###  ", 
            "         ###  ### ###  # #  #  #  ## #  #  #  #    ###  ", 
            "         ###   #   # ########  #   ### #    ##      #   ", 
            "          #            # #   #####    #    ###     #    ", 
            "                     #######   #  #  # ####   # #       ", 
            "         ###           # #  #  #  # #  # ##    #        ", 
            "         ###           # #   ##### #   ### #### #       ", 
            "   ##    ##                                            #", 
            "  #        #   #   #    #                             # ", 
            " #          #   # #     #                            #  ", 
            " #          # ####### #####   ###   #####           #   ", 
            " #          #   # #     #     ###           ###    #    ", 
            "  #        #   #   #    #      #            ###   #     ", 
            "   ##    ##                   #             ###  #      ", 
            "  ###     #    #####  ##### #      ####### ##### #######", 
            " #   #   ##   #     ##     ##    # #      #     ##    # ", 
            "#     # # #         #      ##    # #      #          #  ", 
            "#     #   #    #####  ##### #    # ###### ######    #   ", 
            "#     #   #   #            ########      ##     #  #    ", 
            " #   #    #   #      #     #     # #     ##     #  #    ", 
            "  ###   ##### ####### #####      #  #####  #####   #    ", 
            " #####  #####    #     ###      #           #     ##### ", 
            "#     ##     #  ###    ###     #             #   #     #", 
            "#     ##     #   #            #     #####     #        #", 
            " #####  ######         ###   #                 #     ## ", 
            "#     #      #   #     ###    #     #####     #     #   ", 
            "#     ##     #  ###     #      #             #          ", 
            " #####  #####    #     #        #           #       #   ", 
            " #####    #   ######  ##### ###### ############## ##### ", 
            "#     #  # #  #     ##     ##     ##      #      #     #", 
            "# ### # #   # #     ##      #     ##      #      #      ", 
            "# # # ##     ####### #      #     ######  #####  #  ####", 
            "# #### ########     ##      #     ##      #      #     #", 
            "#      #     ##     ##     ##     ##      #      #     #", 
            " ##### #     #######  ##### ###### ########       ##### ", 
            "#     #  ###        ##    # #      #     ##     ########", 
            "#     #   #         ##   #  #      ##   ####    ##     #", 
            "#     #   #         ##  #   #      # # # ## #   ##     #", 
            "#######   #         ####    #      #  #  ##  #  ##     #", 
            "#     #   #   #     ##  #   #      #     ##   # ##     #", 
            "#     #   #   #     ##   #  #      #     ##    ###     #", 
            "#     #  ###   ##### #    # ########     ##     ########", 
            "######  ##### ######  ##### ########     ##     ##     #", 
            "#     ##     ##     ##     #   #   #     ##     ##  #  #", 
            "#     ##     ##     ##         #   #     ##     ##  #  #", 
            "###### #     #######  #####    #   #     ##     ##  #  #", 
            "#      #   # ##   #        #   #   #     # #   # #  #  #", 
            "#      #    # #    # #     #   #   #     #  # #  #  #  #", 
            "#       #### ##     # #####    #    #####    #    ## ## ", 
            "#     ##     ######## ##### #       #####    #          ", 
            " #   #  #   #      #  #      #          #   # #         ", 
            "  # #    # #      #   #       #         #  #   #        ", 
            "   #      #      #    #        #        #               ", 
            "  # #     #     #     #         #       #               ", 
            " #   #    #    #      #          #      #               ", 
            "#     #   #   ####### #####       # #####        #######", 
            "  ###                                                   ", 
            "  ###     ##   #####   ####  #####  ###### ######  #### ", 
            "   #     #  #  #    # #    # #    # #      #      #    #", 
            "    #   ###### #    # #      #    # #      #      #  ###", 
            "        #    # #####  #      #    # #####  #####  #     ", 
            "        #    # #    # #    # #    # #      #      #    #", 
            "        #    # #####   ####  #####  ###### #       #### ", 
            "                                                        ", 
            " #    #    #        # #    # #      #    # #    #  #### ", 
            " #    #    #        # #   #  #      ##  ## ##   # #    #", 
            " ######    #        # ####   #      # ## # # #  # #    #", 
            " #    #    #        # #  #   #      #    # #  # # #    #", 
            " #    #    #   #    # #   #  #      #    # #   ## #    #", 
            " #    #    #    ####  #    # ###### #    # #    #  #### ", 
            "                                                        ", 
            " #####   ####  #####   ####   ##### #    # #    # #    #", 
            " #    # #    # #    # #         #   #    # #    # #    #", 
            " #    # #    # #    #  ####     #   #    # #    # #    #", 
            " #####  #  # # #####       #    #   #    # #    # # ## #", 
            " #      #   #  #   #  #    #    #   #    #  #  #  ##  ##", 
            " #       ### # #    #  ####     #    ####    ##   #    #", 
            "                       ###     #     ###   ##    #######", 
            " #    #  #   # ###### #        #        # #  #  ########", 
            "  #  #    # #      #  #        #        #     ## #######", 
            "   ##      #      #  ##                 ##       #######", 
            "   ##      #     #    #        #        #        #######", 
            "  #  #     #    #     #        #        #        #######", 
            " #    #    #   ######  ###     #     ###         #######"
            };
         
        Console.Write("Enter the text: ");
        string text = Console.ReadLine();

        int[] asciiNumbers = new int[text.Length];

        for (int i = 0; i < asciiNumbers.Length; i++)
        {
            asciiNumbers[i] = Convert.ToInt32(Convert.ToChar(text[i]));
        }

        int widthNumbers = 7, heightNumbers = 7;

        string[] finalText = new string[heightNumbers];

        for (int i = 0; i < asciiNumbers.Length; i++)
        {
            int ascii = 32;
            int letters = 0, position = 0, lines = 0;
            bool isFound = false;
            int row = 0;

            while(row < body.Length)
            {
                if (letters == 8)
                {
                    row += heightNumbers-1;
                    position = 0;
                    letters = 0;
                }
                
                while(!isFound && (letters <= heightNumbers))
                {
                    if (asciiNumbers[i] != ascii)
                    {
                        ascii++;
                        letters++;
                        position += widthNumbers;
                    }
                    else
                    {
                        isFound = true;
                    }
                }
                
                if (isFound && (lines < heightNumbers))
                {
                    if (i > 0)
                    {
                        finalText[lines] = finalText[lines] + 
                            body[row].Substring(position, widthNumbers);
                    }
                    else
                    {
                        finalText[lines] = 
                            body[row].Substring(position, widthNumbers);
                    }
                    
                    lines++;
                }
                
                row++;
            }
        }
        
        for (int i = 0; i < finalText.Length; i++)
        {
            Console.WriteLine(finalText[i]);
        }
    }
}
