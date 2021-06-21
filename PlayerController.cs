
using UnityEngine;
public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 9f;
    public float jumpForce = 10f;
    private bool onGround = true;
    private Vector3 moveDirection;
    Rigidbody rb;
     void Awake()
    {
       rb = GetComponent<Rigidbody>();
    }
    
    void Update()
    {
        rb.velocity = new Vector3(Input.GetAxis("Horizontal") * moveSpeed, rb.velocity.y, Input.GetAxis("Vertical") * moveSpeed);

        if (Input.GetButtonDown("Jump") && onGround)
        {
            rb.velocity = new Vector3(rb.velocity.x, jumpForce, rb.velocity.z);
            onGround = false;
        }
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ground") {onGround = true;}
    }


}