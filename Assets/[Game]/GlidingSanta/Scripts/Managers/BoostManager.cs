using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoostManager : Singleton<BoostManager>
{
    public float maxBoost;
    private float boost;
    
   
    public float Boost
    {
        get { return boost; }
        set
        {
            if (value > maxBoost)
                boost = maxBoost;
            else
                boost = value;
        }
    }
    private void OnEnable()
    {
        boost = maxBoost;
       
    }
}
