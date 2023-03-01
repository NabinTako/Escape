using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ChaseRange : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {


    }
    private void OnTriggerStay2D(Collider2D other)
    {
        GetComponentInParent<Enemy>().chase = true;
        GetComponentInParent<Enemy>().playerPosition = other.transform.position;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        GetComponentInParent<Enemy>().chase = false;
    }


}
