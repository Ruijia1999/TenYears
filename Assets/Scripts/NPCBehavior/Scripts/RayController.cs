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
    Animator animator;
    Rigidbody2D rb2D;
    RoleStatus status;
    private float energy;
    bool canRun;
    public bool isRiding;
    public Vector2 walkVel;
    public Vector2 runVel;
    public Vector2 bicycleVel;
    private GameObject bicycle;
    private void Awake()
    {
        energy = 3;
        animator = GetComponent<Animator>();
        canRun = true;
        bicycle = Resources.Load<GameObject>("Prefabs/Props/bicycle");
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
        if (Input.GetKeyDown(KeyCode.F) && status == RoleStatus.standing)
        {
            RemoveBicycle();
        }
            
        //}else if (Input.GetKeyDown(KeyCode.G) && status == RoleStatus.standing)
        //{
        //    isRiding = false;
        //    animator.SetTrigger("stand");
        //    animator.SetBool("isRiding", isRiding);
        //    rb2D.velocity = Vector2.zero;
           
        //}
        if (Input.GetKeyDown(KeyCode.A))
        {

            if(isRiding)
            {
                animator.SetTrigger("ride");
                status = RoleStatus.riding;
                rb2D.velocity = -bicycleVel;
            }
            else
            {
                animator.SetTrigger("walk_right");
                status = RoleStatus.walking;
                rb2D.velocity = -walkVel;
            }
           
            transform.localRotation = new Quaternion(0, 180, 0, 0);
           
           
           
        }else if (Input.GetKeyDown(KeyCode.D))
        {
            if (isRiding)
            {
                animator.SetTrigger("ride");
                status = RoleStatus.riding;
                rb2D.velocity = bicycleVel;
            }
            else
            {
                animator.SetTrigger("walk_right");
                status = RoleStatus.walking;
                rb2D.velocity = walkVel;
            }
            transform.localRotation = new Quaternion(0, 0, 0, 0);
        }
        else if (Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.D))
        {
   
            animator.SetTrigger("stand");
            animator.SetBool("isRiding", isRiding);

            rb2D.velocity = Vector2.zero;
            status = RoleStatus.standing;

        }

        //开始跑步
        if (Input.GetKeyDown(KeyCode.LeftShift) && !isRiding && status == RoleStatus.walking && canRun)
        {
            
            status = RoleStatus.running;
            if (Input.GetKey(KeyCode.A))
            {
                rb2D.velocity = -runVel;
               
            } else if (Input.GetKey(KeyCode.D))
            {
                rb2D.velocity = runVel;
                
            }

        } else if (Input.GetKey(KeyCode.LeftShift) && status == RoleStatus.running )
        {
            //能量耗尽
            if (energy <=0 )
            {
                canRun = false;
                status = RoleStatus.walking;
                if (Input.GetKey(KeyCode.A))
                {
                    animator.SetTrigger("walk_right");
                    transform.localRotation = new Quaternion(0, 180, 0, 0);
                    rb2D.velocity = -walkVel;
                  
                }
                else if (Input.GetKey(KeyCode.D))
                {
                    animator.SetTrigger("walk_right");
                    transform.localRotation = new Quaternion(0, 0, 0, 0);
                    rb2D.velocity = walkVel;
                   
                }
            }
            else
            {
                energy -= Time.deltaTime;
            }
        } else if(Input.GetKeyUp(KeyCode.LeftShift) && status == RoleStatus.running)
        {
            status = RoleStatus.walking;
            
            
            if (Input.GetKey(KeyCode.A))
            {
                animator.SetTrigger("walk_right");
                rb2D.velocity = -walkVel;
                transform.localRotation = new Quaternion(0, 180, 0, 0);
            }
            else if (Input.GetKey(KeyCode.D))
            {
                animator.SetTrigger("walk_right");
                rb2D.velocity = walkVel;
                transform.localRotation = new Quaternion(0, 0, 0, 0);
            }
        }


        //休息时间
        if(status == RoleStatus.standing)
        {
            energy += 2 * Time.deltaTime;
            
        }
        if(status == RoleStatus.walking)
        {
            energy  += Time.deltaTime;
        }
        if(energy >= 3)
        {
            canRun = true;
        }
        energy = energy > 3 ? 3 : energy;
        Debug.Log(status);
    }

    public void GetBicycle()
    {
        isRiding = true;
        animator.SetTrigger("stand");
        animator.SetBool("isRiding", isRiding);
        rb2D.velocity = Vector2.zero;
    }

    public void RemoveBicycle()
    {
        if (isRiding == true)
        {
            isRiding = false;
            animator.SetTrigger("stand");
            animator.SetBool("isRiding", isRiding);
            rb2D.velocity = Vector2.zero;
            Instantiate<GameObject>(bicycle, transform.position, transform.rotation);
        }
    }
}
