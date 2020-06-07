using UnityEngine;

public class FollowTrigger : MonoBehaviour
{
    public bool triggered = false;

    public GameObject referredPlayer;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (CombatSingleton.Instance.weaponType.name != "NinjaWeapon")
        {
            triggered = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        triggered = false;
    }
}
