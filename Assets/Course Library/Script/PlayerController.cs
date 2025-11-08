using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;
    private Animator playerAnim;
    [SerializeField] private float jumpForce;
    [SerializeField] private float gravityModifier;

    public bool isGameOver = false;
    private bool isOnGround = true;

    void Start()
    {
        playerAnim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();

        Physics.gravity *= gravityModifier;
        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
    }

    public void OnJump()
    {
        if (isOnGround)
        {
            playerAnim.SetTrigger("Jump_trig");
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isOnGround = false;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
            isOnGround = true;
        else if (collision.gameObject.CompareTag("Obstacle"))
            isGameOver = true;
    }
}
