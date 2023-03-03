using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player : Actor
{
    float horizontalInput, VerticalInput;
    public float xspeed, yspeed;
    [SerializeField]
    private bool GiveDmg;
    protected int Hp = 10;
    protected int dmgAmount = 5;
    /*
    Vector3 motionX = Vector3.zero;
    Vector3 motionY = Vector3.zero;
    bool canMoveX = true;
    bool canMoveY = true; */

    //references
    Animator anim;
    Rigidbody2D rb;
    private void Start()
    {
        anim = GetComponent<Animator>();
        rb =GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        if(Time.time> pushTime + pushRecovery)
        {
            Movement();
        }
        if (Input.GetMouseButtonDown(0))
        {
            anim.SetTrigger("Attack");
        }
    }
    private void Movement()
    {
        //Takes the inputs from the user
        horizontalInput = Input.GetAxisRaw("Horizontal");
        VerticalInput = Input.GetAxisRaw("Vertical");

       Vector3 motion = new Vector3(horizontalInput * xspeed, VerticalInput * yspeed, 0) * Time.deltaTime;

       
        if (horizontalInput > 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
            anim.SetBool("isRunning", true);
            anim.SetBool("isLookingUp", false);
            anim.SetBool("isLookingDown", false);

        }
        else if (horizontalInput < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
            anim.SetBool("isRunning", true);
            anim.SetBool("isLookingUp", false);
            anim.SetBool("isLookingDown", false);
        }
        else
        {
            anim.SetBool("isRunning", false);
        }

        if(VerticalInput > 0)
        {
            anim.SetBool("isLookingDown", false);
            anim.SetBool("isLookingUp", true);
        }
        else if (VerticalInput < 0)
        {
            anim.SetBool("isLookingUp", false);
            anim.SetBool("isLookingDown", true);
        }

        if(horizontalInput > 0 && VerticalInput > 0)
        {
            anim.SetBool("isRunning", true);
            anim.SetBool("isLookingUp", true);
        }else if(horizontalInput < 0 && VerticalInput < 0)
        {
            anim.SetBool("isRunning", true);
            anim.SetBool("isLookingDown", true);
        }
        if (Input.GetKey(KeyCode.W))
        {
            anim.SetBool("isLookingUp", true);
            anim.SetBool("isLookingDown", false);
            anim.SetBool("isRunning", true);
        }
        else if (Input.GetKey(KeyCode.S))
        {
            anim.SetBool("isLookingDown", true);
            anim.SetBool("isLookingUp", false);
            anim.SetBool("isRunning", true);
        }
        // motionX = new Vector3(horizontalInput * xspeed,0, 0);
        // motionY = new Vector3(0, VerticalInput * yspeed, 0);

        // Turn player left or right.
        /* bool[] result = CheckCollision();
        // To move the player to the desired position
        if (result[0])
        {
            transform.Translate(motionX * Time.deltaTime);
        }
        if (result[1])
        {
            transform.Translate(motionY * Time.deltaTime);
        }
        */
        rb.MovePosition(transform.position+ motion);

  

    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "Fighter")
        {
            if (GiveDmg == true)
            {
                other.gameObject.GetComponent<Enemy>().dmg(transform.position,pushForce,dmgAmount);
            }
            else
            {
                Enemy ene = other.gameObject.GetComponent<Enemy>();
                int dmgtaken = ene.DmgDone();
                dmg(other.transform.position, ene.getPushForce());
                Gamemanager.instance.ShowText(dmgtaken.ToString(), 20, Color.red, transform.position, Vector3.up * 40, 2.0f);
            }
        }
        

    }
    public override void dmg(Vector3 other, float force)
    {

       Playerpos = transform.position;
       pushDir = other - Playerpos;
       pushTime = Time.time;
      transform.Translate(pushDir.normalized * -force);

    }

    public bool getGivedmg()
    {
        return GiveDmg;
    }

    // Checking if the player can move or not on a specified axis.
    /*private bool[] CheckCollision()
    {
        RaycastHit2D hitx, hity;

        //Checking for collision on X axis.
        if (horizontalInput < 0)
        {
            hitx = Physics2D.Raycast(transform.position, Vector3.left, 0.09f);
            //Debug.DrawRay(transform.position, Vector3.left * 0.09f, Color.green,0.2f);
            transform.localScale = new Vector3(-1, 1, 1);
        }
        else if (horizontalInput > 0)
        {

            hitx = Physics2D.Raycast(transform.position, Vector3.right, 0.09f);
            //Debug.DrawRay(transform.position, Vector3.right * 0.09f, Color.green,0.2f);
            transform.localScale = new Vector3(1, 1, 1);
        }
        else
        {
            hitx = Physics2D.Raycast(transform.position, Vector3.zero);
        }

        //Checking for collision on Y axis.
        if (VerticalInput < 0)
        {
            hity = Physics2D.Raycast(transform.position, Vector3.down, 0.12f);
            //Debug.DrawRay(transform.position, Vector3.down * 0.12f, Color.green, 0.2f);
        }
        else if (VerticalInput > 0)
        {

            hity = Physics2D.Raycast(transform.position, Vector3.up, 0.12f);
            //Debug.DrawRay(transform.position, Vector3.up * 0.12f, Color.green, 0.2f);
        }
        else
        {
            hity = Physics2D.Raycast(transform.position, Vector3.zero); 
        }

        if (hitx.collider != null && hitx.collider.tag == "Blocking")
        {
            canMoveX = false;
        }
        else
        {
            canMoveX = true;
        }
        if (hity.collider != null && hity.collider.tag == "Blocking")
        {
            canMoveY = false;
        }
        else
        {
            canMoveY = true;
        }
        bool[] result = {canMoveX, canMoveY};
        return result;
    }
    */
    public override int HpLeft()
    {
        return base.HpLeft();
    }

    public override int DmgDone()
    {
        return base.DmgDone();
    }
}
