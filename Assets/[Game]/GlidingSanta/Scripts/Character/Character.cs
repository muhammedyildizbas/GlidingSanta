using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    Rigidbody _rigidbody;
    bool gameStarted = false;
    public float timer=3f;
    public Rigidbody Rigidbody { get { return (_rigidbody == null) ? _rigidbody = GetComponent<Rigidbody>() : _rigidbody; } }
    public float screenLimit=7;
    Touch touch;
    private Vector3 moveVector;
    private Vector3 CurrentAngle;
    private Vector3 TargetForThrow;
    public float speed;
    public float ThrowSpeed = 5f;
    public float AngleSpeed = 0;
  
    private CharacterController controller;

    public GameObject particles; //particle sistem için
    private bool isControllable;

    private void Start()
    {
        StartCoroutine(WaitForStartCoroutine());
        isControllable = true;
        controller = GetComponent<CharacterController>();

        CurrentAngle = transform.eulerAngles;
        TargetForThrow = new Vector3(0f, 35f, 0f);
    }
    private void Update()
    {
       ThrowPlayerAtStart();

       if (!gameStarted)
           return;
 
        Movement();
        BoostController();

    }
    public void BoostController()
    {
        if (!isControllable)
            return;
        if (BoostManager.Instance.Boost <= 0)
        {
            TileManager.Instance.tileSpeed = 0;
            FallDown();
            Debug.Log("death");
            FindObjectOfType<CanvasController>().GameOverPanel();
        }
        else
            BoostManager.Instance.Boost -= Time.deltaTime;
    }

    #region Movement
    public void Movement()
    {

        moveVector.x = Input.GetAxisRaw("Horizontal");
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
            //TargetAngle = new Vector3(transform.rotation.x, BendLeft, transform.rotation.z);
            CurrentAngle = new Vector3(
                Mathf.LerpAngle(CurrentAngle.x, 0, Time.deltaTime * AngleSpeed),
                Mathf.LerpAngle(CurrentAngle.y, 0, Time.deltaTime * AngleSpeed),
                Mathf.LerpAngle(CurrentAngle.z, 40f, Time.deltaTime * AngleSpeed)
                );

            transform.eulerAngles = CurrentAngle;

        }
        #region Mobile
        if (Input.touchCount > 0)
        {
            touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Moved)
            {
                transform.position += Vector3.right * (6 * touch.deltaPosition.x);
                if (transform.position.x >= screenLimit)
                    transform.position = new Vector3(screenLimit, transform.position.y, transform.position.z);
                if (transform.position.x <= -screenLimit)
                    transform.position = new Vector3(-screenLimit, transform.position.y, transform.position.z);
            }
        }
        #endregion
    }
    #endregion 
    public void ThrowPlayerAtStart()
    {
        transform.position = Vector3.Lerp(transform.position, TargetForThrow, ThrowSpeed * Time.deltaTime);
    }

    IEnumerator WaitForStartCoroutine()
    {
        yield return new WaitForSeconds(timer);
        gameStarted = true;
    }

    #region Collectable Trigger
    
    private void OnTriggerEnter(Collider other)
    {
        ICollectable collectedObj = other.GetComponent<ICollectable>();

        if (collectedObj != null)
        {
            
            GameObject particle = Instantiate(particles, transform.position + new Vector3(0,0,5),Quaternion.identity);
            particle.GetComponent<ParticleSystem>().Play();

            collectedObj.Collect();
            Destroy(particle.gameObject,1);
        }
        if (other.gameObject.tag == "Wall")
        {
            isControllable = false;
            TileManager.Instance.tileSpeed = 0;
            FallDown();
            Debug.Log("death");
            FindObjectOfType<CanvasController>().GameOverPanel();
            
        }

    }
    public void FallDown()
    {
        //transform.position =Vector3.Lerp(transform.position,fallTarget,Time.deltaTime);
        Debug.Log("deathanimation");
    }

    #endregion

    
}