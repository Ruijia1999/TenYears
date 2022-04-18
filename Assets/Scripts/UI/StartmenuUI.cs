using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartmenuUI : UIBase
{
    private Button btn_StartGame;
    private Button btn_Continue;
    private Button btn_Team;
    private Button btn_Quit;
    private Button btn_Setting;
    private Animator UIAnimator;
    private GameObject go_Notebook;
    private  Notebook notebook;
    private Transform tran_Buttons;
    private float fixtime = 0;
  
    // Start is called before the first frame update

    public override void Init(params object[] args)
    {
        go_Notebook = GameObject.Find("notebook");
        notebook = go_Notebook.GetComponent<Notebook>();
        UIAnimator = UIGameObject.GetComponent<Animator>();

        tran_Buttons = UITransform.Find("Control/Buttons");
        btn_StartGame = tran_Buttons.Find("NewGame").GetComponent<Button>();
        btn_StartGame.onClick.AddListener(OnNewGame);

        btn_Continue = tran_Buttons.Find("Continue").GetComponent<Button>();
        btn_Continue.onClick.AddListener(OnContinueGame);

        btn_Team = tran_Buttons.Find("Team").GetComponent<Button>();
        btn_Team.onClick.AddListener(OnTeam);

        btn_Setting = tran_Buttons.Find("Setting").GetComponent<Button>();
        btn_Setting.onClick.AddListener(OnSetting);

        btn_Quit = tran_Buttons.Find("Quit").GetComponent<Button>();
        btn_Quit.onClick.AddListener(OnQuit);
        base.Init(args);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    
    void OnClick()
    {
        

        
       
    }

    
    public override void Show()
    {
        base.Show();
        UIAnimator.SetBool("OpenUI", true);
        Invoke("EnableMenu", 1);

    }
    public override void Close()
    {
        UIAnimator.SetBool("OpenUI", false);
        DisableMenu();
       // base.Close();
    }

    public void OnContinueGame()
    {
        if (Time.time - fixtime > 1)
        {
            fixtime = Time.time;

            Close();
            notebook.OpenBook(BookStatus.Continue);
           
        }
    }

    public void OnSetting()
    {
        if (Time.time - fixtime > 1)
        {
            fixtime = Time.time;

            Close();

            Invoke("OpenSetting",2);
        }
    }
    void OpenSetting()
    {
        UIController.GetInstance().GetUI<StartmenuUI>("StartmenuUI").UIGameObject.SetActive(false);
        UIController.GetInstance().OpenUI<SettingUI>("Prefabs/UI/SettingUI");
    }
    public void OnNewGame()
    {
        if (Time.time - fixtime > 1)
        {
            fixtime = Time.time;

            Close();

            notebook.OpenBook(BookStatus.NewGame);
            
        }
       


    }
    public void OnTeam()
    {

        if (Time.time - fixtime > 1)
        {
            fixtime = Time.time;

            Close();
            notebook.OpenBook(BookStatus.Team);
           
        }


    }

    public void OnQuit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
    Application.Quit();
#endif

    }
    private void EnableMenu()
    {
      
        int amount = tran_Buttons.childCount;

        for (int i = 0; i < amount; i++)
        {
            GameObject go = tran_Buttons.GetChild(i).gameObject;
            UIEventListener btnListener = go.AddComponent<UIEventListener>();
            btnListener.SetActive(true);
            go.GetComponent<Button>().enabled = true;
            btnListener.OnMouseEnter += delegate (GameObject gb)
            {
                go.transform.Find("Text").GetComponent<Text>().color = new Color(1, 1, 1, 1);
            };

            btnListener.OnMouseExit += delegate (GameObject gb)
            {
                go.transform.Find("Text").GetComponent<Text>().color = new Color(0.8078432f, 0.345098f, 0.2f, 1);
            };
        }

    }
    private void DisableMenu()
    {

        int amount = tran_Buttons.childCount;

        for (int i = 0; i < amount; i++)
        {
            GameObject go = tran_Buttons.GetChild(i).gameObject;
            go.GetComponent<UIEventListener>().SetActive(false);
            go.GetComponent<Button>().enabled = false;
            go.transform.Find("Text").GetComponent<Text>().color = new Color(0.8078432f, 0.345098f, 0.2f, 1);

        }
    }



    
   

}
