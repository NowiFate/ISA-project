using System.Collections.Generic;
using UnityEngine;

public class CombatSingleton : MonoBehaviour
{
    public static CombatSingleton Instance;

    [HideInInspector]
    public GameObject weaponType;
    private bool qPressed = false;

    private int selectedWeapon;
    public float startTimeBtwAttacks;
    private float timeBtwAttacks;
    private float attackRange;

    WeaponScript weaponScript;
    public Transform attackPos;
    public LayerMask whatIsEnemy;

    public List<GameObject> currentWeapons;

    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
        weaponType = currentWeapons[selectedWeapon];
        weaponScript = weaponType.GetComponent<WeaponScript>();
        weaponScript.localWeaponText.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if(weaponType != null)
        {
            weaponScript = weaponType.GetComponent<WeaponScript>();
            startTimeBtwAttacks = weaponScript.localStartTimeBtwAttacks;
            attackRange = weaponScript.localAttackRange;
        }

        if (LevelManager.Instance.scriptedEvent == false)
        {
            //Press Q to switch weapons
            if (Input.GetKey(KeyCode.Q))
            {
                if (qPressed == false)
                {
                    WeaponSwitch();
                    qPressed = true;
                }
            }
            else
            {
                qPressed = false;
            }

            //combat
            if (timeBtwAttacks <= 0)
            {
                if (Input.GetKey(KeyCode.E))
                {
                    //wapen geluid effect
                    if (weaponScript.weaponStateNumber == 1 || weaponScript.weaponStateNumber == 3) FindObjectOfType<AudioManager>().Play("SlashSound");

                    if (weaponScript.weaponStateNumber == 2) FindObjectOfType<AudioManager>().Play("FireSlash");

                    Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll(attackPos.position, attackRange, whatIsEnemy);
                    for (int i = 0; i < enemiesToDamage.Length; i++)
                    {
                        if (enemiesToDamage[i].GetComponent<RedEnemy>() != null) enemiesToDamage[i].GetComponent<RedEnemy>().EnemyDeath();

                        if (enemiesToDamage[i].GetComponent<FrozenSlime>() != null) enemiesToDamage[i].GetComponent<FrozenSlime>().FrozenDeath();

                        if (enemiesToDamage[i].GetComponent<BossBehaviour>() != null) enemiesToDamage[i].GetComponent<BossBehaviour>().BossLifes();
                    }
                    timeBtwAttacks = startTimeBtwAttacks;
                }
            }
            else
            {
                timeBtwAttacks -= Time.deltaTime;
            }
        }
    }

    private void WeaponSwitch()
    {
        weaponScript = weaponType.GetComponent<WeaponScript>();

        weaponScript.localWeaponText.SetActive(false);
        selectedWeapon+=1;
        if (selectedWeapon > currentWeapons.Count-1) selectedWeapon = 0;
        weaponType = currentWeapons[selectedWeapon];

        weaponScript = weaponType.GetComponent<WeaponScript>();
        weaponScript.localWeaponText.SetActive(true);
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPos.position, attackRange);
    }
}
