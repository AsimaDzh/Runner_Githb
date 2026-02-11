using TMPro;
using UnityEngine;

public class CollectFiles : MonoBehaviour
{
    private int fileCount = 0;

    [SerializeField] private TextMeshProUGUI fileCountText;
    [SerializeField] private TextMeshProUGUI gameOverFilesText;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Collectible"))
        {
            fileCount++;
            fileCountText.text = fileCount.ToString();
            gameOverFilesText.text = "You ate " + fileCount.ToString() + " files";
            Destroy(other.gameObject);
        }
    }
}
