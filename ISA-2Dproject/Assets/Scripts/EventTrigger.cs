using UnityEngine;
using UnityEngine.Events;

public class EventTrigger : MonoBehaviour
{
    public UnityEvent triggered;

    private void OnTriggerEnter2D(Collider2D other)
    {
        triggered.Invoke();
    }
}
