using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadStartScene : MonoBehaviour
{
    // Start is called before the first frame update
    bool isInit;
    void Start()
    {
        if (GameObject.Find("Canvas(Clone)") == null)
        {
            Instantiate(Resources.Load<GameObject>("Prefabs/UI/Canvas"));
        }
        isInit = false;
        
       
    }

    // Update is called once per frame
    void Update()
    {
        if (!isInit && GameObject.Find("Canvas(Clone)") != null)
        {

            object[] args = new object[1];
            args[0] = false;

            UIController.instance.OpenUI<StartmenuUI>("Prefabs/UI/StartmenuUI");
            UIController.instance.OpenUI<MaskUI>("Prefabs/UI/MaskUI", args);
            isInit = true;

        }
    }
}
