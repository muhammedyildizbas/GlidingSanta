using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Present : CollectableBase
{

    

    int presentScore = 5;
    public override void CollectAndText()
    {
        

        base.Destroy();
        CollectablesText.Instance.UpdateCollectionText(presentScore);
    }


}
