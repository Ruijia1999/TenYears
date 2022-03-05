using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class MainUI : UIBase
{
    Animation animation;
    Button returnToMenu;
    // Start is called before the first frame update
    public override void Init(params object[] args)
    {
       

        
        animation = UIGameObject.GetComponent<Animation>();
        returnToMenu = UITransform.Find("Return").GetComponent<Button>();
        returnToMenu.onClick.AddListener(ReturnStartMenu);
        base.Init(args);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ReturnStartMenu()
    {
        Close();
        UIController.instance.DestroyUI<MainUI>("MainUI");
        UIController.instance.DestroyUI<MaskUI>("MaskUI");
        SceneManager.LoadScene("Startmenu");
    }

    public override void Show()
    {
        animation.Play("showMainUI");
   
        base.Show();
    }

    public override void Close()
    {
        animation.Play("fadeMainUI");
        base.Close();
    }

}
