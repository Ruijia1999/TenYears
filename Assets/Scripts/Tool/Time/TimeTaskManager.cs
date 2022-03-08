using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class TimeTaskManager 
{
    private static int i_TimeTaskAmount = 0;//总的id，需要分配给task，也就是每加如一个task，就自增

    private static long l_Tick;//总的时间，用来和task里面的nexttick变量来进行比较，看是否要触发任务

    private static List<TimeTask> _taskList;

    private static Stopwatch stopWatch;//c#自带的计时器，不会的自行百度

  
    // Start is called before the first frame update
    static TimeTaskManager()
    {
        stopWatch = new Stopwatch();
        _taskList = new List<TimeTask>();
    }

    // Update is called once per frame
    public static void Tick()
    {
        TimeTaskManager.l_Tick += (long)(stopWatch.ElapsedMilliseconds);
        
        stopWatch.Reset(); //  开始监视代码运行时间
        stopWatch.Start();

        if (i_TimeTaskAmount != 0)
        {

            for (int i = 0; i < i_TimeTaskAmount; i++)
            {
                TimeTask task= _taskList[i];
               
                if (TimeTaskManager.l_Tick >= task.l_NextTick)
                {
                    _taskList.Remove(task);
                    i_TimeTaskAmount--;
                    task.Excute();
                    
                }
            }

        }
    }

    public static void AddTask(TimeTask timeTask)
    {

        timeTask.l_NextTick += TimeTaskManager.l_Tick;
        _taskList.Add(timeTask);
        i_TimeTaskAmount++;
    }
}
