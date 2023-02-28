using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Actor
{

    /*
    protected Vector3 Playerpos;
    protected Vector3 EnemyPos;
    protected Vector3 pushDir;
    protected float pushTime = 0f;
    */

    Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
   
    public override void dmg(Vector3 player)
    {
      Playerpos = player;
      EnemyPos = transform.position;
      pushDir = Playerpos - EnemyPos;
      pushTime = Time.time;
      transform.Translate( pushDir.normalized * -0.25f);
    
    }
   

}
