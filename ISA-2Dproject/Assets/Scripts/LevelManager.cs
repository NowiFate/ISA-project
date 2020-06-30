using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public static LevelManager Instance;

    public float ResetDelay = 1f;
    public GameObject ResetScreen;
    public GameObject Player;
    public GameObject boss;
    public GameObject lastCheckpoint;
    public GameObject keyText;
    GameObject[] allEnemies;

    public Vector2 respawnPoint;
    public bool bossDefeated = false;
    public bool scriptedEvent = false;
    public int numberOfKeys = 0;

    private void Start()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        respawnPoint = Player.transform.position;
        allEnemies = GameObject.FindGameObjectsWithTag("Enemy");
        FindObjectOfType<AudioManager>().Play("MainTheme");
    }

    private void Update()
    {
        if (numberOfKeys > 0 && keyText != null) keyText.SetActive(true);
        else keyText.SetActive(false);
    }

    public void GameOver()
    {
        scriptedEvent = true;
        ResetScreen.SetActive(true);
        FindObjectOfType<AudioManager>().StopPlaying("BossMusic");
        FindObjectOfType<AudioManager>().StopPlaying("MainTheme");
        FindObjectOfType<AudioManager>().StopPlaying("EndingTheme");
        Invoke("Resetter", ResetDelay);
    }

    public void Resetter()
    {
        BossBehaviour bossBehaviour = boss.GetComponent<BossBehaviour>();

        ResetScreen.SetActive(false);
        //resetting boss battle
        BossTrigger.bossMusicPlaying = false;
        if (bossDefeated == false)
        {
            bossBehaviour.bossHP = 3;
            bossBehaviour.BossRespawn();
            FindObjectOfType<AudioManager>().Play("MainTheme");
        }
        else
        {
            FindObjectOfType<AudioManager>().Play("EndingTheme");
        }
        //Checkpoint respawn
        Player.transform.position = respawnPoint;
        //Enemies respawnen
        foreach (GameObject enms in allEnemies)
        {
            enms.SetActive(true);
        }
        scriptedEvent = false;
    }

    public void NextPhase()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
