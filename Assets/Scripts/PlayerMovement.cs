using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    //Declare Variables 
    public float moveSpeed;
    public Rigidbody rb;
    public float jumpForce;

    // Start is called before the first frame update
    void Start()
    {
        moveSpeed = 10;
        rb = GetComponent<Rigidbody>();
        jumpForce = 7;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            rb.velocity = new Vector3(rb.velocity.x, jumpForce, rb.velocity.z);
        }

        //Vector3( x , y , z )
        rb.velocity = new Vector3(Input.GetAxis("Horizontal") * moveSpeed,
                      rb.velocity.y, Input.GetAxis("Vertical") * moveSpeed); 
    }
}
