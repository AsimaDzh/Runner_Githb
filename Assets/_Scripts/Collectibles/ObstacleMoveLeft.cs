using UnityEngine;

public class ObstacleMoveLeft : MonoBehaviour
{
    [SerializeField] private float speed;

    private PlayerController _playerController;
    private float _leftBound = -10f;


    void Start()
    {
        _playerController = GameObject.Find("Woman").GetComponent<PlayerController>();
    }


    void Update()
    {
        if (!_playerController.isGameOver)
            transform.Translate(Vector3.left * speed * Time.deltaTime);

        if (transform.position.x < _leftBound && !gameObject.CompareTag("Paralax"))
            Destroy(gameObject);
    }
}