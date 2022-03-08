using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameInitManager : MonoBehaviour
{

    private void Awake()
    {
        
    }
    // Start is called before the first frame update
    void Start()
    {

        GameData.Instantiate();
        object[] args = new object[1];
        args[0] = false;
        UIController.instance.OpenUI<TipUI>("Prefabs/UI/TipUI");
        UIController.instance.OpenUI<MaskUI>("Prefabs/UI/MaskUI", args);
        UIController.instance.OpenUI<BackpackUI>("Prefabs/UI/BackpackUI");
        UIController.instance.OpenUI<MainUI>("Prefabs/UI/MainUI");
        UIController.instance.OpenUI<InteractionUI>("Prefabs/UI/InteractionUI");
    }

    // Update is called once per frame
    void Update()
    {
        TimeTaskManager.Tick();
    }
}
