using UnityEngine;

public class FollowTrigger : MonoBehaviour
{
    public bool triggered = false;

    public GameObject referredPlayer;

    private void Update()
    {
        triggered = false;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (CombatSingleton.Instance.weaponType.name != "NinjaWeapon")
        {
            triggered = true;
        }
    }
}
