using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

using System;
public class Drag : MonoBehaviour
{
    private Vector3 previousPos;
    private Quaternion previousRotate;
    public float rotate;
    public bool IsMoveX;
    public bool IsMoveY;
    public Vector3 offset;
    public OnClick onClickEvent;
    [Serializable]
    public class OnClick : UnityEvent { }
    // Start is called before the first frame update
    void Start()
    {
        previousPos = transform.position;
        previousRotate = transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Goback()
    {
        transform.SetPositionAndRotation(previousPos, previousRotate);
    }

    public void RotateWhenClick()
    {
        Vector3 s = previousPos - offset;

        transform.RotateAround(s, Vector3.forward, rotate);
        offset = transform.position - s;
    }
    public void MoveWhileDrag()
    {
        Vector3 currentScreenSpace = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0);
        Vector3 currentPosition = Camera.main.ScreenToWorldPoint(currentScreenSpace) + offset;
        currentPosition = new Vector3(currentPosition.x, currentPosition.y, 0);
        float newX = currentPosition.x;
        float newY = currentPosition.y;
        if (IsMoveX && IsMoveY)
        {
            transform.position = currentPosition;
        }
        else if (IsMoveX)
        {
            transform.position = new Vector3(newX, transform.position.y,transform.position.z);
        }
        else if (IsMoveY)
        {
            transform.position = new Vector3(transform.position.y,newY, transform.position.z);
        }



    }
}
