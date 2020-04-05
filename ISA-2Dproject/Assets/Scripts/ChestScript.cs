﻿using UnityEngine;

public class ChestScript : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;

    public Sprite openChest, closedChest;

    private bool isOpen = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (isOpen == false) //Ik wil dat je op e moet drukken, dus misschien later
            {
                isOpen = true;
                spriteRenderer.sprite = openChest;
            }
        }
    }
}
