using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        this.GetComponent<Camera>().orthographicSize += 5 * Input.GetAxis("Mouse ScrollWheel");



    }

}
