using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class TimeTask
{
    private GameData _Game;//游戏总数据

    private string str_TimeTaskId;//任务id

    private long l_Interval;//任务重复时间间隔,为0不重复

    public long l_NextTick;//下一次触发的时间点


    public TimeTask(string taskID, long interval, long nextTick)
    {
        str_TimeTaskId = taskID;
        l_Interval = interval;
        l_NextTick = nextTick;
    }


    public virtual void Excute()
    {
        Debug.Log("触发");
    }
    
}
