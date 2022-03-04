using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//public class MouseController : MonoBehaviour
//{
//    private Camera cam;//发射射线的摄像机
//    private GameObject go_drag = null;//射线碰撞的物体
//    private GameObject go_enter = null;//射线碰撞的物体
//    private GameObject go_click = null;//射线碰撞的物体
//    private Drag drag; //控制拖拽物体的脚本
//    private bool isDrage = false;
//    public LayerMask draglayer;
//    public LayerMask clicklayer;
//    public bool enabled = false;
//    private float time1 = 0;
//    private float time2 = 0.5f;
    
//    void Start()
//    {
//        cam = Camera.main;
//    }




//    void Update()
//    {
//        //整体初始位置 

//        time1 += Time.fixedDeltaTime;

//        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
//        //从摄像机发出到点击坐标的射线




//        if (Input.GetMouseButton(0) && enabled)
//        {
//            if (!isDrage)
//            {
//                RaycastHit2D hitInfo1 = Physics2D.Raycast(new Vector2(ray.origin.x, ray.origin.y), Vector2.zero,500,draglayer);
//                if (hitInfo1.collider != null )
//                {
//                    go_drag = hitInfo1.collider.gameObject;
//                    drag = go_drag.GetComponent<Drag>();
//                    Debug.Log(go_drag.name);
            
//                        isDrage = true;
                        
                        
                        
//                        Vector3 s = new Vector3(cam.ScreenToWorldPoint(Input.mousePosition).x, cam.ScreenToWorldPoint(Input.mousePosition).y, 0);

//                        drag.offset = go_drag.transform.position - s;
//                        drag.RotateWhenClick();
              
 


//                }
                

//            }



//        }
        

//        if (go_drag != null)
//        {
//            if (!drag.enabled)
//            {
//                drag.enabled = true;
//                isDrage = false;
//                drag = null;
//                go_drag = null;
//            }
//            else
//            {
//                drag.MoveWhileDrag();
//            }
            
//        }

//        if (Input.GetMouseButtonUp(0) && enabled)
//        {

//            if (go_drag != null)
//            {
//                go_drag.GetComponent<Drag>().onMouseUpEvent.Invoke();
//                isDrage = false;
//                go_drag = null;
//                drag = null;
//            }
//            else
//            {
//                RaycastHit2D hitInfo2 = Physics2D.Raycast(new Vector2(ray.origin.x, ray.origin.y), Vector2.zero, 500, clicklayer);

//                if (hitInfo2.collider != null && time1 >= time2)
//                {
//                    time1 = 0;
//                    go_click = hitInfo2.collider.gameObject;
//                    go_click.GetComponent<Drag>().onClickEvent.Invoke();
//                    Debug.Log(go_click.name);
//                }
//            }



//        }
//        else
//        {
//            if(go_drag == null)
//            {
//                RaycastHit2D hitInfo2 = Physics2D.Raycast(new Vector2(ray.origin.x, ray.origin.y), Vector2.zero, 500, clicklayer);

//                if (hitInfo2.collider != null)
//                {
                    
//                    go_enter = hitInfo2.collider.gameObject;
//                    go_enter.GetComponent<Drag>().onEnterEvent.Invoke();
//                    Debug.Log(go_enter.name);
//                }
//                else
//                {
//                    if (go_enter != null)
//                    {
//                        go_enter.GetComponent<Drag>().onExitEvent.Invoke();
//                        Debug.Log(go_enter.name);
//                        go_enter = null;
                        
//                    }
//                }
//            }
//        }


//    }
    


//}
