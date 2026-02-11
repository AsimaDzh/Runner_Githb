using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float life = 2f;

    private void Awake()
    {
        Destroy(gameObject, life);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Obstacle")
            || collision.gameObject.CompareTag("Collectible"))
            Destroy(gameObject);
    }
}
