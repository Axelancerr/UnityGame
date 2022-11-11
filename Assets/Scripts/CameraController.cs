using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    //Declare variables
    public Transform target;
    public Vector3 offset;
    //Used to toggle a default offset or allow us to change the 
    //value
    public bool useOffsetValues;
    public float rotateSpeed;

    public Transform pivot;

    // Start is called before the first frame update
    void Start()
    {
        if (!useOffsetValues)
        {
            //checking the distance between the camera and player
            //set that distance value to the offset
            offset = target.position - transform.position;
        }

        pivot.transform.position = target.transform.position;
        pivot.transform.parent = target.transform;

        Cursor.lockState = CursorLockMode.Locked;

    }

    // Update is called once per frame
    void Update()
    {

        //get the x position of the mouse & rotate the target
        float horizontal = Input.GetAxis("Mouse X") * rotateSpeed;
        target.Rotate(0, horizontal, 0);

        //get the y position of the mouse & rotate the target
        float vertical = Input.GetAxis("Mouse Y") * rotateSpeed;
        pivot.Rotate(vertical, 0, 0);

        //move the camera based on the current rotation of the target & offset
        float desiredYAngle = target.eulerAngles.y;
        float desiredXangle = pivot.eulerAngles.x;
        Quaternion rotation = Quaternion.Euler(desiredXangle, desiredYAngle, 0);
        transform.position = target.position - (rotation * offset);

        //check the camera is going below the players feet
        if(transform.position.y < target.position.y)
        {
            transform.position = new Vector3(transform.position.x,
                transform.position.y -.5f, transform.position.z);
        }

        transform.LookAt(target);
        //transform.position = target.position - offset;
    }
}
