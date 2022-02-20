using System;
using System.Xml;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Reflection;

class BehaviorTreeHelp
{
    public static void InitiateTree(NpcController i_Npc)
    {
        Type type = Type.GetType(i_Npc.npcName);
        

        
        
        XmlDocument xml = new XmlDocument();
        Queue<XmlNode> nodeList = new Queue<XmlNode>();
        Queue<BehaviorTreeNode> treenodeList = new Queue<BehaviorTreeNode>();

        xml.Load(Application.dataPath + "/Mike.xml");

        XmlNode root = xml.SelectSingleNode("BehaviorTree");
        root = root.FirstChild;
        nodeList.Enqueue(root);
        treenodeList.Enqueue(XmlNodeToTreeNode(root, i_Npc, type));

        BehaviorTree tree = new BehaviorTree(treenodeList.Peek());
        i_Npc.m_BehaviorTree = tree;

        while (nodeList.Count != 0)
        {
            XmlNode xmlNode = nodeList.Dequeue();
            BehaviorTreeNode treeNode = treenodeList.Dequeue();

            XmlNodeList xmlnodeList = xmlNode.ChildNodes;
            foreach (XmlNode node in xmlnodeList)
            {
                nodeList.Enqueue(node);
                BehaviorTreeNode tNode = XmlNodeToTreeNode(node, i_Npc, type);
                treenodeList.Enqueue(tNode);
                treeNode.AddChild(tNode);
            }
        }


    }


    static BehaviorTreeNode NewNode(Type type, NpcController i_Npc, string id)
    {
       
        MethodInfo method = type.GetMethod(id);
        
        Action<object> action = (Action<object>)Delegate.CreateDelegate(typeof(Action<object>), i_Npc, method);

        return new BehaviorTreeNode(action, id);
    }



    static BehaviorTreeNode XmlNodeToTreeNode(XmlNode xmlNode, NpcController i_NPC, Type type)
    {
        string actionID = xmlNode.Attributes[0].Value;
        return NewNode(type, i_NPC, actionID);
    }
}

