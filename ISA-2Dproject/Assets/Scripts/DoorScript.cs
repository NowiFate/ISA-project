using UnityEngine;

public class DoorScript : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    public Sprite openDoor, closedDoor;
    private bool isOpen = false;
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
            if (LevelManager.Instance.numberOfKeys > 0 && isOpen == false)
            {
                spriteRenderer.sprite = openDoor;
                boxCollider.enabled = false;
                isOpen = true;
                LevelManager.Instance.numberOfKeys -= 1;
            }
        }
    }

    public void GetAKey()
    {
        LevelManager.Instance.numberOfKeys += 1;
    }
}
