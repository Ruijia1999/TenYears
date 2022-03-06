using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour
{
    public static UIController instance;
    private GameObject canvas;
    public Dictionary<string, UIBase> panels;
   
    // Awake
    public void Awake()
    {
       // DontDestroyOnLoad(gameObject);
        instance = this;
        canvas = GameObject.Find("Canvas");

        panels = new Dictionary<string, UIBase>();
    }

    void Start()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    public void CloseUI<T>() where T : UIBase
    {
        string name = typeof(T).ToString();
        if (panels.ContainsKey(name))
        {
            panels[name].Close();

            return;
        }
    }
    // Open UI
    public void OpenUI<T> (string UIpath, params object[] args) where T: UIBase
    {
        string name = typeof(T).ToString();
        if (panels.ContainsKey(name))
        {
            panels[name].Show();
            
            return;
        }

        UIBase panel = canvas.AddComponent<T>();
        
        panels.Add(name, panel);

        GameObject UIGameObject = Resources.Load<GameObject>(UIpath);
        panel.UIGameObject = (GameObject)Instantiate(UIGameObject);
        panel.UIGameObject.transform.SetParent(this.transform);
        panel.UITransform = panel.UIGameObject.transform;
        panel.Init(args);
        // play animations
        panel.Show();
        
    }

    public T GetUI<T>(string UI_name)where T: UIBase
    {
        return (T)panels[UI_name];
    }

    public void DestroyUI<T>(string UI_name) where T : UIBase
    {
        Destroy(panels[UI_name].UIGameObject);
        Destroy(canvas.GetComponent<T>());
        
      
    }
}
