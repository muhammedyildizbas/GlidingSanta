using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    private Vector3 moveVector;
    public float speed ;
    private float verticalVelocity = 0.0f;
    private CharacterController controller;
    //private float gravity = 12.0f;


    private void Start()
    {
        controller = GetComponent<CharacterController>();
        
    }
    private void Update()
    {
        moveVector = Vector3.zero;

        /*if(controller.isGrounded)
         {
             verticalVelocity = 0.5f;
         }
         else
         {
             verticalVelocity -= gravity-Time.deltaTime;
         }*/

        
        moveVector.x = Input.GetAxisRaw("Horizontal")*speed;

        moveVector.y = verticalVelocity;

        moveVector.z = speed;

        controller.Move(moveVector*Time.deltaTime); 
    }
}