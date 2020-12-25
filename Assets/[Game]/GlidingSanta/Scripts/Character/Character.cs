using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    Rigidbody _rigidbody;
    public Rigidbody Rigidbody { get { return (_rigidbody == null) ? _rigidbody = GetComponent<Rigidbody>() : _rigidbody; } }


    private Vector3 moveVector;
    private Vector3 CurrentAngle;
    private Vector3 TargetForThrow;
    public float speed;
    public float ThrowSpeed = 5f;
    public float AngleSpeed = 0;
  
    private CharacterController controller;

    public GameObject particles; //particle sistem için
    private void Start()
    {
        controller = GetComponent<CharacterController>();
        CurrentAngle = transform.eulerAngles;
        TargetForThrow = new Vector3(0f, 35f, 0f);
    }
    private void Update()
    {
        ThrowPlayerAtStart();
        StartCoroutine(WaitForStartCoroutine());
        Movement();

    }

    public void Movement()
    {

        moveVector.x = Input.GetAxisRaw("Horizontal") * speed;
        Rigidbody.velocity = (moveVector) * Time.deltaTime * speed;

        if(moveVector.x > 0)
        {
            //TargetAngle = new Vector3(transform.rotation.x, BendRight, transform.rotation.z);
            CurrentAngle = new Vector3(
                Mathf.LerpAngle(CurrentAngle.x, 0, Time.deltaTime * AngleSpeed),
                Mathf.LerpAngle(CurrentAngle.y, 0f, Time.deltaTime * AngleSpeed),
                Mathf.LerpAngle(CurrentAngle.z, -40f, Time.deltaTime * AngleSpeed)
                );
            transform.eulerAngles = CurrentAngle;

        }
        if(moveVector.x < 0)
        {
            CurrentAngle = new Vector3(
                Mathf.LerpAngle(CurrentAngle.x, 0, Time.deltaTime * AngleSpeed),
                Mathf.LerpAngle(CurrentAngle.y, 0, Time.deltaTime * AngleSpeed),
                Mathf.LerpAngle(CurrentAngle.z, 40f, Time.deltaTime * AngleSpeed)
                );

            transform.eulerAngles = CurrentAngle;

        }

    }

    public void ThrowPlayerAtStart()
    {
        transform.position = Vector3.Lerp(transform.position, TargetForThrow, ThrowSpeed * Time.deltaTime);
    }

    IEnumerator WaitForStartCoroutine()
    {
        yield return new WaitForSeconds(2f);

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