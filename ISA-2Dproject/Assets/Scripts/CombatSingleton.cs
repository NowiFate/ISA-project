using UnityEngine;

public class Combat : MonoBehaviour
{
    public GameObject weaponType;

    private float weaponNumber;
    public float startTimeBtwAttacks;
    private float timeBtwAttacks;
    private float attackRange;

    public Transform attackPos;
    public LayerMask whatIsEnemy;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(weaponType != null)
        {
            WeaponScript weaponScript = weaponType.GetComponent<WeaponScript>();
            weaponNumber = weaponScript.weaponStateNumber;
            startTimeBtwAttacks = weaponScript.localStartTimeBtwAttacks;
            attackRange = weaponScript.localAttackRange;
            weaponScript.localWeaponText.SetActive(true);
        }

        //combat
        if (timeBtwAttacks <= 0)
        {
            if (Input.GetKey(KeyCode.E))
            {
                //wapen geluid effect
                if (weaponNumber == 1 || weaponNumber == 3)
                {
                    FindObjectOfType<AudioManager>().Play("SlashSound");
                }

                if (weaponNumber == 2)
                {
                    FindObjectOfType<AudioManager>().Play("FireSlash");
                }

                Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll(attackPos.position, attackRange, whatIsEnemy);
                for (int i = 0; i < enemiesToDamage.Length; i++)
                {
                    if (enemiesToDamage[i].GetComponent<RedEnemy>() != null)
                    {
                        enemiesToDamage[i].GetComponent<RedEnemy>().EnemyDeath();
                    }

                    if (enemiesToDamage[i].GetComponent<FrozenSlime>() != null)
                    {
                        enemiesToDamage[i].GetComponent<FrozenSlime>().FrozenDeath();
                    }

                    if (enemiesToDamage[i].GetComponent<BossBehaviour>() != null)
                    {
                        enemiesToDamage[i].GetComponent<BossBehaviour>().BossLifes();
                    }
                }
                timeBtwAttacks = startTimeBtwAttacks;
            }
        }
        else
        {
            timeBtwAttacks -= Time.deltaTime;
        }
    }
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPos.position, attackRange);
    }
}
