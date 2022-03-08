using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
public enum PropType
{
    picked,
    condition_picked,
    interactable
}
public class PropBase : MonoBehaviour
{
    public PropType propType;
    public string str_propID;
    private GameObject go_Tip;
    private Button btn_Tip;
    private Text txt_Condition;
    public string str_Condition;
    private GameObject Tip; //互动标志
  //  public string str_ConditionProp;
    private Texture2D txture_prop;

    public OnGet onGetEvent;
    [Serializable]
    public class OnGet : UnityEvent { }

    public OnCheck onCehckConditionsEvent;
    [Serializable]

    public class OnCheck : UnityEvent { }

    public OnNear onNearEvent;
    [Serializable]

    public class OnNear : UnityEvent { }

    public OnFar onFarEvent;
    [Serializable]

    public class OnFar : UnityEvent { }

    // Start is called before the first frame update
    void Start()
    {
       // tipUI = GameObject.Find("Canvas/Tip").GetComponent<TipUI>();
        // go_Tip = transform.Find("Tip").gameObject;
        //  btn_Tip = go_Tip.GetComponent<Button>();
        //  btn_Tip.onClick.AddListener(OnClick);
        txture_prop = transform.GetComponent<SpriteRenderer>().sprite.texture;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
   
        if (propType == PropType.interactable && collision.gameObject.name.Equals("Ray"))
        {
            onNearEvent.Invoke();
        }
    }


    private void OnCollisionExit2D(Collision2D collision)
    {
        if (propType == PropType.interactable&&collision.gameObject.name.Equals("Ray"))
        {
            onFarEvent.Invoke();
        }
    }
    public virtual bool IsAvailable()
    {
        return true;
    }

    public void OnClick()
    {
        Debug.Log(str_propID);
        switch (propType)
        {
            case PropType.picked: onGetEvent.Invoke(); break;
            case PropType.condition_picked:
                {
                    Debug.Log(str_propID);
                    if (CheckCondition()){
                        onGetEvent.Invoke();
                    }
                    break;
                }
        }
    }

    public void PutInBag()
    {
       
        MouseController.instance.enabled = false;
        GameData.currentItem = str_propID;
        UIController.instance.GetUI<TipUI>("TipUI").ShowGetProp(str_propID);
        UIController.instance.GetUI<BackpackUI>("BackpackUI").AddItem(str_propID);
        GameObject.Destroy(gameObject);
       
    }

    public virtual bool CheckCondition()
    {
      
       
        return true;
    }
    
}
