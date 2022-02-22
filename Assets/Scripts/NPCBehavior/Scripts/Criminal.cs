using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Criminal : NpcController
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        m_BehaviorTree.Excute(null);
        
    }

    //第一次遇到人
    public static void Steal(object args)
    {
        
        Debug.Log("偷车");
        
    }


    //第二次遇到
    public static void Kill(object args)
    {

        Debug.Log("杀人");
    }
    public static void Run(object args)
    {

        Debug.Log("逃跑");
    }

}
