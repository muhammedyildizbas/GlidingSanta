using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyer : MonoBehaviour
{
    private void Start()
    {
        transform.position = new Vector3(transform.position.x,transform.position.y,TileManager.Instance.tileDistance*-1f);
        //Position of the Destroyer cube in the scene has to be negatif tileDistance z position.
    }
    private void Update()
    {
        Vector3 toTarget = (TileManager.Instance.activeTiles[0].transform.position - transform.position).normalized;

        if (Vector3.Dot(toTarget, transform.forward) < 0)
        {
            TileManager.Instance.DeleteTile(TileManager.Instance.activeTiles[0]);
        }

        if (CollectableManager.Instance.activePresents == null || CollectableManager.Instance.activePresents.Count == 0)
            return;
        toTarget = (CollectableManager.Instance.activePresents[0].transform.position - transform.position).normalized;

        if (Vector3.Dot(toTarget, transform.forward) < 0)
        {
            CollectableManager.Instance.activePresents[0].GetComponent<ICollectable>().Destroy();
        }
    }

    /*private void OnTriggerEnter(Collider other)
    {
        TileManager.Instance.DeleteTile(other.transform.parent.gameObject);
    } */
}
