using UnityEngine;

public class EnemySpawning : MonoBehaviour
{
    public GameObject[] enemies;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag.Equals("Player"))
        {
            for (int i = 0; i < enemies.Length; i++)
            {
                enemies[i].SetActive(true);
            }
        }
    }
}
