using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gamemanager : MonoBehaviour
{
    public static Gamemanager instance;
    private void Awake()
    {
        if(Gamemanager.instance != null)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
    }
}
