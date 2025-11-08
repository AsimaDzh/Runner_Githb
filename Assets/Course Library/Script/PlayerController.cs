using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;
    [SerializeField] private float jumpForce;
    [SerializeField] private float gravityModifier;
    private bool isOnGround = true;
    public bool isGameOver = false;


    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Physics.gravity *= gravityModifier;
        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
    }

    public void OnJump()
    {
        if (isOnGround)
        {
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
