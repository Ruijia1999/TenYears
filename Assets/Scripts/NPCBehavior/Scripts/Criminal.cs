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
        object[] args = new object[1];
        args[0] = collision.gameObject.name;
        m_BehaviorTree.Excute(args);
        
    }

    //第一次遇到人
    public static void Steal(object[] args)
    {
        string name = (string)args[0];
        Debug.Log("偷车");
        if(name.Equals("Naya"))
        GameData.GetNPC("Criminal").m_BehaviorTree.nextID = "Kill";
        else
        {
            GameData.GetNPC("Criminal").m_BehaviorTree.nextID = "Run";
        }
        GameData.GetNPC("Criminal").m_BehaviorTree.Excute(null);
    }


    //第二次遇到
    public static void Kill(object[] args)
    {

        Debug.Log("杀人");
    }
    public static void Run(object[] args)
    {

        Debug.Log("逃跑");
    }

}
