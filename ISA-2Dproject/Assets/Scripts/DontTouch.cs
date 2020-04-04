using UnityEngine;
using UnityEngine.Events;

public class DontTouch : MonoBehaviour
{
    public UnityEvent youDied;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag.Equals("Player"))
        {
            youDied.Invoke();
        }
    }
}
