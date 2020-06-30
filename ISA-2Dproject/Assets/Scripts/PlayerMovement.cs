using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public static PlayerMovement Instance;
    private float moveSpeed;
    [System.NonSerialized]
    public  float walkSpeed = 3f;
    [System.NonSerialized]
    public float runSpeed = 5f;
    private bool runPressed = false;

    // Start is called before the first frame update
    void Awake()
    {
        Instance = this;
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

            //runButton
            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                runPressed = true;
                FindObjectOfType<AudioManager>().Play("RunSound");
            }

            if (Input.GetKeyUp(KeyCode.LeftShift))
            {
                runPressed = false;
            }

            if (runPressed == true)
            {
                moveSpeed = runSpeed;
            }
            else
            {
                moveSpeed = walkSpeed;
            }
        }
    }
}
