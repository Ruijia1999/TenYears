using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private Vector3 offset;
    private bool isInit = false;
    public GameObject leftBoard;
    public GameObject rightBoard;
    public float f_slideSpeed;
    public float minScale;
    public float maxScale;
    Vector2 vec_RightScreenPoint;
    Vector2 vec_LeftScreenPoint;
    public void Init()
    {
        offset = transform.position - GameData.Ray.transform.position;
        isInit = true;
    }
    // Start is called before the first frame update
    void Start()
    {
        
      
    }

    // Update is called once per frame
    void Update()
    {
        vec_RightScreenPoint = RectTransformUtility.WorldToScreenPoint(Camera.main, rightBoard.transform.position);
        vec_LeftScreenPoint = RectTransformUtility.WorldToScreenPoint(Camera.main, leftBoard.transform.position);
        if (isInit)
        {
            Vector3 newPos = offset + GameData.Ray.transform.position;
        
            if (vec_RightScreenPoint.x <= GameData.f_screen_width)
            {
                if (newPos.x < transform.position.x)
                {
                    transform.position = newPos;
                }
            }
            else if (vec_LeftScreenPoint.x >= 0)
            {
                Debug.Log(vec_LeftScreenPoint.x);
                if (newPos.x > transform.position.x)
                {
                    transform.position = newPos;
                }
            }else
            {
                transform.position = newPos;
            }


        }

        // this.GetComponent<Camera>().orthographicSize += 5 * Input.GetAxis("Mouse ScrollWheel");

        float mouseCenter = Input.GetAxis("Mouse ScrollWheel");

        if (mouseCenter > 0)
        {
            if (Camera.main.orthographicSize < maxScale)
            {
                Camera.main.orthographicSize = Camera.main.orthographicSize+f_slideSpeed * Time.deltaTime > maxScale? maxScale: Camera.main.orthographicSize + f_slideSpeed * Time.deltaTime;
            }
        }
        else if (mouseCenter < 0)
        {
            if (Camera.main.orthographicSize > minScale)
            {
                Camera.main.orthographicSize = Camera.main.orthographicSize - f_slideSpeed * Time.deltaTime < minScale ? minScale : Camera.main.orthographicSize - f_slideSpeed * Time.deltaTime;
            }
        }

    }

}

