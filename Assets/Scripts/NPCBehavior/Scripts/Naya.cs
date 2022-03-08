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

    public override void OnTrigger()
    {
        m_BehaviorTree.Excute(null);
    }
    public static void LeaveHome(object[] args)
    {
        Debug.Log("Leave home");
       
        a.Play();
    }

    
}
