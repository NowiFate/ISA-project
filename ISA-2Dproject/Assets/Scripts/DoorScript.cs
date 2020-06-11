using UnityEngine;

public class DoorScript : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    public Sprite openDoor, closedDoor;
    private bool isOpen = false;
    public int numberOfKeys = 0;
    private BoxCollider2D boxCollider;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = this.GetComponent<SpriteRenderer>();
        boxCollider = this.GetComponent<BoxCollider2D>();
        spriteRenderer.sprite = closedDoor;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (numberOfKeys > 0 && isOpen == false)
            {
                spriteRenderer.sprite = openDoor;
                boxCollider.enabled = false;
                isOpen = true;
                numberOfKeys -= 1;
            }
        }
    }

    public void GetAKey()
    {
        numberOfKeys += 1;
    }
}
