using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIBase : MonoBehaviour
{
    public string UIName;
    public GameObject UIGameObject;
    public Transform UITransform;
    public bool isShowed;
    public object[] args;
    #region life span

    public virtual void Init(params object[] args)
    {

    }
    public virtual void Start()
    {

    }

    // Update is called once per frame
    public virtual void Update()
    {

    }

    // Open Animation
    public virtual void Show()
    {
        
        UIGameObject.SetActive(true);
        StartCoroutine(SetIsShowed(true));
        
    }

    // Close Animation
    public virtual void Close()
    {
        
        UIGameObject.SetActive(false);
        StartCoroutine(SetIsShowed(false));
    }

    IEnumerator SetIsShowed(bool status)
    {
        yield return new WaitForSeconds(1);
        isShowed = status;
    }
    #endregion
}
