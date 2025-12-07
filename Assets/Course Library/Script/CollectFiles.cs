using TMPro;
using UnityEngine;

public class CollectFiles : MonoBehaviour
{
    private int fileCount = 0;

    public TextMeshProUGUI fileCountText;
    public TextMeshProUGUI gameOverFilesText;

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
