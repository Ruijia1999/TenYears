using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    public void OnDragMouseUp()
    {

        if (inContent && notebook.IsNewLevel())
        {
            Debug.Log("New Game Start");
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
