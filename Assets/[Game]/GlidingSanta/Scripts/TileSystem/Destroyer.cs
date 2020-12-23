using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyer : MonoBehaviour
{
    private void Start()
    {
        transform.position = new Vector3(transform.position.x,transform.position.y,TileManager.Instance.tileDistance*-1f);
    }
    private void Update()
    {
        Vector3 toTarget = (TileManager.Instance.activeTiles[0].transform.position- transform.position).normalized;

        if (Vector3.Dot(toTarget, transform.forward) < 0)
        {
            TileManager.Instance.DeleteTile(TileManager.Instance.activeTiles[0]);
            Debug.Log("Target is in front of this game object.");
        }
        
    }

    /*private void OnTriggerEnter(Collider other)
    {
        TileManager.Instance.DeleteTile(other.transform.parent.gameObject);
    } */
}
