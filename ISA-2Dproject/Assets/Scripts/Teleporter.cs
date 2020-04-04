using UnityEngine;

public class Teleporter : MonoBehaviour
{
    [SerializeField] private Transform teleport;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name == "Player")
        {
            other.transform.position = teleport.position;
        }
    }
}
