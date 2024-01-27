﻿namespace ImprovedMiniBars.Framework
{
    public class Database
    {
        public static string bars_theme;
        public static int distance_x;
        public static int bar_size;
        public static int player_bar_size;

        public static void GetTheme()
        {
            if (ModEntry.config.Bars_Theme == 2)
            {
                bars_theme = "Simple_Themes";
                distance_x = 15;
                bar_size = 31;
                player_bar_size = 47;
            }
            else
            {
                bars_theme = "Normal_Themes";
                distance_x = 4;
                bar_size = 20;
                player_bar_size = 34;
            }
        }
    }
}
