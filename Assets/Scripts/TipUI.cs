using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TipUI : MonoBehaviour
{
    private GameObject GetProp;
    private Image img_prop;
    private Text text_prop;
    private GameObject Tip;
    private Text txt_Tip;

    // Start is called before the first frame update
    void Start()
    {
        GetProp = transform.Find("GetProp").gameObject;
        img_prop = GetProp.transform.Find("img_prop").GetComponent<Image>();
        text_prop = GetProp.transform.Find("Text").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ShowGetProp(string name, Sprite texture)
    {
        gameObject.SetActive(true);
        img_prop.sprite = texture;
        text_prop.text = "获得：" + name+"。";
    }

    public void ShowTip(string tip)
    {
        // txt_Tip.text = tip;
        Debug.Log("Condition:" + tip);
    }

    private void disappear()
    {
        gameObject.SetActive(false);
    }
}
