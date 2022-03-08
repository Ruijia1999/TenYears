using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameData
{
    // Start is called before the first frame update

    public static RayController Ray;
    public static GameObject Naya;
    public static bool IfHasBicycle;
    public static bool IfTogether;
    public static BackpackUI backPackUI;
    private static TipUI tipUI;
    public static string currentItem = null;
    public static CameraController cameraCtrl;
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
        Ray = GameObject.Find("Ray").gameObject.GetComponent<RayController>();
        cameraCtrl = Camera.main.GetComponent<CameraController>();
        cameraCtrl.Init();

        NPCList = new Dictionary<string, NpcController>();
       
      
        //Naya = GameObject.Find("Naya").gameObject;
        

       // Naya = GameObject.Find("Criminal").gameObject;
        GameObject[] npcs = GameObject.FindGameObjectsWithTag("npc");
        foreach (GameObject npc in npcs)
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
