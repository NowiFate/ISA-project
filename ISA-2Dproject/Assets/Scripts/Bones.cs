using UnityEngine;
using UnityEngine.UI;

public class Bones : MonoBehaviour
{
    public static Bones Instance;

    public Text bonesDisplay;
    public int bonesCollected = 0;
    public int totalBones = 6;

    // Start is called before the first frame update
    void Awake()
    {
        Instance = this;
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
