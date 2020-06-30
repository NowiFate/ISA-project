using UnityEngine;
using UnityEngine.Events;

public class FrozenSlime : MonoBehaviour
{
    public UnityEvent youDied;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
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
