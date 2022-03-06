using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class MainUI : UIBase
{
   
    Button returnToMenu;
    // Start is called before the first frame update
    public override void Init(params object[] args)
    {
       
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

        
        UIController.instance.CloseUI<MaskUI>();
        //UIController.instance.DestroyUI<MaskUI>("MaskUI");
        Invoke("LoadNewScene", 1);
        //SceneManager.LoadScene("Startmenu");
    }

   
    void LoadNewScene()
    {
        SceneManager.LoadScene("Startmenu");

        UIController.instance.DestroyUI<MainUI>("MainUI");
        
      
    }
   

}
