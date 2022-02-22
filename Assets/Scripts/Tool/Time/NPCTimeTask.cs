using System.Collections;
using System.Collections.Generic;
using System;


public class NPCTimeTask:TimeTask
{
    private string str_NpcID;

    public NPCTimeTask(string NpcID, string taskID, int interval, int nextTick): base(taskID, interval, nextTick)
    {
        str_NpcID = NpcID;
    }


    public override void Excute()
    {
        GameData.GetNPC(str_NpcID).OnTrigger();

    }
    
}
