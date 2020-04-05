using UnityEngine;

public class Roomtransition : MonoBehaviour
{
    public Transform target;
    public Vector2 roomSize;
    public float smoothCam;

    private void Update()
    {
        Vector3 pos = new Vector3(Mathf.RoundToInt(target.position.x / roomSize.x) * roomSize.x, Mathf.RoundToInt(target.position.y / roomSize.y) * roomSize.y, transform.position.z);
        transform.position = Vector3.Lerp(transform.position, pos, smoothCam);
    }
}
