using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TipUI : UIBase
{
    private GameObject GetProp;
    private Image img_prop;
    private Text text_prop;
    private GameObject Tip;
    private Text txt_Tip;
    
    // Start is called before the first frame update
    public override void Init(params object[] args)
    {
        GetProp = UITransform.Find("GetProp").gameObject;
        img_prop = GetProp.transform.Find("img_prop").GetComponent<Image>();
        text_prop = GetProp.transform.Find("Text").GetComponent<Text>();
    }

    // Update is called once per frame
    public override void Update()
    {
        if (Input.GetMouseButtonUp(0) && isShowed)
        {

            MouseController.instance.enabled = true;
            isShowed = false;
            GetProp.SetActive(false);
        }
    }
  
    public void ShowGetProp(string str_propName)
    {

        GetProp.SetActive(true);
        Invoke("SetShow", 0.5f);
        MouseController.instance.enabled = false;
        Sprite texture = Resources.Load<Sprite>("Texture/Props/" + str_propName);
        img_prop.sprite = texture;
        text_prop.text = "获得：" + str_propName + "。";
    }
    public override void Show()
    {
        base.Show();
    }
    private void SetShow()
    {
        isShowed = true;
    }
    public void ShowTip(string tip)
    {
        // txt_Tip.text = tip;
       
    }

    public override void Close()
    {
        isShowed = false;
        UIGameObject.SetActive(false);
        base.Close();
    }
}
