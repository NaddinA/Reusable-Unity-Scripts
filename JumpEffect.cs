
using UnityEngine;

public class JumpEffect : MonoBehaviour
{
    public float fallMultiplier = 3f;
    public float lowJumpMultiplier = 2f;
    public float gravityScale = 1f;
    private float globalGravity = -9.81f;

    private Rigidbody rb;

 void Start ()
    {
        rb = GetComponent<Rigidbody>();
        rb.useGravity = false;
 }
 
 void FixedUpdate ()
    {
        Vector3 gravity = globalGravity * gravityScale * Vector3.up;
  if (rb.velocity.y < 0)
        {
            rb.AddForce(gravity * fallMultiplier, ForceMode.Acceleration);
        }
        else if (rb.velocity.y > 0 && !Input.GetButton("Jump"))
        {
            rb.AddForce(gravity * lowJumpMultiplier, ForceMode.Acceleration);
        }
        else
        {
            rb.AddForce(gravity, ForceMode.Acceleration);
        }
 }
}