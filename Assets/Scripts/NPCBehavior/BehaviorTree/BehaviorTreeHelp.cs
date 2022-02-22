using System;
using System.Xml;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Reflection;

//从xml配置文件中读取节点信息并绑定
class BehaviorTreeHelp
{


    public static void InitiateTree(NpcController i_Npc)
    {
        Type type = Type.GetType(i_Npc.npcName);
        

        
        
        XmlDocument xml = new XmlDocument();
        Queue<XmlNode> nodeList = new Queue<XmlNode>();
        Queue<BehaviorTreeNode> treenodeList = new Queue<BehaviorTreeNode>();

        xml.Load(Application.dataPath + "/Scripts/NPCBehavior/Documents/"+i_Npc.name+".xml");

        XmlNode root = xml.SelectSingleNode("BehaviorTree");
        root = root.FirstChild;
        nodeList.Enqueue(root);
        treenodeList.Enqueue(XmlNodeToTreeNode(root,  i_Npc, type));

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


    static BehaviorTreeNode NewNode(Type type, NpcController npc, string id)
    {
       
        MethodInfo method = type.GetMethod(id);
        Debug.Log(method+" "+type.Name);

        Action<object> action = (Action<object>)Delegate.CreateDelegate(typeof(Action<object>), method);

        return new BehaviorTreeNode(action, id);
    }



    static BehaviorTreeNode XmlNodeToTreeNode(XmlNode xmlNode, NpcController npc, Type type)
    {
        string actionID = xmlNode.Attributes[0].Value;
        return NewNode(type,npc,actionID);
    }
}

