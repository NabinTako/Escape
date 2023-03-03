using System.Collections;
using System.Collections.Generic;
using UnityEditor.Search;
using UnityEngine;
using UnityEngine.UI;

public class FloatingText
{
    public bool isactive;
    public GameObject go;
    public Text text;
    public Vector3 motion;
    public float duration;
    public float lastshown;

    public void Show()
    {
        isactive = true;
        lastshown = Time.time;
        go.SetActive(isactive);
    }

    public void Hide()
    {
        isactive=false;
        go.SetActive(isactive);
    }
    
    public void updatefloatingText()
    {
        if (!isactive)
        {
            return;
        }
        if(Time.time - lastshown > duration)
        {
            Hide();
            return;
        }
        go.transform.position += motion * Time.deltaTime;
    }
}
