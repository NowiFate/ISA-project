using UnityEngine;

public class Roomtransition : MonoBehaviour
{
    public Vector3 cameraShove;
    public Vector3 playerShove;
    public Camera mainCam;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            mainCam.transform.position += cameraShove;
            other.transform.position += playerShove;
        }
    }
}
