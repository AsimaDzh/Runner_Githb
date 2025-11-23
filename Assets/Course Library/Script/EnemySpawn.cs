using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    private Object _enemyRef;
    private Vector3 _startPosition;
    [SerializeField] private float delayBeforeDestroy = 5f;


    private PlayerController playerControllerScript;

    public GameObject enemyShootPrefab;
    public Transform enemyShootPoint;
    [SerializeField] private float shootSpeed = 20f;


    void Start()
    {
        playerControllerScript = GameObject.Find("Woman").GetComponent<PlayerController>();
        _startPosition = transform.position;
        _enemyRef = Resources.Load("waspy");

        InvokeRepeating("EnemyShoot", 2f, 2f);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Bullet"))
        {
            gameObject.SetActive(false);
            Invoke("Respawn", delayBeforeDestroy);
            Destroy(other.gameObject);
        }
    }

    private void Respawn()
    {
        if (!playerControllerScript.isGameOver)
        {
            GameObject enemyClone = (GameObject)Instantiate(_enemyRef);
            enemyClone.transform.position = new Vector3(Random.Range(
                _startPosition.x - 2, _startPosition.x + 2),
                _startPosition.y,
                _startPosition.z);
        }
        Destroy(gameObject);
    }

    void EnemyShoot()
    {
        if (!playerControllerScript.isGameOver)
        {
            var bullet = Instantiate(enemyShootPrefab, enemyShootPoint.position, Quaternion.identity);
            Rigidbody rb = bullet.GetComponent<Rigidbody>();
            rb.linearVelocity = Vector3.left * shootSpeed;
        }
    }
}