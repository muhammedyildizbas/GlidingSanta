using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    public float skor;
    private void OnEnable()
    {
        skor = 0;
    }
}
