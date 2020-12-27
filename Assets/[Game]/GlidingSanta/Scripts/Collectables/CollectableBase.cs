using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableBase : MonoBehaviour, ICollectable
{
    public int points;

    private void Update()
    {
        transform.Rotate(Vector3.up * 180 * Time.deltaTime);
    }
    public void Collect()
    {
        CollectablesText.Instance.UpdateCollectionText(points);
        Destroy();
    }

    public void Destroy()
    {
        CollectableManager.Instance.activePresents.Remove(gameObject);
        Destroy(gameObject);
    }
}
