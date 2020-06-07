using UnityEngine;

public class ChestScript : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    public Sprite openChest, closedChest;

    public GameObject itemScreen;
    private bool screenOn = false;

    private bool isOpen = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (isOpen == false)
            {
                isOpen = true;
                spriteRenderer.sprite = openChest;
                FindObjectOfType<AudioManager>().Play("ChestSound");
                itemScreen.SetActive(true);
                screenOn = true;
            }
        }
    }

    //ItemScreen
    private void Update()
    {
        if (screenOn == true)
        {
            PlayerMovement.scriptedEvent = true;
        }

        if (Input.GetKey(KeyCode.E))
        {
            screenOn = false;
            itemScreen.SetActive(false);
            PlayerMovement.scriptedEvent = false;
        }
    }
}
