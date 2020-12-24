using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour, ICharacterController
{
    public Transform CurrentPos { get { return FindObjectOfType<Character>().transform; } }
    
    private void OnEnable()
    {
        if (Managers.Instance == null)
            return;

        EventManager.OnSwipeDetected.AddListener(Move);
    }

    private void OnDisable()
    {
        if (Managers.Instance == null)
            return;

        EventManager.OnSwipeDetected.RemoveListener(Move);
    }

    public void Move(Vector3 direction)
    {
        
    }

    private void Move(Swipe swipe, Vector2 direction)
    {
        
        switch (swipe)
        {
            case Swipe.Left:
                GoLeftLane();
                break;

            case Swipe.Right:
                GoRightLane();
                break;
        }
            
            
    }
    private void GoLeftLane()
    {
        transform.position = new Vector3(10,35,0);
    }
    private void GoRightLane()
    {
        transform.position = new Vector3(-10, 35, 0);

    }
}
