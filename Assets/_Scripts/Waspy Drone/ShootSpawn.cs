using UnityEngine;

public class ShootSpawn : MonoBehaviour
{
    [SerializeField] private GameObject enemyShootPrefab;
    [SerializeField] private Transform enemyShootPoint;
    [SerializeField] private float shootSpeed = 20f;
    [SerializeField] private float timer;

    private PlayerController _playerController;
    private EnemySpawn _enemySpawn;


    void Start()
    {
        _playerController = GameObject.Find("Woman").GetComponent<PlayerController>();
        _enemySpawn = GetComponentInParent<EnemySpawn>();
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
        if (!_playerController.isGameOver && !_enemySpawn.isDeadFlag)
        {
            var bullet = Instantiate(
                enemyShootPrefab, 
                enemyShootPoint.position, 
                Quaternion.identity);
            Rigidbody rb = bullet.GetComponent<Rigidbody>();
            rb.linearVelocity = Vector3.left * shootSpeed;
        }
    }
}
