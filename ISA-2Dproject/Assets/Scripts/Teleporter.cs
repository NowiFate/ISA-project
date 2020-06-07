using UnityEngine;

public class Teleporter : MonoBehaviour
{
    public Transform teleport;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name == "Player")
        {
            other.transform.position = teleport.position;
        }
    }
}
