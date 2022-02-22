using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Photo : MonoBehaviour
{
    private Drag drag;
    StartmenuScene startmenu;
    Animation animation;
    private bool isDisplaying = false;
    // Start is called before the first frame update
    void Start()
    {
        drag = gameObject.GetComponent<Drag>();
        animation = gameObject.GetComponent<Animation>();
        startmenu = GameObject.Find("Main Camera").GetComponent<StartmenuScene>();
        animation.playAutomatically = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(isDisplaying && Input.GetMouseButtonDown(0))
        {
            
            Invoke("EnableBook", 1f);
            drag.enabled = true;
            animation.Play("ReturnPhoto");
        }
        else if (!isDisplaying)
        {
            if (Vector3.Distance(transform.position, drag.GetPreviousPos()) > 2)
            {
                isDisplaying = true;
                startmenu.enabled = false;
                drag.enabled = false;
                animation.Play("DisplayPhoto");

            }
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
