using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private Vector3 offset;
    private bool isInit;
    public void Init()
    {
        offset = transform.position - GameData.Ray.transform.position;
        isInit = true;
    }
    // Start is called before the first frame update
    void Start()
    {
        isInit = false;
        
    }

    // Update is called once per frame
    void Update()
    {
        if(isInit)
        transform.position = offset + GameData.Ray.transform.position;
        // this.GetComponent<Camera>().orthographicSize += 5 * Input.GetAxis("Mouse ScrollWheel");



    }

}
