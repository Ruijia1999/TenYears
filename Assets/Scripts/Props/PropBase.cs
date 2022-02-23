using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public enum PropType
{
    picked,
    condition_picked,
    bicycle
}
public class PropBase : MonoBehaviour
{
    public PropType propType;
    public string str_propID;
    private GameObject go_Tip;
    private Button btn_Tip;
    private Text txt_Condition;
    public string str_Condition;
    public string str_ConditionProp;
    private Texture2D txture_prop;

    public TipUI tipUI;
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

    public virtual bool IsAvailable()
    {
        return true;
    }

    public void OnClick()
    {
        switch (propType)
        {
            case PropType.picked: PutInBag(); break;
            //case PropType.condition_picked: GameData.IfHasBicycle = true; break;
            case PropType.bicycle:
                {
                    if (CheckCondition()){
                        PutInBag();
                    }
                    break;
                }
        }
    }

    public void PutInBag()
    {
        tipUI.ShowGetProp(str_propID, transform.GetComponent<SpriteRenderer>().sprite);
        GameData.currentItem = str_propID;
       // GameData.backPack.AddItem(str_propID, transform.GetComponent<SpriteRenderer>().sprite.texture);
    }

    public bool CheckCondition()
    {
        Debug.Log(GameData.currentItem + " " + str_ConditionProp);
        if (GameData.currentItem == null)
        {
            tipUI.ShowTip(str_Condition);
            return false;
        }

        if (str_ConditionProp.Equals(GameData.currentItem))
        {
            return true;
        }
        tipUI.ShowTip(str_Condition);
        return false;
    }
    
}
