using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadHomeScene : MonoBehaviour
{
   
    // Start is called before the first frame update
    void Start()
    {
        object[] args = new object[1];
        args[0] = false;
        UIController.GetInstance().OpenUI<MainUI>("Prefabs/UI/MainUI");
        UIController.GetInstance().OpenUI<MaskUI>("Prefabs/UI/MaskUI", args);
        UIController.GetInstance().OpenUI<BackpackUI>("Prefabs/UI/BackpackUI");
        UIController.GetInstance().OpenUI<InteractionUI>("Prefabs/UI/InteractionUI");
        UIController.GetInstance().OpenUI<TipUI>("Prefabs/UI/TipUI");
        UIController.GetInstance().GetUI<MaskUI>("MaskUI").StartScene();


        GameData.Instantiate();
        
        GameObject.Find("Chouti").SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
       // TimeTaskManager.Tick();
       

           

    }
}
