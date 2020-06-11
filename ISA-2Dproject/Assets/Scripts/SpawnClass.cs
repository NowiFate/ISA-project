using UnityEngine;

public class SpawnClass : MonoBehaviour
{
    public GameObject[] toBeSpawned;

    public void Spawner()
    {
        for (int i = 0; i < toBeSpawned.Length; i++)
        {
            toBeSpawned[i].SetActive(true);
        }
    }
}
