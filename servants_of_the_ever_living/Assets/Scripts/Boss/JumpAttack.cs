using UnityEngine;

public class JumpAttack : MonoBehaviour
{
    Rigidbody2D rb;
    public float jumpForce;
    public bool isGrounded;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    public void Jump()
    {

        rb.velocity = Vector2.up * jumpForce * Time.fixedDeltaTime;

    }
}
