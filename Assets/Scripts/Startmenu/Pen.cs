using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Pen : MonoBehaviour
{
    
    
    private Drag drag;
    private Notebook notebook;
    private bool inContent = false;
    public Animation animation;
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


    }

    public void OnDragMouseUp()
    {

        if (inContent && notebook.isGuiding)
        {
            UIController.instance.GetUI<MaskUI>("MaskUI").StartMovie();
            notebook.ContinueGuide(6);
            GetComponent<Animation>().Play();
            animation.Play();
            Invoke("EnternewLevel", 6);
        }else if (inContent && notebook.IsNewLevel())
        {
            UIController.instance.GetUI<MaskUI>("MaskUI").StartMovie();
            GetComponent<Animation>().Play();
            animation.Play();

            Invoke("EnternewLevel", 6);
           
        }
        else 
        {
            drag.Goback();
        }
    }
    void EnternewLevel()
    {
        UIController.instance.DestroyUI<StartmenuUI>("StartmenuUI");

        UIController.instance.CloseUI<MaskUI>();
        Invoke("LoadScene", 1);
        
    }
    void LoadScene()
    {
        SceneManager.LoadScene("Home");
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
