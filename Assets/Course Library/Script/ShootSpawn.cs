using UnityEngine;

public class ShootSpawn : MonoBehaviour
{
    public GameObject enemyShootPrefab;
    public Transform enemyShootPoint;
    [SerializeField] private float shootSpeed = 20f;
    [SerializeField] private float timer;

    private PlayerController playerControllerScript;
    private EnemySpawn enemySpawnScript;


    void Start()
    {
        playerControllerScript = GameObject.Find("Woman").GetComponent<PlayerController>();
        enemySpawnScript = GetComponentInParent<EnemySpawn>();
    }

    void Update()
    {
        timer += Time.deltaTime;

        if (timer > 2f)
        {
            timer = 0f;
            EnemyShoot();
        }
    }

    void EnemyShoot()
    {
        if (!playerControllerScript.isGameOver && !enemySpawnScript.isDeadFlag)
        {
            var bullet = Instantiate(enemyShootPrefab, enemyShootPoint.position, Quaternion.identity);
            Rigidbody rb = bullet.GetComponent<Rigidbody>();
            rb.linearVelocity = Vector3.left * shootSpeed;
        }
    }
}
