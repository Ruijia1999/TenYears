using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaskUI : UIBase
{
    Animation animation;
    private GameObject go_movieMaks;
    public override void Init(params object[] args)
    {
        bool isMovieMode = (bool)args[0];
        go_movieMaks = UITransform.Find("edgeMask").gameObject;
        
        if (isMovieMode)
        {
            go_movieMaks.SetActive(true);
        }
        else
        {
            go_movieMaks.SetActive(false);
        }
        animation = UIGameObject.GetComponent<Animation>();

        base.Init(args);
    }
    public override void Show()
    {
        UIGameObject.SetActive(true);
        animation.Play("showUI");
        
        base.Show();
    }

    public void StartMovie()
    {
        go_movieMaks.SetActive(true);
        animation.Play("StartMovie");

        base.Show();
    }
    public void EndMovie()
    {
        animation.Play("EndMovie");
        go_movieMaks.SetActive(false);
        base.Show();
    }
    public override void Close()
    {
        animation.Play("fadeUI");
       
        base.Close();
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
