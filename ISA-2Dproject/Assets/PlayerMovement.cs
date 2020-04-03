using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float extraSpeedForRunning = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0f, 0f);
        transform.position += movement * Time.deltaTime * (moveSpeed + extraSpeedForRunning);

        //rennen
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            extraSpeedForRunning = 3f;
        }

        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            extraSpeedForRunning = 0;
        }
    }
}
