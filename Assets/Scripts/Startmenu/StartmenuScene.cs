using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartmenuScene : MonoBehaviour
{
    private Camera cam;//发射射线的摄像机
    private GameObject go;//射线碰撞的物体
    private Drag drag; //控制拖拽物体的脚本
    private bool isDrage = false;
    public LayerMask draglayer;
    public LayerMask clicklayer;

    private float time1 = 0;
    private float time2 = 1;

    void Start()
    {
        cam = Camera.main;
    }




    void Update()
    {
        //整体初始位置 


        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        //从摄像机发出到点击坐标的射线




        if (Input.GetMouseButton(0))
        {
            if (!isDrage)
            {
                RaycastHit2D hitInfo1 = Physics2D.Raycast(new Vector2(ray.origin.x, ray.origin.y), Vector2.zero,500,draglayer);
                if (hitInfo1.collider != null )
                {
                    go = hitInfo1.collider.gameObject;
                    drag = go.GetComponent<Drag>();
                    Debug.Log(go.name);
            
                        isDrage = true;
                        
                        
                        
                        Vector3 s = new Vector3(cam.ScreenToWorldPoint(Input.mousePosition).x, cam.ScreenToWorldPoint(Input.mousePosition).y, 0);

                        drag.offset = go.transform.position - s;
                        drag.RotateWhenClick();
              
 


                }
                

            }

            RaycastHit2D hitInfo2 = Physics2D.Raycast(new Vector2(ray.origin.x, ray.origin.y), Vector2.zero, 500, clicklayer);

            if (hitInfo2.collider != null)
            {
                GameObject go1 = hitInfo2.collider.gameObject;
                //go1.GetComponent<Drag>().onClickEvent.Invoke();
                Debug.Log(go1.name);
            }

        }

        if (go != null)
        {
            drag.MoveWhileDrag();
        }

        if (Input.GetMouseButtonUp(0))
        {

            if (go != null)
            {
                go.GetComponent<Drag>().Goback();
                isDrage = false;
                go = null;
                drag = null;
            }
                
        }


    }
    


}
