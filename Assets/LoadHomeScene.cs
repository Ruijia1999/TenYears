using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadHomeScene : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        object[] args = new object[1];
        args[0] = true;
        UIController.instance.OpenUI<MainUI>("Prefabs/UI/MainUI");
        UIController.instance.OpenUI<MaskUI>("Prefabs/UI/MaskUI", args);
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
