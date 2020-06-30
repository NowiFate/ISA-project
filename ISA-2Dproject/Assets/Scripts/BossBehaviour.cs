using UnityEngine;
using UnityEngine.Events;

public class BossBehaviour : MonoBehaviour
{
    public float bossHP = 3;
    public float bossSpeed;
    private Vector2 bossPos;
    private Transform target;

    public BoxCollider2D triggerBox;

    public UnityEvent bossKilledYou;

    private void Start()
    {
        bossPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        BossTrigger bossTrigger = triggerBox.GetComponent<BossTrigger>();

        if (bossTrigger.beginBossBattle == true)
        {
            //stalking the player
            target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
            transform.position = Vector2.MoveTowards(transform.position, target.position, bossSpeed * Time.deltaTime);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("Player")) bossKilledYou.Invoke();
    }

    public void BossLifes()
    {
        bossHP -= 1;
        FindObjectOfType<AudioManager>().Play("BossHurt");

        if (bossHP < 1)
        {
            BossTrigger bossTrigger = triggerBox.GetComponent<BossTrigger>();

            gameObject.GetComponent<PolygonCollider2D>().enabled = false;
            gameObject.SetActive(false);
            LevelManager.Instance.bossDefeated = true;
            FindObjectOfType<AudioManager>().StopPlaying("BossMusic");
            FindObjectOfType<AudioManager>().Play("EndingTheme");

            if (bossTrigger.leftCollider != null) bossTrigger.leftCollider.SetActive(false);
            if (bossTrigger.rightCollider != null) bossTrigger.rightCollider.SetActive(false);
        }
    }

    public void BossRespawn()
    {
        gameObject.transform.position = bossPos;
        gameObject.SetActive(false);
    }
}
