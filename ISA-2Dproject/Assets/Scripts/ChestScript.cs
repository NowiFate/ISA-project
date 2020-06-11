using UnityEngine;
using UnityEngine.Events;

public class ChestScript : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    public Sprite openChest, closedChest;

    public GameObject itemScreen;
    private bool screenOn = false;
    private bool isOpen = false;
    [Space]
    public GameObject weaponInChest;
    public UnityEvent chestEvents;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (isOpen == false)
            {
                //Open Chest
                isOpen = true;
                spriteRenderer.sprite = openChest;
                FindObjectOfType<AudioManager>().Play("ChestSound");
                chestEvents.Invoke();
                if(itemScreen != null)
                {
                    itemScreen.SetActive(true);
                    screenOn = true;
                }

                //Add weapon
                if(weaponInChest != null)
                {
                    CombatSingleton.Instance.currentWeapons.Add(weaponInChest);
                }
            }
        }
    }

    //ItemScreen
    private void Update()
    {
        if (itemScreen != null)
        {

            if (screenOn == true)
            {
                LevelManager.Instance.scriptedEvent = true;
            }

            if (Input.GetKey(KeyCode.E))
            {
                screenOn = false;
                itemScreen.SetActive(false);
                LevelManager.Instance.scriptedEvent = false;
            }
        }
    }
}
