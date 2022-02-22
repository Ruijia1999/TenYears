using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartmenuUI : MonoBehaviour
{
    public Button btn_StartGame;
    public Button btn_Next;
    public Button btn_Last;
    public Animator UIAnimator;
    private GameObject go_Notebook;
    private  Notebook notebook;

    private float fixtime = 0;
    // Start is called before the first frame update
    void Start()
    {
        go_Notebook = GameObject.Find("notebook");
        notebook = go_Notebook.GetComponent<Notebook>();
        btn_StartGame.onClick.AddListener(OnClick);

        UIEventListener btnListener = btn_StartGame.gameObject.AddComponent<UIEventListener>();

        btnListener.OnMouseEnter += delegate (GameObject gb)
        {
            btn_StartGame.transform.Find("Text").GetComponent<Text>().color =new Color(1, 0.427451f, 0.3294118f,1);
            Debug.Log("enter");
        };

        btnListener.OnMouseExit += delegate (GameObject gb)
        {
            btn_StartGame.transform.Find("Text").GetComponent<Text>().color = new Color(150/255f, 65/255.0f, 38/255.0f,1);
            Debug.Log("exit" + btn_StartGame.transform.Find("Text").GetComponent<Text>().color);
        };
        btn_Next.onClick.AddListener(NextPage);
        btn_Last.onClick.AddListener(LastPage);
        


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
            StartCoroutine(OnFinished());
        } 
        
       
    }

    IEnumerator OnFinished()
    {
        yield return new WaitForSeconds(2);
        notebook.OpenBook();
        

    }

    void NextPage()
    {
        if (Time.time - fixtime > 1)
        {
            fixtime = Time.time;
            Debug.Log(notebook.currentPage);
            if (notebook.currentPage == 0)
            {
                notebook.OpenBook();

            }
            else
                notebook.GotoNextPage();
        }
       
    }

    void LastPage()
    {
        if (Time.time - fixtime > 1)
        {
            fixtime = Time.time;
            Debug.Log(notebook.currentPage);
            if (notebook.currentPage == 1)
            {

                notebook.CloseBook();

            }
            else
            {
                notebook.GotoLastPage();

            }
        }
    }


   

}
