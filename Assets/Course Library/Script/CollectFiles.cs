using TMPro;
using UnityEngine;

public class CollectFiles : MonoBehaviour
{
    private int fileCount = 0;

    public TextMeshProUGUI fileCountText;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Collectible"))
        {
            fileCount++;
            fileCountText.text = fileCount.ToString();
            Destroy(other.gameObject);
        }
    }
}
