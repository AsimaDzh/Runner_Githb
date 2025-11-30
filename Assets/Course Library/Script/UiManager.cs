using UnityEngine;
using UnityEngine.SceneManagement;

public class UiManager : MonoBehaviour
{


    public void Quit()
    {
        Application.Quit();
    }

    public void Restart()
    {
        SceneManager.LoadScene("Prototype 3");
    }
}
