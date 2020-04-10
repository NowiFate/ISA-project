using UnityEngine;

public class BossTrigger : MonoBehaviour
{
    public bool begin = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag.Equals("Player"))
        {
            begin = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        begin = false;
    }
}
