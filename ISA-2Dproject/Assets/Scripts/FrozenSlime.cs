using UnityEngine;
using UnityEngine.Events;

public class FrozenSlime : MonoBehaviour
{
    public UnityEvent youDied;
    public GameObject referencePlayer;

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
            gameObject.SetActive(false);
        }
    }
}
