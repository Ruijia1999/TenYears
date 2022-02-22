using System;
using System.Collections.Generic;
using UnityEngine;

public class BehaviorTree
{
    private BehaviorTreeNode RootNode;
    private BehaviorTreeNode CurrentNode;
    private BehaviorTreeNode LastNode;
    public string nextID = "Root";
    


    public BehaviorTree(BehaviorTreeNode root)
    {
        RootNode = root;
        CurrentNode = root;
        LastNode = null;
    }

    
    public void Excute(object[] args)
    {

        if (nextID.Equals("Root"))
        {
            CurrentNode = RootNode;
        }else if (nextID.Equals("Last"))
        {
            CurrentNode = LastNode;
            LastNode = null;
        }
        else
        {
            CurrentNode = CurrentNode.GetNextNode(nextID);
            LastNode = CurrentNode;
        }
        
        if (CurrentNode != null)
        {

            CurrentNode.Excute(args);
           

        }else
        {
            Debug.LogError("CurrentNode is null");
        }
        
    }
    public void SetRoot(BehaviorTreeNode node)
    {
        RootNode = node;
        CurrentNode = node;
    }
    public BehaviorTreeNode GetRoot()
    {
        return RootNode;
    }

    public BehaviorTreeNode GetCurrent()
    {
        return CurrentNode;
    }
}