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
                drag.enabledClick = true;
                drag.enabledDrag = true;
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
                drag.enabledClick = false;
                drag.enabledDrag = false;
                animation.Play("DisplayPhoto");
                Debug.Log(drag.GetPreviousPos() + "aaa" + transform.position);
            }
        }
    }
    public void OnClickBeforeDrag()
    {
       
 
        Vector3 prePos = drag.GetPreviousPos();
        transform.position = new Vector3(prePos.x + 1, prePos.y, prePos.z);
        drag.offset += new Vector3(1,0,0);
        Debug.Log(drag.GetPreviousPos() + "aaa" + transform.position);
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
