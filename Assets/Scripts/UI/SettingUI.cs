using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum Language
{
    简体中文,
    English
}
public class SettingUI : UIBase
{

    Button btn_return;
    Button btn_apply;
    float i_volume;
    Language language;
    // Start is called before the first frame update
    public override void Init(params object[] args)
    {
        btn_apply = UITransform.Find("btn_apply").GetComponent<Button>();
        btn_return = UITransform.Find("btn_return").GetComponent<Button>();
        btn_return.onClick.AddListener(OnReturn);
        base.Init(args);

    }

    public override void Show()
    {
        base.Show();
    }

    public override void Close()
    {
        base.Close();
    }

    void OnReturn()
    {
        UIController.GetInstance().OpenUI<StartmenuUI>("Prefabs/UI/StartmenuUI");
        UIController.GetInstance().CloseUI<SettingUI>();
    }
}
