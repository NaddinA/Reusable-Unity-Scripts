
using UnityEngine;
public class PlayerCC : MonoBehaviour
{
    public float moveSpeed = 9f;
    public float jumpForce = 10f;
    public float gravityScale = 1f;
    private Vector3 moveDirection;
    CharacterController controller;

     void Awake()
    {
        controller = GetComponent<CharacterController>();
        GetComponent<CapsuleCollider>();
    }
    
    void Update()
    {
        float yStore = moveDirection.y;
        moveDirection = (transform.forward * Input.GetAxis("Vertical")) + (transform.right * Input.GetAxis("Horizontal")); 
        //transform.forward is a vector that points forward for the player gameObject while taking into account its rotation (I need to use it since mouse (the camera) is manipulating direction of player using rotations). Im multiplying the output vectors by the corresponding input in this case for smoother movement.

        moveDirection = Vector3.ClampMagnitude(moveDirection, 1) * moveSpeed; //decelerates movement after key is released!!:D
        moveDirection.y = yStore;

        if(controller.isGrounded)
        {
            moveDirection.y = 0f;
            //whether or not moveDirection is within isGrounded{} can either limit the player from or allow them to move/rotate while jumping. 

            if(Input.GetButtonDown("Jump")) 
            {
                moveDirection.y = jumpForce;
            }
        }

        moveDirection.y = moveDirection.y + (Physics.gravity.y * gravityScale * Time.deltaTime);
        controller.Move(moveDirection * Time.deltaTime);
    }
    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Platform")
        {
             transform.parent = other.gameObject.transform; 
        }
    }

    void OnTriggerExit(Collider other)
    {
        transform.parent = null;
    }
 }
