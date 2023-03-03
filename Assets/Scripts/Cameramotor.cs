using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cameramotor : MonoBehaviour
{
    //Game Objects
    public Transform PlayerPosition;

    public float boundX = 0.2f;
    public float boundY = 0.05f;
    void Start()
    {
        transform.position = new Vector3(PlayerPosition.position.x,PlayerPosition.position.y,-10);
    }

   
    void LateUpdate()
    {
        Vector3 delta= Vector3.zero;

        // To check if player is inside the bounds for x axis.
        float deltax = PlayerPosition.position.x - transform.position.x;
        if(deltax > boundX || deltax < -boundX)
        {
            if (transform.position.x < PlayerPosition.position.x)
            {
                delta.x = deltax - boundX;
            }
            else
            {
                delta.x = deltax + boundX;
            }
        }

        // To check if player is inside the bounds for y axis.
        float deltaY = PlayerPosition.position.y- transform.position.y;
        if (deltaY > boundY || deltaY < -boundY)
        {
            if (transform.position.y < PlayerPosition.position.y)
            {
                delta.y = deltaY - boundY;
            }
            else
            {
                delta.y = deltaY + boundY;
            }
        }

        transform.position += new Vector3(delta.x, delta.y, 0);
    }
}
