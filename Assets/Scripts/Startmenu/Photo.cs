using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Photo : MonoBehaviour
{
    private Drag drag;
    MouseController startmenu;
    Animation animation;
    public Notebook notebook;
    private bool isDisplaying = false;
    // Start is called before the first frame update
    void Start()
    {
        drag = gameObject.GetComponent<Drag>();
        animation = gameObject.GetComponent<Animation>();
        startmenu = GameObject.Find("Main Camera").GetComponent<MouseController>();
        animation.playAutomatically = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(isDisplaying && Input.GetMouseButtonDown(0))
        {
            if (notebook.isGuiding)
            {
                notebook.ContinueGuide(3);

            }
            else
            {
                drag.enabled = true;
            }
            Invoke("EnableBook", 1f);
            
            animation.Play("ReturnPhoto");
        }
        else if (!isDisplaying)
        {
            if (Vector3.Distance(transform.position, drag.GetPreviousPos()) > 2)
            {
                
                isDisplaying = true;
                startmenu.enabled = false;
                notebook.ContinueGuide(2);
                drag.enabled = false;
                animation.Play("DisplayPhoto");

            }
        }
    }
    public void OnClickBeforeDrag()
    {
        if (notebook.isGuiding)
        {
            notebook.ContinueGuide(1);

        }
    }
    public void OnDragMouseUp()
    {

       
            drag.Goback();
        
    }

    public void EnableBook()
    {
        startmenu.enabled = true;
        isDisplaying = false;
    }

    public void SetIsDisplaying()
    {
        
    }

}
