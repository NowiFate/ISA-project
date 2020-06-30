using System.Collections;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public float followSpeed;
    public float backSpeed;
    public float waitingTime;

    private Vector2 startPos;
    private Transform stalkTarget;
    public GameObject startZone;

    private void Awake()
    {
        startPos = transform.position;
        stalkTarget = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (startZone.GetComponent<FollowTrigger>().triggered == true)
        {
            StopCoroutine(GoingBack());
            transform.position = Vector2.MoveTowards(transform.position, stalkTarget.position, followSpeed * Time.deltaTime);
        }

        if(startZone.GetComponent<FollowTrigger>().triggered == false)
        {
            StartCoroutine(GoingBack());
        }
    }

    IEnumerator GoingBack()
    {
        yield return new WaitForSeconds(waitingTime);
        transform.position = Vector2.MoveTowards(transform.position, startPos, backSpeed * Time.deltaTime);
    }
}
