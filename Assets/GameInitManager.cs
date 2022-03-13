using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameInitManager : MonoBehaviour
{
    bool isInit;
    
    private void Awake()
    {
        
    }
    // Start is called before the first frame update
    void Start()
    {
        if (GameObject.Find("Canvas(Clone)") == null)
        {
            Instantiate(Resources.Load<GameObject>("Prefabs/UI/Canvas"));
        }
        isInit = false;

        GameData.Instantiate();
        
       
    }

    // Update is called once per frame
    void Update()
    {
        TimeTaskManager.Tick();
        if (!isInit && GameObject.Find("Canvas(Clone)") != null)
        {

            object[] args = new object[1];
            args[0] = false;
            UIController.instance.OpenUI<TipUI>("Prefabs/UI/TipUI");
            UIController.instance.OpenUI<MaskUI>("Prefabs/UI/MaskUI", args);
            UIController.instance.OpenUI<BackpackUI>("Prefabs/UI/BackpackUI");
            UIController.instance.OpenUI<MainUI>("Prefabs/UI/MainUI");
            UIController.instance.OpenUI<InteractionUI>("Prefabs/UI/InteractionUI");
            UIController.instance.OpenUI<DialogUI>("Prefabs/UI/DialogUI");
            isInit = true;

        }
    }
}
