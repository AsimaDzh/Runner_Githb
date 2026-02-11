using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] GameObject[] spawnablePrefabs;

    private Vector3 _spawnPos = new Vector3(25f, 1.3f, 0f);
    private float _startDelay = 2f;
    private float _repeatRate = 2f;

    private PlayerController _playerController;


    void Start()
    {
        _playerController = GameObject.Find("Woman").GetComponent<PlayerController>();

        InvokeRepeating("SpawnObstacle", _startDelay, _repeatRate);
    }


    void SpawnObstacle()
    {
        if (!_playerController.isGameOver)
            Instantiate(
                spawnablePrefabs[Random.Range(0, spawnablePrefabs.Length)], 
                _spawnPos, 
                Quaternion.identity);
    }
}
