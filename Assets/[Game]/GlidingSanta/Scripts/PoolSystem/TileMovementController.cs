﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileMovementController : MonoBehaviour
{
    private void Update()
    {
        if(GameManager.Instance.isClickedForStartGame == true)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - TileManager.Instance.tileSpeed * Time.deltaTime);
        }
        
    }
}
