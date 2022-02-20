using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PropType
{
    picked,
    contion_picked,
    bicycle
}
public class PropBase : MonoBehaviour
{
    public PropType propType;
    public string propID;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public virtual bool IsAvailable()
    {
        return true;
    }

    public void OnClick()
    {
        switch (propType)
        {
            case PropType.picked: PutInBag(); break;
        }
    }

    public void PutInBag()
    {

        GameData.backPack.AddItem(propID, transform.GetComponent<Sprite>().texture);
    }

    
    
}
