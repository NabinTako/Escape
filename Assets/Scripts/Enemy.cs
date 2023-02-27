using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Actor
{
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

    public void dmg(Collision2D other)
    {
     //   Knockback(other);
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log(other.gameObject.tag);
      

    }
    protected override void Knockback(Collision2D other)
    {
        base.Knockback(other);
    /*
        Playerpos = other.gameObject.transform.position;
        EnemyPos = transform.position;
        pushDir = Playerpos - EnemyPos;
        pushTime = Time.time;
        rb.MovePosition(transform.position + pushDir.normalized * -0.25f);
    */
    }
   

}
