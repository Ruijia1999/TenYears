using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    // Start is called before the first frame update

    void Init()
    {
       

    }
    void Start()
    {
        Debug.Log("aaaa");
        GameData.Instantiate();


    }

    // Update is called once per frame
    void Update()
    {
       
       
        TimeTaskManager.Tick();
    }
}
