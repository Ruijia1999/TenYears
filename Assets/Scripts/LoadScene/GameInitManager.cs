using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameInitManager : MonoBehaviour
{
  
    
    private void Awake()
    {
        
    }
    // Start is called before the first frame update
    void Start()
    {

        object[] args = new object[1];
        args[0] = false;
        UIController.GetInstance().OpenUI<TipUI>("Prefabs/UI/TipUI");
        UIController.GetInstance().OpenUI<MaskUI>("Prefabs/UI/MaskUI", args);
        UIController.GetInstance().OpenUI<BackpackUI>("Prefabs/UI/BackpackUI");
        UIController.GetInstance().OpenUI<MainUI>("Prefabs/UI/MainUI");
        UIController.GetInstance().OpenUI<InteractionUI>("Prefabs/UI/InteractionUI");
        UIController.GetInstance().OpenUI<DialogUI>("Prefabs/UI/DialogUI");
        UIController.GetInstance().GetUI<MaskUI>("MaskUI").StartScene();

        GameData.Instantiate();
        
       
    }

    // Update is called once per frame
    void Update()
    {
        TimeTaskManager.Tick();
       

           

    }
}
