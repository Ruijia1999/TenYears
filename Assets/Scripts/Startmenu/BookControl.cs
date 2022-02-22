using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BookControl : MonoBehaviour
{
    public Animator BookAnimator;
    private Notebook notebook;

    // Start is called before the first frame update
    void Start()
    {
       
        notebook = GameObject.Find("notebook").GetComponent<Notebook>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void NextPage()
    {

        Debug.Log("next");
        if (notebook.currentPage == 0)
        {
            notebook.OpenBook();

        }
        else
            notebook.GotoNextPage();
    }

    public void LastPage()
    {
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
