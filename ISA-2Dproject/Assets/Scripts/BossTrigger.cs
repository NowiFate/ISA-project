﻿using UnityEngine;

public class BossTrigger : MonoBehaviour
{
    public bool beginBossBattle = false;
    public GameObject boss;
    public GameObject gameMananger;
    public GameObject leftCollider, rightCollider;
    public static bool bossMusicPlaying = false;

    private void Update()
    {
        if (beginBossBattle == true)
        {
            boss.SetActive(true);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        LevelManager levelManager = gameMananger.GetComponent<LevelManager>();

        if (other.gameObject.tag.Equals("Player") && levelManager.bossDefeated == false)
        {
            beginBossBattle = true;
            if (leftCollider != null) leftCollider.SetActive(true);
            if (rightCollider != null) rightCollider.SetActive(true);
            if (bossMusicPlaying == false)
            {
                FindObjectOfType<AudioManager>().StopPlaying("MainTheme");
                //play boss music
                FindObjectOfType<AudioManager>().Play("BossMusic");
                bossMusicPlaying = true;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        beginBossBattle = false;
        leftCollider.SetActive(false);
        rightCollider.SetActive(false);
    }
}
