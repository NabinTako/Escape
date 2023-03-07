using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Actor
{
    public bool chase = false;
    public float speed = 0.5f;
    protected new int Hp = 10;
    protected new int dmgAmount = 5;


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
   
    public override void dmg(Vector3 player,float force,float dmgtaken)
    {
        Playerpos = player;
        pushDir = Playerpos - transform.position;
        pushTime = Time.time;
        transform.Translate(pushDir.normalized * -force);

        Gamemanager.instance.ShowText(dmgtaken.ToString(), 20, Color.red, transform.position, Vector3.up * 40, 2.0f);
        Hp -= (int) dmgtaken;

    } 
   


    public float getPushForce()
    {
        return pushForce;
    }

    public override int HpLeft()
    {
        return base.HpLeft();
    }

    public override int DmgDone()
    {
        return base.DmgDone();
    }


}
