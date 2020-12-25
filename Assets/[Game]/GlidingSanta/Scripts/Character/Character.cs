using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    Rigidbody _rigidbody;
    public Rigidbody Rigidbody { get { return (_rigidbody == null) ? _rigidbody = GetComponent<Rigidbody>() : _rigidbody; } }


    private Vector3 moveVector;
    public float speed ;
    private float verticalVelocity = 0.0f;
    private CharacterController controller;
    //private float gravity = 12.0f;

    public GameObject particles; //particle sistem için
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

        Rigidbody.velocity = (moveVector) * Time.deltaTime * 400f;

        //controller.Move(moveVector*Time.deltaTime); 










    }

    #region Collectable Trigger

    private void OnTriggerEnter(Collider other)
    {
        ICollectable collectedObj = other.GetComponent<ICollectable>();

        if (collectedObj != null)
        {
            GameObject particle = Instantiate(particles, transform.position + new Vector3(0,0,5),Quaternion.identity);
            particle.GetComponent<ParticleSystem>().Play();

            collectedObj.CollectAndText();
            Destroy(particle.gameObject,1);
        }

        

    }

    #endregion

}