using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    public GameObject Manager;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            LevelManager levelmanager = Manager.GetComponent<LevelManager>();
            levelmanager.respawnPoint = transform.position;
        }
    }
}
