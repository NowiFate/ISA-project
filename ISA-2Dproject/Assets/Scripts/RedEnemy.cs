using UnityEngine;
using UnityEngine.Events;

public class RedEnemy : MonoBehaviour
{
    public UnityEvent youDied;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            youDied.Invoke();
        }
    }

    public void EnemyDeath()
    {
        gameObject.SetActive(false);
    }
}
