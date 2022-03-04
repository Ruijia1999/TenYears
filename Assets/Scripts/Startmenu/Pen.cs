using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Pen : MonoBehaviour
{
    
    
    private Drag drag;
    private Notebook notebook;
    private bool inContent = false;
    // Start is called before the first frame update
    void Start()
    {
        drag = gameObject.GetComponent<Drag>();
        notebook = GameObject.Find("notebook").GetComponent<Notebook>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ClickBeforeDrag()
    {
        
        drag.RotateWhenClick();
        if (notebook.isGuiding)
        {
            notebook.ContinueGuide(5);
        }

    }

    public void OnDragMouseUp()
    {

        if (inContent && (notebook.IsNewLevel()||notebook.isGuiding))
        {
            SceneManager.LoadScene("Street");
            notebook.ContinueGuide(6);
        }
        else
        {
            drag.Goback();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.gameObject.name.Equals("levelText"))
        {
            inContent = true;
        }
       
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
       
        if (collision.gameObject.name.Equals("levelText"))
        {
            inContent = false;
        }

    }
}
