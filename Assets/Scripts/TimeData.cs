using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeData : MonoBehaviour
{
    private Dictionary<string, float> TimeNodes;
    private int nodeCount;
    // Start is called before the first frame update
    void Start()
    {
        TimeNodes = new Dictionary<string, float>();
        nodeCount = 0;
    }

    // Update is called once per frame
    void Update()
    {

        
        //foreach(string nodeKey in TimeNodes.Keys)
        //{
        //    TimeNodes[nodeKey] += Time.fixedDeltaTime;
        //}
    }

    public void AddNode(string i_nodeID)
    {
        TimeNodes.Add(i_nodeID,0);
        nodeCount++;
    }

    public void RemoveNode(string i_nodeID)
    {
        TimeNodes.Remove(i_nodeID);
        nodeCount--;
    }

    public bool IfHasInterval(string i_nodeID, float i_seconds)
    {
        if(Time.time - TimeNodes[i_nodeID] >= i_seconds)
        {
            return true;
        }
        return false;
    }
}
