using UnityEngine;
using UnityEngine.Events;

public class BossBehaviour : MonoBehaviour
{
    public SpriteRenderer bossSprite;
    public BoxCollider2D bossCollider;
    public Animator bossTakesDamage;
    public GameObject gameMananger;

    public float bossHP = 3;
    public float bossSpeed;
    public Transform target;

    public BoxCollider2D triggerBox;

    public UnityEvent bossKilledYou;

    // Update is called once per frame
    void Update()
    {
        BossTrigger bossTrigger = triggerBox.GetComponent<BossTrigger>();

        if (bossTrigger.begin == true)
        {
            bossSprite.enabled = true;
            bossCollider.enabled = true;

            target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
            transform.position = Vector2.MoveTowards(transform.position, target.position, bossSpeed * Time.deltaTime);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag.Equals("Player"))
        {
            bossKilledYou.Invoke();
        }
    }

    public void BossLifes()
    {
        bossHP -= 1;
        bossTakesDamage.enabled = true;

        if (bossHP < 1)
        {
            LevelManager levelManager = gameMananger.GetComponent<LevelManager>();
            levelManager.bossDefeated = true;
            Destroy(gameObject);
        }
    }
}
