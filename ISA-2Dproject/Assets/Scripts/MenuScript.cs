using UnityEngine.SceneManagement;
using UnityEngine;

public class MenuScript : MonoBehaviour
{
    public void NextScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void CloseGame()
    {
        Application.Quit();
    }
}
