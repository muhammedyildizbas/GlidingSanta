using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CollectableBase : MonoBehaviour, ICollectable
{


    


    public abstract void CollectAndText();

    public virtual void Destroy()
    {


        Destroy(gameObject);
    }
}
