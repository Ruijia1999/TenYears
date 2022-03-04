using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public enum BookStatus
{
    Continue,
    NewGame,
    Team
}
public class Notebook : MonoBehaviour
{
    private BookStatus status;
    public int currentPage;
    private int currentLevel=4;
    public bool isGuiding = false;
    private Animator coverAnimator;
    private Animator firstpageAnimator;
    private Animator newpageAnimator;
    
    public MouseController mouseControl;
    private StartmenuUI startmenuUI;
    
    private Dictionary<int, string> contents;

    public Animator guideAnimator;
    public GameObject go_guide;
    private GameObject btn_return;
    private Sprite btn_dark;
    private Sprite btn_light;
    private Drag pen;
    private Drag photo;
    private GameObject go_next;
    private GameObject go_last;
    private GameObject go_photo;
    private GameObject go_pen;
    private SpriteRenderer oldlevelContent;
    private SpriteRenderer newlevelContent;
    void Start()
    {
        currentPage = 0;
        startmenuUI = GameObject.Find("Canvas").GetComponent<StartmenuUI>();
      //  oldlevelContent = transform.Find("newPage/content").GetComponent<SpriteRenderer>();
        newlevelContent = transform.Find("newcontent").GetComponent<SpriteRenderer>();
        btn_return = transform.Find("Return").gameObject;
        go_next = transform.Find("NextPage").gameObject;
        go_last = transform.Find("LastPage").gameObject;
        pen = GameObject.Find("pen").GetComponent<Drag>();
        go_photo = GameObject.Find("photo").gameObject;
        photo = go_photo.GetComponent<Drag>();
        contents = new Dictionary<int, string>();

        coverAnimator = transform.Find("cover").GetComponent<Animator>();
        firstpageAnimator = transform.Find("firstPage").GetComponent<Animator>();
        newpageAnimator = transform.Find("newPage").GetComponent<Animator>();

        btn_dark = Resources.Load<Sprite>("Texture/btn_return_dark");
        btn_light = Resources.Load<Sprite>("Texture/btn_return_light");

        

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OpenBook(BookStatus i_status)
    {
        status = i_status;
        
        currentPage++;
        coverAnimator.SetTrigger("openbook");
        mouseControl.enabled = true;
        Invoke("SetBook", 1);
    }

    public void CloseBook()
    {
        mouseControl.enabled = false;

        go_last.SetActive(false);
        go_next.SetActive(false);
        if (currentPage > 1)
        {
            currentPage = 0;
            firstpageAnimator.SetTrigger("last");
            Invoke("Return", 0.5f);
            Invoke("BackToMenu", 1.5f);
        }else if (currentPage == 1)
        {
            currentPage = 0;
            coverAnimator.SetTrigger("closebook");
            Debug.Log("2");
            Invoke("BackToMenu", 1f);
        }
        
    }
    void Return()
    {
        coverAnimator.SetTrigger("closebook");
        Debug.Log("1");
    }
    public void SetReutrnBtn()
    {
        if (btn_return.active)
        {
            btn_return.SetActive(false);
        }
        else
        {
            btn_return.SetActive(true);
        }
    }

    public void EnterReturn()
    {
        btn_return.GetComponent<SpriteRenderer>().sprite = btn_light;
        
    }

    public void ExitReturn()
    {
         btn_return.GetComponent<SpriteRenderer>().sprite = btn_dark;
    }

    public bool IsNewLevel()
    {
        return currentPage == currentLevel;
    }

    private void BackToMenu()
    {
        startmenuUI.ShowMenu();
    }
    public void GotoNextPage()
    {
        
        if (currentPage >= currentLevel)
        {
            return;
        }
        
       if (currentPage == 1)
        {
            if (isGuiding)
            {
                ContinueGuide(4);
            }
            currentPage++;
            // Invoke("UpdateContent",0.5f);
            firstpageAnimator.SetTrigger("next");
        }
        else
        {
            currentPage++;
           // Invoke("UpdateContent", 0.5f);
            newpageAnimator.SetTrigger("next");

        }

      




    }
    public void UpdateContent()
    {
        if(status == BookStatus.Team)
        {
            newlevelContent.sprite = Resources.Load<Sprite>("Texture/notebook/team");
            return;
        }
        //oldlevelContent.sprite = newlevelContent.sprite;
        if (currentPage == 0)
        {
            newlevelContent.sprite = Resources.Load<Sprite>("Texture/notebook/level_1" );
        }
        if (currentPage < currentLevel)
        {
            newlevelContent.sprite = Resources.Load<Sprite>("Texture/notebook/level_" + currentPage);
        }
        else
        {
            newlevelContent.sprite = null;
        }
    }

    public void GotoLastPage()
    {
        if (currentPage == 1)
        {
            Debug.Log("3");
            CloseBook();

        }
        else if (currentPage == 2)
        {
            currentPage--;
            //UpdateContent();
            firstpageAnimator.SetTrigger("last");

        }
        else
        {
            currentPage--;
            //UpdateContent();
            newpageAnimator.SetTrigger("last");
        }

    }
    #region different options

    void SetBook()
    {
        switch (status)
        {
            case BookStatus.Continue: Continue(); break;
            case BookStatus.NewGame: NewGame(); break;
            case BookStatus.Team: Team();break;
        }
    }
    void NewGame()
    {
        isGuiding = true;
        Invoke("StartGuide", 3);
        go_next.SetActive(false);
        go_last.SetActive(false);
        btn_return.GetComponent<Drag>().enabled = false;
        photo.enabled = false;
        pen.enabled = false;
    }
    void StartGuide()
    {
        ContinueGuide(0);
    }
    //新手引导
    public void ContinueGuide(int stage)
    {
        switch (stage)
        {
            case 0: go_guide.SetActive(true); guideAnimator.SetTrigger("continue"); 
                photo.enabled = true; 
                break;
            case 1: guideAnimator.SetTrigger("continue"); break;
            case 2: guideAnimator.SetTrigger("continue"); go_guide.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0); break;
            case 3: go_guide.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1); 
                guideAnimator.SetTrigger("continue");
                go_next.SetActive(true);
                break;
            case 4: guideAnimator.SetTrigger("continue"); pen.enabled = true; break;
            case 5: guideAnimator.SetTrigger("continue");
                
                break;
            case 6: guideAnimator.SetTrigger("continue"); break;
        }
    }
    void Continue()
    {
        go_next.SetActive(true);
        go_last.SetActive(true);
        btn_return.GetComponent<Drag>().enabled = true;
        photo.enabled = true;
        pen.enabled = true;
        //btn_return.SetActive(true);
    }

    void Team()
    {
        go_next.SetActive(false);
        go_last.SetActive(true);
        btn_return.GetComponent<Drag>().enabled = true;
        photo.enabled = false;
        pen.enabled = false;
    }
    #endregion
   
    //public void ItemOut()
    //{
    //    Debug.Log("Item");
    //    item_animation.Play();
    //    Invoke("ItemShow", 1.5f);
    //}

    //public void ItemFade()
    //{
    //    item_animation.Play("HideItem");
    //}

    //public void ItemShow()
    //{
    //    item_animation.Play("ItemDisplay");
    //}




}
