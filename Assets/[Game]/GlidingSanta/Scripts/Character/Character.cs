using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Character : MonoBehaviour
{
    Rigidbody _rigidbody;
    public Rigidbody Rigidbody { get { return (_rigidbody == null) ? _rigidbody = GetComponent<Rigidbody>() : _rigidbody; } }
    
    bool gameStarted = false;
    bool isControllable = true;

    Touch touch;

    private Vector3 moveVector;
    private Vector3 CurrentAngle;
    private Vector3 TargetForThrow;

    public float screenLimit = 7;
    public float timer = 3f;
    public float speed;
    public float ThrowSpeed = 5f;
    public float AngleSpeed = 0;

    private AnimationController AnimationController;
    private CharacterController controller;

    [HideInInspector]
    public UnityEvent OnCharacterHit = new UnityEvent();

    public GameObject particles; //particle sistem için
    private void Start()
    {
        StartCoroutine(WaitForStartCoroutine());
 
        controller = GetComponent<CharacterController>();

        CurrentAngle = transform.eulerAngles;
        TargetForThrow = new Vector3(0f, 35f, 0f);

        AnimationController = GetComponent<AnimationController>();
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
        if (BoostManager.Instance.Boost <= 0)
            Debug.Log("EndGame");
        else
            BoostManager.Instance.Boost -= Time.deltaTime;
    }

    #region Movement
    public void Movement()
    {
        if (!isControllable)
            return;
        else
        {
            moveVector.x = Input.GetAxisRaw("Horizontal") * speed;
            Rigidbody.velocity = (moveVector) * Time.deltaTime * speed;

            if (moveVector.x > 0)
            {
                //TargetAngle = new Vector3(transform.rotation.x, BendRight, transform.rotation.z);
                CurrentAngle = new Vector3(
                    Mathf.LerpAngle(CurrentAngle.x, 0, Time.deltaTime * AngleSpeed),
                    Mathf.LerpAngle(CurrentAngle.y, 0f, Time.deltaTime * AngleSpeed),
                    Mathf.LerpAngle(CurrentAngle.z, -40f, Time.deltaTime * AngleSpeed)
                    );
                transform.eulerAngles = CurrentAngle;

            }
            if (moveVector.x < 0)
            {
                //TargetAngle = new Vector3(transform.rotation.x, BendLeft, transform.rotation.z);
                CurrentAngle = new Vector3(
                    Mathf.LerpAngle(CurrentAngle.x, 0, Time.deltaTime * AngleSpeed),
                    Mathf.LerpAngle(CurrentAngle.y, 0, Time.deltaTime * AngleSpeed),
                    Mathf.LerpAngle(CurrentAngle.z, 40f, Time.deltaTime * AngleSpeed)
                    );

                transform.eulerAngles = CurrentAngle;

            }
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
            collectedObj.CollectAndText();
            Destroy(particle.gameObject,1);
        }

        if (other.gameObject.tag == "Wall")
        {
            
            FallDown();
            
        }

    }

    //Çarpma tetikleme
    void FallDown()
    {
        isControllable = false;
        TileManager.Instance.tileSpeed = 0;
        GetComponent<AnimationController>().InvokeTrigger("Death");
    }

    #endregion

    
}