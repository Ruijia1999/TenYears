using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bedroomDesk : MonoBehaviour
{
    GameObject go_home;
    // Start is called before the first frame update
    void Awake()
    {
        go_home = GameObject.Find("Home").gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OpenChouti()
    {
        Debug.Log(go_home);
        go_home.SetActive(false);
        GameData.Ray.gameObject.SetActive(false);
        gameObject.SetActive(true);
    }
    public void CloseChouti()
    {
        
        go_home.SetActive(true);
        GameData.Ray.gameObject.SetActive(true);
        gameObject.SetActive(false);
    }
}
