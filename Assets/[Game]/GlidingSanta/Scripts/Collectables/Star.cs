using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Star : CollectableBase
{
    int starsPoint = 5;
    public override void CollectAndText()
    {
        CollectablesText.Instance.UpdateCollectionText(starsPoint);
        base.Destroy();
    }


}
