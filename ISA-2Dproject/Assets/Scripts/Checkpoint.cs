using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    private Animator anim;

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        if(LevelManager.Instance.lastCheckpoint == gameObject)
        {
            LevelManager.Instance.respawnPoint = transform.position;
            anim.SetBool("thisOne", true);
        }
        else
        {
            anim.SetBool("thisOne", false);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            anim.SetBool("touchCheck", true);
            LevelManager.Instance.lastCheckpoint = gameObject;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        anim.SetBool("touchCheck", false);
    }
}
