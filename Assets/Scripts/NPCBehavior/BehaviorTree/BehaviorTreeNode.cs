using System;
using System.Collections.Generic;
using System.Collections;


public class BehaviorTreeNode
{
    public List<BehaviorTreeNode> children;


    public string nodeID;
    public readonly Action<object[]> action;

   
    public BehaviorTreeNode(Action<object[]> i_action, string i_ID)
    {
        nodeID = i_ID;
        action = i_action;
   
        children = new List<BehaviorTreeNode>();
    }

    
    public void AddChild(BehaviorTreeNode i_node)
    {
        children.Add(i_node);
    }

    public virtual void Excute(object[] args)
    {
        action.Invoke(args);
        
    }

    public BehaviorTreeNode GetNextNode(string i_ID)
    {
        foreach(BehaviorTreeNode child in children)
        {
            if (child.nodeID.Equals(i_ID))
            {
                return child;
            }
        }

        return null;
    }


}