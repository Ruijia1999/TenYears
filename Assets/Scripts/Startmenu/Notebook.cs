using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Notebook : MonoBehaviour
{

    public Animator animator;
    public int currentPage;
    void Start()
    {
        currentPage = 0;
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
    }

    public void CloseBook()
    {
        
        currentPage--;
        animator.SetInteger("currentPage", currentPage);
        animator.SetTrigger("LastPage");
        
    }

    public void GotoNextPage()
    {



        currentPage++;
        animator.SetInteger("currentPage", currentPage);
        animator.SetTrigger("NextPage");




    }

    public void GotoLastPage()
    {
        currentPage--;
        animator.SetInteger("currentPage", currentPage);
        animator.SetTrigger("LastPage");
    }



 
}
