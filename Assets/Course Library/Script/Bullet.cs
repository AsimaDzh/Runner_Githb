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
        Destroy(collision.gameObject);
        Destroy(gameObject);
    }

}
