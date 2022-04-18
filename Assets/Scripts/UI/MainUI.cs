using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class MainUI : UIBase
{
   
    Button returnToMenu;
    GameObject go_backPack;
    Button btn_backPack;
    Image img_currentItem;
    // Start is called before the first frame update
    public override void Init(params object[] args)
    {
        go_backPack = UITransform.Find("backpack").gameObject;
        btn_backPack = go_backPack.transform.Find("btn_backpack").GetComponent<Button>();
        img_currentItem = go_backPack.transform.Find("bg/currentItem").GetComponent<Image>();
        btn_backPack.onClick.AddListener(OpenBackPack);
        returnToMenu = UITransform.Find("Return").GetComponent<Button>();
        returnToMenu.onClick.AddListener(ReturnStartMenu);
        base.Init(args);
    }

    void OpenBackPack()
    {
        UIController.GetInstance().GetUI<BackpackUI>("BackpackUI").OpenBackPack();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SetCurrentItem(Sprite sprite)
    {
        img_currentItem.sprite = sprite;
    }
    public void ReturnStartMenu()
    {

        
        UIController.GetInstance().CloseUI<MaskUI>();
        //UIController.GetInstance().DestroyUI<MaskUI>("MaskUI");
        Invoke("LoadNewScene", 1);
        //SceneManager.LoadScene("Startmenu");
    }

   
    void LoadNewScene()
    {
        SceneManager.LoadScene("Startmenu");

        UIController.GetInstance().DestroyUI<MainUI>("MainUI");
        
      
    }
   

}
