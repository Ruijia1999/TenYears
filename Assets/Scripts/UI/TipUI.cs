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
        string name = (string)args[0];
        GetProp = UITransform.Find("GetProp").gameObject;
        img_prop = GetProp.transform.Find("img_prop").GetComponent<Image>();
        text_prop = GetProp.transform.Find("Text").GetComponent<Text>();
        Sprite texture = Resources.Load<Sprite>("Texture/Props/" + name);
        img_prop.sprite = texture;
        text_prop.text = "获得：" + name + "。";
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonUp(0) && isShowed)
        {
            this.Close();
        }
    }
  
    public override void Show()
    {
        base.Show();
    }
    public void ShowTip(string tip)
    {
        // txt_Tip.text = tip;
        Debug.Log("Condition:" + tip);
    }

    public override void Close()
    {

        base.Close();
    }
}
