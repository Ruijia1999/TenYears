using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bicycle : PropBase
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override bool CheckCondition()
    {
        
        if(GameData.currentItem != null && GameData.currentItem.Equals("key")){
            return true;
        }
        return false;
    }

    public void GetBicycle()
    {
        
        GameData.Ray.GetComponent<RayController>().GetBicycle();
        Destroy(gameObject);
    }

  
}
