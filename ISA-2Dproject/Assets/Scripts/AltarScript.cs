using UnityEngine;
using System.Collections;
using UnityEngine.Events;

public class AltarScript : MonoBehaviour
{
    public UnityEvent ritualStart;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (Bones.Instance.bonesCollected == Bones.Instance.totalBones && LevelManager.Instance.bossDefeated == true)
            {
                StartCoroutine(AltarScene());
            }
            else
            {
                Debug.Log("Zoek alle bones voor het ritueel. Overwin de eindbaas. Dan kun je terug komen.");
            }
        }
    }
       IEnumerator AltarScene()
    {
        LevelManager.Instance.scriptedEvent = true;
        ritualStart.Invoke();
        yield return new WaitForSeconds(5f); //Animation time as seconds
        LevelManager.Instance.NextPhase();
    }
}
