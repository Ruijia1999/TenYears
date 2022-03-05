using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadStartScene : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        UIController.instance.OpenUI<StartmenuUI>("Prefabs/UI/StartmenuUI");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
