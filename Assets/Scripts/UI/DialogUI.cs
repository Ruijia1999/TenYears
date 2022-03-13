using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class DialogUI : UIBase
{
    GameObject go_subtitle;
    GameObject go_self;
    GameObject go_Dialog;
    Text txt_subtitle;
    Text txt_self;
    Text txt_Dialog;
    bool isSelf;
    bool isDialog;
    bool isSubtitle;
    // Start is called before the first frame update
    void Start()
    {
        isSelf = false;
        go_subtitle = UITransform.Find("subtitles").gameObject;
        txt_subtitle = go_subtitle.GetComponent<Text>();
        go_self = UITransform.Find("selfDialog").gameObject;
        txt_self = go_self.transform.Find("Text").GetComponent<Text>();
        go_Dialog = UITransform.Find("Dialog").gameObject;
        txt_Dialog = go_Dialog.transform.Find("bg_dialog/Text").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (isSelf)
            {
                Invoke("ActiveMouseCtrl", 0.5f);
                isSelf = false;
                GameData.Ray.GetComponent<RayController>().enabled = true;
                go_self.SetActive(false);
            }else if (isDialog)
            {
                Invoke("ActiveMouseCtrl", 0.5f);
                isDialog = false;
                GameData.Ray.GetComponent<RayController>().enabled = true;
                go_Dialog.SetActive(false);
            }
          
        }
    }

    public void ShowSelf(string context)
    {
        MouseController.instance.enabled = false;
        txt_self.text = context;
        go_self.SetActive(true);
        isSelf = true;
        GameData.Ray.GetComponent<RayController>().StopRay();
    }

    public void StartDialog(string diaID)
    {
        MouseController.instance.enabled = false;
        isDialog = true;
        txt_Dialog.text = "Hey. Ray. Good morning!";
        go_Dialog.SetActive(true);
        GameData.Ray.GetComponent<RayController>().StopRay();
       
    }
    public void ContinueDialog()
    {

    }
    void ActiveMouseCtrl()
    {
        MouseController.instance.enabled = true;
    }
}
