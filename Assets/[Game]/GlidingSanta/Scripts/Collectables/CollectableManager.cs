using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableManager : Singleton<CollectableManager>
{
    public List<GameObject> Presents;
    public List<GameObject> activePresents;
    private void OnEnable()
    {
        if (Managers.Instance == null)
            return;
        activePresents = new List<GameObject>();
    }

    private void OnDisable()
    {
        if (Managers.Instance == null)
            return;
    }

    public void CreateStars(int lane)
    {
        //int RandomLanes = Random.Range(0, TrackManager.Instance.Lanes.Count);
        int targetStarCount = Random.Range(3, 5);  /*oluşturulacak yıldız sayısı*/
        
        StartCoroutine(CreateStarsCo(TrackManager.Instance.Lanes[lane].position, targetStarCount));
        Debug.Log("Coroutine başladı");
    }

    private IEnumerator CreateStarsCo(Vector3 lane, int targetStarCount)
    {
        Debug.Log("CreateStars");
        //yield return new WaitForSeconds(Random.Range(0.5f, 1.5f));
        for (int i = 0; i < targetStarCount; i++)
        {
            int RandomPresents = Random.Range(0, Presents.Count);
            activePresents.Add(Instantiate(Presents[RandomPresents], lane + Vector3.back, Quaternion.identity));

            yield return new WaitForSeconds(0.2f);
        }
    }
}