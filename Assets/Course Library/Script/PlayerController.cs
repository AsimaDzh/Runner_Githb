using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;
    private Animator playerAnim;
    private float jumpForce = 28f;
    private float gravityModifier = 8f;

    [Header("========== GameOver ==========")]
    public bool isGameOver = false;
    private bool isOnGround = true;

    [Header("========== Bullet Settings ==========")]
    public Transform bulletSpawnPoint;
    public GameObject bulletPrefab;
    [SerializeField] private float bulletSpeed = 20f;

    [Header("========== Particle Effects ==========")]
    public ParticleSystem explosionParticle;
    public ParticleSystem dirtParticle;

    [Header("========== Audio Clips ==========")]
    public AudioClip jumpSound;
    public AudioClip crashSound;
    private AudioSource playerAudio;

    void Start()
    {
        playerAudio = GetComponent<AudioSource>();
        playerAnim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();

        Physics.gravity *= gravityModifier;
    }

    public void OnJump()
    {
        if (isOnGround && !isGameOver)
        {
            isOnGround = false;

            playerAnim.SetTrigger("Jump_trig");
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);

            dirtParticle.Stop();
            playerAudio.PlayOneShot(jumpSound, 1.0f);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;

            dirtParticle.Play();
        }
        else if (collision.gameObject.CompareTag("Obstacle"))
        {
            isGameOver = true;

            playerAnim.SetBool("Death_b", true);
            playerAnim.SetInteger("DeathType_int", 1);

            explosionParticle.Play();
            dirtParticle.Stop();
            playerAudio.PlayOneShot(crashSound, 1.0f);
        }
    }

    public void OnFire()
    {
        if (!isGameOver)
        {
            playerAnim.SetBool("Shoot_b", true);

            var bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, Quaternion.identity);
            Rigidbody bulletRb = bullet.GetComponent<Rigidbody>();
            bulletRb.linearVelocity = Vector3.right * bulletSpeed;
        }
    }
}
