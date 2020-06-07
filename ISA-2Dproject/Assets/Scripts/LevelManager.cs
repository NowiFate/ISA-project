using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static LevelManager Instance;

    public float ResetDelay = 1f;
    public GameObject ResetScreen;
    public GameObject Player;
    public GameObject boss;
    GameObject[] allEnemies;

    public Vector2 respawnPoint;
    public bool bossDefeated = false;

    private void Start()
    {
        Instance = this;

        respawnPoint = Player.transform.position;
        allEnemies = GameObject.FindGameObjectsWithTag("Enemy");
        FindObjectOfType<AudioManager>().Play("MainTheme");
    }

    public void GameOver()
    {
        BossTrigger bossTrigger = boss.GetComponent<BossTrigger>();

        PlayerMovement.scriptedEvent = true;
        ResetScreen.SetActive(true);
        FindObjectOfType<AudioManager>().StopPlaying("BossMusic");
        FindObjectOfType<AudioManager>().StopPlaying("MainTheme");
        FindObjectOfType<AudioManager>().StopPlaying("EndingTheme");
        Invoke("Resetter", ResetDelay);
    }

    public void Resetter()
    {
        BossBehaviour bossBehaviour = boss.GetComponent<BossBehaviour>();

        PlayerMovement.scriptedEvent = false;
        ResetScreen.SetActive(false);
        //resetting boss battle
        BossTrigger.bossMusicPlaying = false;
        if (bossDefeated == false)
        {
            bossBehaviour.bossHP = 3;
            bossBehaviour.bossRespawn();
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
    }
}
