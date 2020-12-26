using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Present : CollectableBase
{

    Vector3 rotation = new Vector3(0, 180, 0);

    private void Update()
    {
        transform.Rotate(rotation * Time.deltaTime);
    }

    int presentScore = 5;
    public override void CollectAndText()
    {
        

        base.Destroy();
        CollectablesText.Instance.UpdateCollectionText(presentScore);
    }


}
