using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PlayerStatus
{
    OffStair,
    OnStair,
    ReadyUpStair,
    ReadyDownStair,
    ReadyUpOffStair,
    ReadyDownOffStair,
    Talk
}
public class PlayerController : MonoBehaviour
{
    public float currentTime = 0.1f;
    // 弹幕计时
    private float invokeTime = 0.0001f;
    public GameObject upArrow;
    public GameObject downArrow;
    public GameObject rightArrow;
    public GameObject leftArrow;

    public float player_speed = 0.001f;

    public float top;
    public float bottom;
    //Ladder Status
    PlayerStatus playerStatus = PlayerStatus.OffStair;
    PlayerStatus previousPlayerStatus;
    void Start()
    {
        TimeTask task = new TimeTask("s", 0, 0);

        Criminal npc = new Criminal();
 
        
        
        //BehaviorTreeHelp.InitiateTree(npc);
        
    }

    void ReadyStair()
    {
        
        if (playerStatus == PlayerStatus.ReadyUpStair){
            if (Input.GetKey(KeyCode.W)) {
                playerStatus = PlayerStatus.OnStair;
                previousPlayerStatus = playerStatus;
                upArrow.SetActive(false);
               
            }
        }
        if (playerStatus == PlayerStatus.ReadyDownStair) { 
            if (Input.GetKey(KeyCode.S)) { 
                playerStatus = PlayerStatus.OnStair;
                previousPlayerStatus = playerStatus;
                downArrow.SetActive(false);
               
            }  
        }
        if (Input.GetKey(KeyCode.A)) { CharacterMove(Vector2.left); }
        if (Input.GetKey(KeyCode.D)) { CharacterMove(Vector2.right); }
    }

    void ReadyOffStair()
    {
        if(playerStatus == PlayerStatus.ReadyDownOffStair)
        {
            if (Input.GetKey(KeyCode.W)) { CharacterMove(Vector2.up); }
            if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
            {
                transform.localPosition = Vector3.MoveTowards(gameObject.transform.localPosition, new Vector3(transform.localPosition.x, bottom, -3), 1);
                playerStatus = PlayerStatus.OffStair;
                previousPlayerStatus = playerStatus;
                rightArrow.SetActive(false);
                leftArrow.SetActive(false);
            }
        }
        if(playerStatus == PlayerStatus.ReadyUpOffStair)
        {
            if (Input.GetKey(KeyCode.S)) { CharacterMove(Vector2.down); }
            if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
            {
                transform.localPosition = Vector3.MoveTowards(gameObject.transform.localPosition, new Vector3(transform.localPosition.x, top,-3), 1);
                playerStatus = PlayerStatus.OffStair;
                previousPlayerStatus = playerStatus;
                rightArrow.SetActive(false);
                leftArrow.SetActive(false);
            }
        }
        
        
       
    }

    void OnStair()
    {
        
        if (Input.GetKey(KeyCode.W))
        {
            CharacterMove(Vector2.up);

        }
        if (Input.GetKey(KeyCode.S))
        {

            CharacterMove(Vector2.down);
        }
    }

    void OffStair()
    {
        if (Input.GetKey(KeyCode.A))
        {

            CharacterMove(Vector2.left);
        }
        if (Input.GetKey(KeyCode.D))
        {

            CharacterMove(Vector2.right);
        }
    }
    void Update()
    {
        //Debug.Log(playerStatus);
        invokeTime += Time.deltaTime;
        // 间隔时间大于自定义时间才执行

     
        switch (playerStatus)
        {
            case PlayerStatus.OnStair: OnStair(); break;
            case PlayerStatus.ReadyUpStair: 
            case PlayerStatus.ReadyDownStair: ReadyStair(); break;
            case PlayerStatus.OffStair: OffStair(); break;
            case PlayerStatus.ReadyUpOffStair: 
            case PlayerStatus.ReadyDownOffStair: ReadyOffStair(); break;
        }
        
    }

    private void OnTriggerEnter2D(Collider2D coll)
    {

        previousPlayerStatus = playerStatus;
        if (playerStatus == PlayerStatus.OnStair)
        {
            if (coll.gameObject.tag == "bottom")
            {
                playerStatus = PlayerStatus.ReadyDownOffStair;
                
            }

            if (coll.gameObject.tag == "top")
            {
                playerStatus = PlayerStatus.ReadyUpOffStair;

            }
            rightArrow.SetActive(true);
            leftArrow.SetActive(true);


        }
        else if (playerStatus == PlayerStatus.OffStair)
        {
            if(coll.gameObject.tag == "bottom") {
                playerStatus = PlayerStatus.ReadyUpStair;
                upArrow.SetActive(true);
                
            }
            
            if (coll.gameObject.tag == "top") {
                playerStatus = PlayerStatus.ReadyDownStair;
                downArrow.SetActive(true);
            }
        }
    }

    private void OnTriggerExit2D (Collider2D coll)
    {

        playerStatus = previousPlayerStatus;
        rightArrow.SetActive(false);
        leftArrow.SetActive(false);
        upArrow.SetActive(false);
        downArrow.SetActive(false);
    }


    private void CharacterMove(Vector2 vector)
    {
        

        if (vector == Vector2.down || vector == Vector2.up)
        {
            transform.Translate(vector * player_speed * Time.fixedDeltaTime);
      
            return;
        }
            
        if (vector == Vector2.left || vector == Vector2.right)
            transform.Translate(vector * player_speed *2* Time.fixedDeltaTime);


    }

   
}
