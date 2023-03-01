using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Actor
{
    public bool chase=false;
    public float speed = 0.5f;


    public Vector3 playerPosition;

    // Start is called before the first frame update
    void Start()
    {
      

    }

    // Update is called once per frame
    void Update()
    {
         if(chase == true)
         {
            if(Time.time > pushTime+pushRecovery)
            transform.position = Vector3.MoveTowards(transform.position, playerPosition, speed *Time.deltaTime);
         }
    }
   
    public override void dmg(Vector3 player,float force)
    {
      Playerpos = player;
      pushDir = Playerpos - transform.position;
      pushTime = Time.time;
      transform.Translate(pushDir.normalized * -force);
    } 
   


    public float getPushForce()
    {
        return pushForce;
    }

    
   

}
