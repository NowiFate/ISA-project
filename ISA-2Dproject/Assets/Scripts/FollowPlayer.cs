using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public float followSpeed;
    public float backSpeed;
    public float waitingTime;

    public Transform startPos;
    private Transform stalkTarget;
    public BoxCollider2D spawner;

    private void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        FollowTrigger followTrigger = spawner.GetComponent<FollowTrigger>();
        if (followTrigger.triggered == true)
        {
            stalkTarget = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
            transform.position = Vector2.MoveTowards(transform.position, stalkTarget.position, followSpeed * Time.deltaTime);
        }

        if(followTrigger.triggered == false)
        {
            Invoke("GoingBack", waitingTime);
        }
    }

    public void GoingBack()
    {
        transform.position = Vector2.MoveTowards(transform.position, startPos.position, backSpeed * Time.deltaTime);
    }
}
