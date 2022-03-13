using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BackpackUI : UIBase
{
    GameObject go_backpack;
    //Items in backpack
    string str_currentItem;
    Image img_currentItem;
    Sprite spr_defaultProp;
    int i_items;
    Dictionary<int, string> list_Items;
    Dictionary<int, Image> img_Items;
    Button btn_return;
    // Start is called before the first frame update
    public override void Init(params object[] args)
    {
        str_currentItem = null;
        go_backpack = UITransform.Find("bg").gameObject;
        Transform content = UITransform.Find("bg/backPack/Content");
        btn_return = UITransform.Find("bg/backPack/btn_return").GetComponent<Button>();
        btn_return.onClick.AddListener(CloseBackPack);

        img_currentItem = UITransform.Find("bg/backPack/currentItem/img_prop").GetComponent<Image>();
        spr_defaultProp = img_currentItem.sprite;
        list_Items = new Dictionary<int, string>();
        img_Items = new Dictionary<int, Image>();
        
        i_items = content.childCount;
        for(int i= 0; i < i_items; i++)
        {
            list_Items.Add(i, null);
            img_Items.Add(i, content.GetChild(i).transform.Find("img_prop").GetComponent<Image>());
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OpenBackPack()
    {
        go_backpack.SetActive(true);
    }
    public void CloseBackPack()
    {
        go_backpack.SetActive(false);
    }
    public override void Close()
    {
        UIGameObject.SetActive(false);
        base.Close();
    }
  
    public void AddItem(string prop_name)
    {
        
        int pos = FindEmpty();
        if (pos == -1)
        {
            SetCurrentItem(prop_name);
            return;
        }
        Sprite texture = Resources.Load<Sprite>("Texture/Props/" + prop_name);
        list_Items.Remove(pos);
        list_Items.Add(pos, prop_name);
        img_Items[pos].sprite = texture;
    }
    public void SetCurrentItem(string prop_name)
    {
        GameData.currentItem = prop_name;
        str_currentItem = prop_name;
        img_currentItem.sprite = Resources.Load<Sprite>("Texture/Props/" + prop_name);
        UIController.instance.GetUI<MainUI>("MainUI").SetCurrentItem(Resources.Load<Sprite>("Texture/Props/" + prop_name));
    }
    public void RemoveItem(int prop_index)
    {

    }

    public void TakeoutItem(int prop_index)
    {

    }
    void OnCurrentItemClick()
    {

    }
    void OnPropClick()
    {

    }

    int FindEmpty()
    {
        if (str_currentItem == null)
        {
            return -1;
        }
        for (int i=0; i < i_items; i++)
        {
            if (list_Items[i] == null)
            {
                return i;
            }
        }
       
        return i_items;
    }
}
