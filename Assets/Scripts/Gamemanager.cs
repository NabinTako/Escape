using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Gamemanager : MonoBehaviour
{
    public static Gamemanager instance;

    public FloatingTextManager floatingTextmanager;

    private void Awake()
    {
        if(Gamemanager.instance != null)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
    }

    //floating text
    public void ShowText(string msg,int fontsize,Color color,Vector3 position, Vector3 motion,float duration)
    {
        floatingTextmanager.Show(msg,fontsize,color,position,motion,duration);
    }
}
