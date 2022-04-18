using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Naya : NpcController
{
     static Animation a;
   
    // Start is called before the first frame update
    void Start()
    {
        //m_BehaviorTree.nextID = "LeaveHome";
        //AutoMove("Naya_0");
       a = transform.GetComponent<Animation>();
     
        TimeTask task = new NPCTimeTask("Naya","Naya_chufa", 0, 5000);
        TimeTaskManager.AddTask(task);
        
        
        // b.GetCurrentAnimatorStateInfo(0)
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
    public override void OnTrigger()
    {
        object[] args = new object[1];

        m_BehaviorTree.Excute(null);
       
    }

    //第一次遇到人
    public static void Meet_1(object[] args)
    {

        string name = (string)args[0];
        Debug.Log(name);
        if (name.Equals("Criminal"))
        {
            GameData.GetNPC("Naya").m_BehaviorTree.nextID = "Die";
            GameData.GetNPC("Naya").m_BehaviorTree.Excute(null);
        }
        else if (name.Equals("Ray"))
        {
            GameData.GetNPC("Naya").m_BehaviorTree.nextID = "MeetRay";
            GameData.GetNPC("Naya").m_BehaviorTree.Excute(null);
        }
        else
        {
            GameData.GetNPC("Naya").m_BehaviorTree.nextID = "Self";
            
        }
       
    }
    public static void LeaveHome(object[] args)
    {
        
        Debug.Log("Leave home");
        GameData.GetNPC("Naya").m_BehaviorTree.nextID = "next";
        a.Play();
    }

    public static void Die(object[] args)
    {
       
        Debug.Log("Die");

    }
    public static void MeetRay(object[] args)
    {
       
        Debug.Log("MeetRay");
        Vector3 tr = GameData.GetNPC("Naya").transform.position;
        a.Stop();
        GameData.GetNPC("Naya").transform.position = tr;
        UIController.GetInstance().GetUI<DialogUI>("DialogUI").StartDialog("");

    }

    public static void ArriveSchool(object[] args) {
        string name = (string)args[0];

        if (name.Equals("School"))
        {
            GameData.GetNPC("Naya").m_BehaviorTree.nextID = "Next";
            GameData.GetNPC("Naya").m_BehaviorTree.Excute(null);
        }
        else
        {
            GameData.GetNPC("Naya").m_BehaviorTree.nextID = "Self";
          
        }
       
    }
}
