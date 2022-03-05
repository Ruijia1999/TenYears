using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum RoleStatus
{ 
    standing,
    walking,
    running,
    riding
}
public class RayController : MonoBehaviour
{
    Rigidbody2D rb2D;
    RoleStatus status;
    bool canRun;
    float runTime;
    float restTime;
    public float keepRunTime;
    public float chargeTime; //跑步需要的休息时间
    public Vector2 walkVel;
    public Vector2 runVel;
    public Vector2 bicycleVel;

    private void Awake()
    {
        canRun = true;
        runTime = 0;
        status = RoleStatus.standing;
        rb2D = GetComponent<Rigidbody2D>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            rb2D.velocity = -walkVel;
            status = RoleStatus.walking;
           
        }else if (Input.GetKeyDown(KeyCode.D))
        {
            status = RoleStatus.walking;
            rb2D.velocity = walkVel;

        }else if (Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.D))
        {
            Debug.Log("up");
            rb2D.velocity = Vector2.zero;
            status = RoleStatus.standing;
        }

        //开始跑步
        if (Input.GetKeyDown(KeyCode.LeftShift) && status == RoleStatus.walking && canRun)
        {
            status = RoleStatus.running;
            if (Input.GetKey(KeyCode.A))
            {
                rb2D.velocity = -runVel;
                runTime = 0;
            } else if (Input.GetKey(KeyCode.D))
            {
                rb2D.velocity = runVel;
                runTime = 0;
            }

        } else if (Input.GetKey(KeyCode.LeftShift) && status == RoleStatus.running)
        {
            //能量耗尽
            if (runTime >= keepRunTime)
            {
                canRun = false;
                status = RoleStatus.walking;
                if (Input.GetKey(KeyCode.A))
                {
                    rb2D.velocity = -walkVel;
                    restTime = 0;
                }
                else if (Input.GetKey(KeyCode.D))
                {
                    rb2D.velocity = walkVel;
                    restTime = 0;
                }
            }
            else
            {
                runTime += Time.deltaTime;
            }
        } else if(Input.GetKeyUp(KeyCode.LeftShift) && status == RoleStatus.running)
        {
            status = RoleStatus.walking;
            if (Input.GetKey(KeyCode.A))
            {
                rb2D.velocity = -walkVel;
                restTime = 0;
            }
            else if (Input.GetKey(KeyCode.D))
            {
                rb2D.velocity = walkVel;
                restTime = 0;
            }
        }


        //休息时间
        if(status == RoleStatus.standing)
        {
            restTime += 2 * Time.deltaTime;
        }
        if(status == RoleStatus.walking)
        {
            restTime += Time.deltaTime;
        }
        if(restTime >= chargeTime)
        {
            canRun = true;
        }

        Debug.Log(status);
    }


}
