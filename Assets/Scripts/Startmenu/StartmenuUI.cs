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
    }

    // Update is called once per frame
    void Update()
    {
        btn_StartGame.onClick.AddListener(OnClick);
        btn_Next.onClick.AddListener(NextPage);
        btn_Last.onClick.AddListener(LastPage);
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
