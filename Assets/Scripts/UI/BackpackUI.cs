using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BackpackUI : UIBase
{
    //Items in backpack
    string str_currentItem;
    Image img_currentItem;

    int i_items;
    Dictionary<int, string> list_Items;
    Dictionary<int, Image> img_Items;
    // Start is called before the first frame update
    public override void Init(params object[] args)
    {
        str_currentItem = null;
        Transform content = UITransform.Find("Content");
        img_currentItem = content.Find("currentItem/img_prop").GetComponent<Image>();

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
    public void OpenBag()
    {

    }
    public void AddItem(string prop_name)
    {
        Sprite texture = Resources.Load<Sprite>("Texture/Props/" + prop_name);
        int pos = FindEmpty();
        list_Items.Remove(pos);
        list_Items.Add(pos, prop_name);
        img_Items[pos].sprite = texture;
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
        for(int i=1; i < i_items; i++)
        {
            if (list_Items[i] == null)
            {
                return i;
            }
        }
        if (str_currentItem == null)
        {
            return 0;
        }
        return i_items;
    }
}
