using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadHomeScene : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        UIController.instance.OpenUI<MainUI>("Prefabs/UI/MainUI");
        UIController.instance.OpenUI<MaskUI>("Prefabs/UI/MaskUI");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
