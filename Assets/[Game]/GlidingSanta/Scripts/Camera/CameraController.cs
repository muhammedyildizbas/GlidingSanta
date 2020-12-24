﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private Transform lookAt;
    private Vector3 startOffset;
    private Vector3 moveVector;

    private void Start()
    { 
        lookAt = GameObject.FindGameObjectWithTag("Player").transform;
        startOffset = transform.position - lookAt.position;
    }
    private void Update()
    {
        moveVector = lookAt.position + startOffset;

        moveVector.x = 0;

        //moveVector.y = Mathf.Clamp(moveVector.y, 3, 5); //If game has a mechanic for moving up-down position

        transform.position = moveVector;

    }
}
