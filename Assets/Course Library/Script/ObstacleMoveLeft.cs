using UnityEngine;

public class ObstacleMoveLeft : MonoBehaviour
{
    [SerializeField] private float speed;
    private PlayerController playerControllerScript;
    private float leftBound = -10f;


    void Start()
    {
        playerControllerScript = GameObject.Find("Woman").GetComponent<PlayerController>();
    }

    void Update()
    {
        if (!playerControllerScript.isGameOver)
            transform.Translate(Vector3.left * speed * Time.deltaTime);

        if (transform.position.x < leftBound && gameObject.CompareTag("Obstacle"))
            Destroy(gameObject);
    }
}
