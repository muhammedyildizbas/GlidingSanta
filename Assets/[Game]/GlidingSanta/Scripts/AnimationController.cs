using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{

    private Animator animator;
    public Animator Animator { get { return (animator == null) ? animator = GetComponent<Animator>() : animator; } }

    Character character;
    public Character Character { get { return (character == null) ? character = FindObjectOfType<Character>().GetComponent<Character>() : character; } } 
 
    //private void OnEnable()
    //{
    //    character.OnCharacterHit.AddListener(() => InvokeTrigger("Death"));
    //}
    //private void OnDisable()
    //{
    //    character.OnCharacterHit.RemoveListener(() => InvokeTrigger("Death"));
    //}

    public void InvokeTrigger(string value)
    {  
            Animator.SetTrigger(value);
    }
}
