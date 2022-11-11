using UnityEngine;

public class PlayerMovementV2 : MonoBehaviour
{
    //Declare Variables 
    public float moveSpeed;
    public float jumpForce;
    public CharacterController controller;
    public float gravityScale;
    private Vector3 moveDirection;

    // Start is called before the first frame update
    void Start()
    {
        moveSpeed = 10;
        controller = GetComponent<CharacterController>();
        jumpForce = 30;
        gravityScale = 0.05f;
    }

    // Update is called once per frame
    void Update()
    {
        float currentYValue = moveDirection.y;
        moveDirection = (transform.right * Input.GetAxis("Horizontal")) +
                        (transform.forward * Input.GetAxis("Vertical"));

        //remove the extra speed on diagonal movement
        moveDirection = moveDirection.normalized * moveSpeed;
        moveDirection.y = currentYValue;

        if (controller.isGrounded)
        {
            moveDirection.y = 0f;
            if (Input.GetButtonDown("Jump"))
            {
                moveDirection.y = jumpForce;
            }
        }


        moveDirection.y += (Physics.gravity.y * gravityScale);

        controller.Move(moveDirection * Time.deltaTime);
    }
}