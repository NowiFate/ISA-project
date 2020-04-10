using UnityEngine;
using UnityEngine.UI;

public class Bones : MonoBehaviour
{
    public GameObject[] allBones;
    public Text bonesDisplay;
    public int bonesCollected = 0;
    private int numberOfBones;

    // Start is called before the first frame update
    void Start()
    {
        numberOfBones = allBones.Length;
        bonesDisplay.text = "Bones Collected: " + bonesCollected.ToString() + "/" + numberOfBones;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
