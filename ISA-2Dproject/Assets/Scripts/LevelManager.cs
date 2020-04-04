using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public float ResetDelay = 1f;

    public GameObject ResetScreen;

    public void GameOver()
    {
        ResetScreen.SetActive(true);
        Invoke("Resetter", ResetDelay);
    }

    public void Resetter()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
