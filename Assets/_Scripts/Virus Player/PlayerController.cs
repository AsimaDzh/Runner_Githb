using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody _rb;
    private Animator _playerAnim;
    private float _jumpForce = 28f;
    private float _gravityModifier = 8f;
    private static bool _gravityInitialized = false;

    [Header("========== GameOver ==========")]
    [SerializeField] private GameObject gameOverPanel;
    public bool isGameOver = false;
    private bool isOnGround = true;

    [Header("========== Bullet Settings ==========")]
    [SerializeField] private Transform bulletSpawnPoint;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private float bulletSpeed = 20f;

    [Header("========== Particle Effects ==========")]
    [SerializeField] private ParticleSystem explosionParticle;
    [SerializeField] private ParticleSystem dirtParticle;
    [SerializeField] private ParticleSystem landDirtParticle;

    [Header("========== Audio Clips ==========")]
    [SerializeField] private AudioClip jumpSound;
    [SerializeField] private AudioClip crashSound;
    [SerializeField] private AudioSource playerAudio;


    void Start()
    {
        playerAudio = GetComponent<AudioSource>();
        _playerAnim = GetComponent<Animator>();
        _rb = GetComponent<Rigidbody>();

        if (!_gravityInitialized)
        {
            Physics.gravity *= _gravityModifier;
            _gravityInitialized = true;
        }
    }


    public void OnJump()
    {
        if (isOnGround && !isGameOver)
        {
            isOnGround = false;

            _playerAnim.SetTrigger("Jump_trig");
            _rb.AddForce(Vector3.up * _jumpForce, ForceMode.Impulse);

            dirtParticle.Stop();
            playerAudio.PlayOneShot(jumpSound, 1.0f);
        }
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;

            landDirtParticle.Play();
            dirtParticle.Play();
        }
        else if (collision.gameObject.CompareTag("Obstacle"))
        {
            isGameOver = true;
            gameOverPanel.SetActive(true);

            _playerAnim.SetBool("Death_b", true);
            _playerAnim.SetInteger("DeathType_int", 1);

            explosionParticle.Play();
            dirtParticle.Stop();
            playerAudio.PlayOneShot(crashSound, 1.0f);
        }
        else if (collision.gameObject.CompareTag("EnemyBullet"))
        {
            isGameOver = true;
            gameOverPanel.SetActive(true);

            _playerAnim.SetBool("Death_b", true);
            _playerAnim.SetInteger("DeathType_int", 2);

            explosionParticle.Play();
            dirtParticle.Stop();
            playerAudio.PlayOneShot(crashSound, 1.0f);
        }
    }


    public void OnFire()
    {
        if (!isGameOver)
        {
            var bullet = Instantiate(
                bulletPrefab, 
                bulletSpawnPoint.position, 
                Quaternion.identity);
            Rigidbody bulletRb = bullet.GetComponent<Rigidbody>();
            bulletRb.linearVelocity = Vector3.right * bulletSpeed;
        }
    }
}
