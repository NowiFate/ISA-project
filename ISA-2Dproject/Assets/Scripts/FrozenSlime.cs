using UnityEngine;
using UnityEngine.Events;

public class FrozenSlime : MonoBehaviour
{
    public GameObject referencePlayer;
    public UnityEvent youDied;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag.Equals("Player"))
        {
            youDied.Invoke();
        }
    }

    public void FrozenDeath()
    {
        if (CombatSingleton.Instance.weaponType.name == "FireWeapon")
        {
            FindObjectOfType<AudioManager>().Play("IceBreaking");
            gameObject.SetActive(false);
        }
        else
        {
            FindObjectOfType<AudioManager>().Play("HittingIce");
        }
    }
}
