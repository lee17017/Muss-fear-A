using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameData {
    public static bool ControllerActive = false;
    private static int LevelLast;
    public static int DLC_Limit=4;

    public static bool controlled()
    {
        return ControllerActive;
    }

    public static void setLevel(int Level)//Main Levelauswahl -> setLevel(LevelID) //Level->Win/Lose Lose-> Menu Win -> Next/Menü
    {
        LevelLast = Level;
    }

    public static int getLast()
    {
        return LevelLast;
    }
}
