using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    float horizontalInput, VerticalInput;
    public float xspeed, yspeed;
    Vector3 motion = Vector3.zero;
    private void Start()
    {
        
    }
    void Update()
    {
        Movement();
    }
   private void Movement()
    {
        //Takes the inputs from the user
        horizontalInput = Input.GetAxisRaw("Horizontal");
        VerticalInput = Input.GetAxisRaw("Vertical");

        
        motion = new Vector3(horizontalInput * xspeed, VerticalInput * yspeed, 0);
        
        // Turn player left or right.
        if(horizontalInput < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
        else
        {

            transform.localScale = new Vector3(1, 1, 1);
        }

        RaycastHit2D hit;
        // To move the player to the desired position
        transform.Translate(motion * Time.deltaTime);
    }

}
