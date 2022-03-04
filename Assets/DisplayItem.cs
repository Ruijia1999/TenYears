using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayItem : MonoBehaviour
{
    public Notebook notebook;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void NextPage()
    {
        notebook.GotoNextPage();
    }
}
