using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameData
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


    public static Dictionary<string, NpcController> NPCList;
    public static void Instantiate()
    {
        f_screen_width = Screen.width;
        f_screen_height = Screen.height;
        NPCList = new Dictionary<string, NpcController>();
        GameObject[] npcs = GameObject.FindGameObjectsWithTag("npc");
        foreach(GameObject npc in npcs)
        {
            NpcController npcctrl = npc.GetComponent<NpcController>();
            NPCList.Add(npcctrl.npcName, npcctrl);
            BehaviorTreeHelp.InitiateTree(npcctrl);
            Debug.Log(npcctrl.npcName);
        }
    }

    public static NpcController GetNPC(string name)
    {
        return NPCList[name];

    }
}
