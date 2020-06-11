using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float moveSpeed;
    public float walkSpeed = 3f;
    public float runSpeed = 2f;

    // Start is called before the first frame update
    void Start()
    {
        moveSpeed = walkSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        if (LevelManager.Instance.scriptedEvent == false)
        {
            //Movement
            Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0f);

            transform.position += movement * Time.deltaTime * moveSpeed;

            //rennen
            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                moveSpeed = runSpeed;
                FindObjectOfType<AudioManager>().Play("RunSound");
            }

            if (Input.GetKeyUp(KeyCode.LeftShift))
            {
                moveSpeed = walkSpeed;
            }
        }
    }
}
