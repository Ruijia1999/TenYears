using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameData
{
    // Start is called before the first frame update
    public static PlayerController player;
    public static BackPack backPack;
    public static Item currentItem;

    public static int level;
    public static bool isAccompanied;
    public static bool isRiding;

    public static float f_screen_width;
    public static float f_screen_height;
    public static float f_screen_width_ratio;
    public static float f_screen_height_ration;

    public static void Instantiate()
    {
        f_screen_width = Screen.width;
        f_screen_height = Screen.height;
    }


}
