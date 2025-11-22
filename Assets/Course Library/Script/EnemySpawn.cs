using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    private Object _enemyRef;
    private GameObject _visualEnemy;

    void Start()
    {
        _enemyRef = Resources.Load("waspy");
        _visualEnemy = transform.GetChild(0).gameObject;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Bullet"))
        {
            _visualEnemy.SetActive(false);
            Invoke("Respawn", 5f);
            Destroy(other.gameObject);
        }
    }

    private void Respawn()
    {
        GameObject enemyClone = (GameObject)Instantiate(_enemyRef);
        enemyClone.transform.position = transform.position;

        Destroy(gameObject);
    }
}

