using System.Collections;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    private Object _enemyRef;
    private Vector3 _startPosition;
    private float delayBeforeDestroy = 5f;

    private PlayerController playerControllerScript;
    private Animator enemyAnim;

    public bool isDeadFlag = false;
    public ParticleSystem deathParticle;

    public AudioClip deathSound;
    private AudioSource enemyAudio;

    void Start()
    {
        playerControllerScript = GameObject.Find("Woman").GetComponent<PlayerController>();
        _enemyRef = Resources.Load("waspy");
        enemyAnim = GetComponent<Animator>();
        enemyAudio = GetComponent<AudioSource>();

        _startPosition = transform.position;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Bullet") && !isDeadFlag)
        {
            isDeadFlag = true;
            Destroy(other.gameObject);

            enemyAudio.PlayOneShot(deathSound, 1.0f);
            deathParticle.Play();
            enemyAnim.SetBool("isDead", true); //Help

            var col = GetComponent<Collider>();
            if (col != null) col.enabled = false;

            StartCoroutine(DeathAndRespawnRoutine());
        }
    }

    private IEnumerator DeathAndRespawnRoutine()
    {
        float waitTime = 1.2f;
        yield return new WaitForSeconds(waitTime);

        gameObject.SetActive(false);
        Invoke("Respawn", delayBeforeDestroy);
    }

    private void Respawn()
    {
        if (!playerControllerScript.isGameOver)
        {
            GameObject enemyClone = (GameObject)Instantiate(_enemyRef);
            enemyClone.transform.position = new Vector3(Random.Range(
                _startPosition.x - 1, _startPosition.x + 1),
                _startPosition.y,
                _startPosition.z);
        }
        Destroy(gameObject);
    }
}