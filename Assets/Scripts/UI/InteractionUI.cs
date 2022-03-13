using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class InteractionUI : UIBase 
{
    // Start is called before the first frame update

    GameObject go_propInteractionTip;
    Text txt_propInteractionKey;
     Text txt_propInteractionDescription;
    public override void Init(params object[] args)
    {
        go_propInteractionTip = UITransform.Find("PropTip").gameObject;
        txt_propInteractionKey = go_propInteractionTip.transform.Find("Key").GetComponent<Text>();
        txt_propInteractionDescription = go_propInteractionTip.transform.Find("Description").GetComponent<Text>();
        base.Init(args);
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    public override void Show()
    {
        base.Show();
    }

    public override void Close()
    {
        base.Close();
    }


    public void ShowPropInteractionTip(Vector3 i_prop_pos,string i_key, string i_description )
    {
       
        Vector2 vec_ScreenPoint = RectTransformUtility.WorldToScreenPoint(Camera.main, i_prop_pos);

        
        go_propInteractionTip.transform.localPosition  = vec_ScreenPoint - new Vector2(GameData.f_screen_width / 2, GameData.f_screen_height / 2);
        txt_propInteractionKey.text = i_key;
        txt_propInteractionDescription.text = i_description;
        go_propInteractionTip.SetActive(true);
    }

    public void ClosePropInteractionTip()
    {

        go_propInteractionTip.SetActive(false);
    }





}
