using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 8f;
    public float extraSpeedForRunning = 3f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //Movement
        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0f);

        transform.position += movement * Time.deltaTime * moveSpeed;

        //rennen
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            moveSpeed+=extraSpeedForRunning;
        }

        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            moveSpeed-=extraSpeedForRunning;
        }
    }
}
