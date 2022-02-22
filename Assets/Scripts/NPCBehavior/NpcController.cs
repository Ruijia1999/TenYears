using System.Collections;
using System.Collections.Generic;
using System.Xml;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
public class NpcController : MonoBehaviour
{
    public string npcName;
    public BehaviorTree m_BehaviorTree;

    //private Button btn_talk; //开始谈话的按钮
    //private Button btn_present; //使用物品进行交互的按钮
    //private GameObject go_talk;
    //private GameObject go_present;
    //private RectTransform rec_Canvas;
    //private RectTransform rec_Interaction;

    //public float height;
    // Start is called before the first frame update
    void Start()
    {
        //go_talk = transform.Find("Canvas/Interaction/Talk").gameObject;
        //btn_talk = go_talk.GetComponent<Button>();
        //go_present = transform.Find("Canvas/Interaction/Present").gameObject;
        //btn_present = go_present.GetComponent<Button>();
        //rec_Canvas = transform.Find("Canvas").GetComponent<RectTransform>();
        //rec_Interaction = transform.Find("Canvas/Interaction").GetComponent<RectTransform>();
        //GameData.Instantiate();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    //自动行走
    public void AutoMove(string nodeID)
    {
        NPCAutoWalk moveNodes = Resources.Load<NPCAutoWalk>("Scriptable/AutoMove/"+nodeID);
        Vector3[] nodes = moveNodes.Nodes;
        foreach(var node in nodes)
        {
            transform.DOMove(node, 2);
          
          
            
        }
        
    }
    public virtual void OnTrigger()
    {
        Debug.Log(npcName);
       m_BehaviorTree.Excute(null);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //go_present.SetActive(true);
        //go_talk.SetActive(true);
        
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        FollowCharacter();
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        //go_present.SetActive(false);
        //go_talk.SetActive(false); 
    }

    private void FollowCharacter()
    {
        Vector2 vec_ScreenPoint = RectTransformUtility.WorldToScreenPoint(Camera.main, transform.position+new Vector3(0,0.668f,0));

        
        //rec_Interaction.localPosition = vec_ScreenPoint - new Vector2(GameData.f_screen_width / 2, GameData.f_screen_height / 2);
    }
}
