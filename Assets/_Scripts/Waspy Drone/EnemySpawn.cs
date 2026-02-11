using System.Collections;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    private Object _enemyRef;
    private Vector3 _startPosition;
    private float _delayBeforeDestroy = 5f;

    private PlayerController _playerController;
    private Animator _enemyAnim;

    public bool isDeadFlag = false;
    
    [SerializeField] private ParticleSystem deathParticle;
    [SerializeField] private AudioClip deathSound;
    private AudioSource _enemyAudio;
    

    void Start()
    {
        _playerController = GameObject.Find("Woman").GetComponent<PlayerController>();
        _enemyRef = Resources.Load("waspy");
        _enemyAnim = GetComponent<Animator>();
        _enemyAudio = GetComponent<AudioSource>();

        _startPosition = transform.position;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Bullet") && !isDeadFlag)
        {
            isDeadFlag = true;
            Destroy(other.gameObject);

            _enemyAudio.PlayOneShot(deathSound, 1.0f);
            deathParticle.Play();
            _enemyAnim.SetBool("isDead", true);

            var col = GetComponent<Collider>();
            if (col != null) 
                col.enabled = false;

            StartCoroutine(DeathAndRespawnRoutine());
        }
    }

    private IEnumerator DeathAndRespawnRoutine()
    {
        float _waitTime = 1.2f;
        yield return new WaitForSeconds(_waitTime);

        gameObject.SetActive(false);
        Invoke("Respawn", _delayBeforeDestroy);
    }

    private void Respawn()
    {
        if (!_playerController.isGameOver)
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