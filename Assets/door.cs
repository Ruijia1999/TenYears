﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class door : MonoBehaviour
{
    // Start is called before the first frame update
    Transform go_door;
    bool isNear; //是否可互动
    bool inAnimation;
    bool isOpened;
    Animation animation;
    public string description;

    void Start()
    {
        go_door = transform.Find("door");
        isNear = false;
        inAnimation = false;
        isOpened = false;
        animation = GetComponent<Animation>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isNear && !inAnimation)
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                if (gameObject.name.Equals("frontdoor"))
                {

                    UIController.instance.CloseUI<MaskUI>();
                    Invoke("LoadScene", 1);
                    
                    return;
                }
                inAnimation = true;
                if (!isOpened)
                {
                    
                    animation["OpenDoor"].time = 0;
                    //动画的播放速度为正常速度
                    animation["OpenDoor"].speed = 1.0f;
                    animation.Play("OpenDoor");
                    GetComponent<BoxCollider2D>().enabled = false;
                }
            }
        }
    }
    void LoadScene()
    {
        SceneManager.LoadScene("street");
    }
    public void OnNear()
    {
        UIController.instance.GetUI<InteractionUI>("InteractionUI").ShowPropInteractionTip(go_door.position, "F", description);
        isNear = true;
    }

    public void OnFar()
    {
        UIController.instance.GetUI<InteractionUI>("InteractionUI").ClosePropInteractionTip();
        isNear = false;
    }
}
