using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameInitManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        UIController.instance.OpenUI<BackpackUI>("Prefabs/UI/BackpackUI");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
