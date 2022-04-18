using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadStartScene : MonoBehaviour
{
    // Start is called before the first frame update

    void Start()
    {

        object[] args = new object[1];
        args[0] = false;

        UIController.GetInstance().OpenUI<StartmenuUI>("Prefabs/UI/StartmenuUI");
        UIController.GetInstance().OpenUI<MaskUI>("Prefabs/UI/MaskUI", args);
       


    }

    // Update is called once per frame
    void Update()
    {
       
           

     
    }
}
