using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Notebook : MonoBehaviour
{
    private int level = 0;
    public Animator animator;
    public int currentPage;
    public StartmenuScene mouseControl;
    private StartmenuUI startmenuUI;
    void Start()
    {
        currentPage = 0;
        startmenuUI = GameObject.Find("Canvas").GetComponent<StartmenuUI>();
        //PageLayer = transform.Find("PageLayer").gameObject;
        //newPage = transform.Find("newPage").gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OpenBook()
    {
        currentPage++;
        animator.SetInteger("currentPage", currentPage);
        mouseControl.enabled = true;

    }

    private void closeBook()
    {
        animator.SetTrigger("LastPage");
    }
    public void CloseBook()
    {
        mouseControl.enabled = false;
        
       
        if (currentPage > 1)
        {
            currentPage = 0;
            animator.SetInteger("currentPage", currentPage);
            animator.SetTrigger("LastPage");
            Invoke("closeBook", 0.7f);
            Invoke("BackToMenu", 1);
        }
       
        else
        {
            currentPage = 0;
            animator.SetInteger("currentPage", currentPage);
            closeBook();
            Invoke("BackToMenu", 0.5f);
        }
        
        
        
        
        
        
    }

    public bool IsNewLevel()
    {
        return true;
    }
    private void BackToMenu()
    {
        startmenuUI.ShowMenu();
    }
    public void GotoNextPage()
    {


        if (currentPage == 0)
        {
            OpenBook();

        }
        else
        {
            
            animator.SetTrigger("NextPage");
            currentPage++;
            animator.SetInteger("currentPage", currentPage);
            

        }





    }

    public void GotoLastPage()
    {
        if (currentPage == 1)
        {

            CloseBook();

        }
        else
        {
            
            animator.SetTrigger("LastPage");
            currentPage--;
            animator.SetInteger("currentPage", currentPage);
        }
        
    }



 
}
