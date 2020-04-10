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
        Combat combat = referencePlayer.GetComponent<Combat>();

        if (combat.weaponType.name == "FireWeapon")
        {
            Destroy(gameObject);
        }
    }
}
