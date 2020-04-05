using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 8f;
    public float extraSpeedForRunning = 3f;
    private float timeBtwAttacks;
    public float startTimeBtwAttacks;
    public Transform attackPos;
    public float attackRange;
    public LayerMask whatIsEnemy;

    public static bool scriptedEvent = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (scriptedEvent == false)
        {
            //Movement
            Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0f);

            transform.position += movement * Time.deltaTime * moveSpeed;

            //rennen
            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                moveSpeed += extraSpeedForRunning;
            }

            if (Input.GetKeyUp(KeyCode.LeftShift))
            {
                moveSpeed -= extraSpeedForRunning;
            }

            //combat
            if (timeBtwAttacks <= 0)
            {
                if (Input.GetKey(KeyCode.E))
                {
                    Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll(attackPos.position, attackRange,whatIsEnemy);
                    for (int i = 0; i < enemiesToDamage.Length; i++)
                    {
                        enemiesToDamage[i].GetComponent<DontTouch>().EnemyDeath();
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

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPos.position, attackRange);
    }
}
