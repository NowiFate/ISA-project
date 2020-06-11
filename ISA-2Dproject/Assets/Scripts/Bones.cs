using UnityEngine;
using UnityEngine.UI;

public class Bones : MonoBehaviour
{
    public Text bonesDisplay;
    public int bonesCollected = 0;
    public readonly int totalBones = 1;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        bonesDisplay.text = "Bones Collected: " + bonesCollected.ToString() + "/" + totalBones;
    }

    public void AddBone()
    {
        bonesCollected++;
    }
}
