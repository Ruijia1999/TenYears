using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartmenuUI : MonoBehaviour
{
    public Button btn_StartGame;
    public Button btn_Continue;
    public Button btn_Team;
    public Button btn_Quit;
    public Animator UIAnimator;
    private GameObject go_Notebook;
    private  Notebook notebook;
    private GameObject go_Buttons;
    private float fixtime = 0;
    // Start is called before the first frame update
    void Start()
    {
        go_Notebook = GameObject.Find("notebook");
        notebook = go_Notebook.GetComponent<Notebook>();
        btn_StartGame.onClick.AddListener(OnClick);

        go_Buttons = GameObject.Find("Buttons");

        Invoke("EnableMenu", 2);
    
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    void OnClick()
    {
        if(Time.time - fixtime > 1)
        {
            fixtime = Time.time;
        
            UIAnimator.SetBool("OpenUI", false);
            Invoke("OnFinished",1);
            DisableMenu();
        }

        
       
    }

    private void OnFinished()
    {
        
        notebook.GotoNextPage();
        

    }
    private void EnableMenu()
    {
      
        int amount = go_Buttons.transform.childCount;

        for (int i = 0; i < amount; i++)
        {
            GameObject go = go_Buttons.transform.GetChild(i).gameObject;
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

        int amount = go_Buttons.transform.childCount;

        for (int i = 0; i < amount; i++)
        {
            GameObject go = go_Buttons.transform.GetChild(i).gameObject;
            go.GetComponent<UIEventListener>().SetActive(false);
            go.GetComponent<Button>().enabled = false;
            go.transform.Find("Text").GetComponent<Text>().color = new Color(0.8078432f, 0.345098f, 0.2f, 1);

        }
    }

    public void ShowMenu()
    {
        EnableMenu();
        UIAnimator.SetBool("OpenUI", true);
    }


    
   

}
