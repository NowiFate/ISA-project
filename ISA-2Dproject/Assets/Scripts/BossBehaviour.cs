using UnityEngine;
using UnityEngine.Events;

public class BossBehaviour : MonoBehaviour
{
    public GameObject gameMananger;

    public float bossHP = 3;
    [SerializeField]
    public float bossSpeed;
    private Vector2 bossPos;
    public Transform target;

    public BoxCollider2D triggerBox;

    public UnityEvent bossKilledYou;

    private void Awake()
    {
        bossPos = this.transform.position;
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

        if (bossHP < 1)
        {
            LevelManager.Instance.bossDefeated = true;
            gameObject.SetActive(false);
            FindObjectOfType<AudioManager>().StopPlaying("BossMusic");
            FindObjectOfType<AudioManager>().Play("EndingTheme");
        }
    }

    public void bossRespawn()
    {
        this.transform.position = bossPos;
    }
}
