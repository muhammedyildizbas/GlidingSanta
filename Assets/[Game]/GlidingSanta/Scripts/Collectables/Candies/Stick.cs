using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stick : CollectableBase
{
    Vector3 rotation = new Vector3(0, 180, 0);

    private void Update()
    {
        transform.Rotate(rotation * Time.deltaTime);
    }


    int stickScore = 1;
    public override void CollectAndText()
    {


        base.Destroy();
        CollectablesText.Instance.UpdateCollectionText(stickScore);
    }


}
