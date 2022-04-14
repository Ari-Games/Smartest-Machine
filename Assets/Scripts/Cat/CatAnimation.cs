using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatAnimation : MonoBehaviour
{
    public enum State
    {
        None = -1,
        Idle = 0,
        Walk,
        Sit,
        Meow
    }

    private const string STATE = "state";

    private State current = State.None;
    public State Current
    {
        get
        {
            return current;
        }
        set
        {
            if (current == value)
            {
                return;
            }
            current = value;
            UpdateAnimation(value);
        }
    }

    private Animator animator;

    private void Awake()
    {
        animator = GetComponentInChildren<Animator>();
    }

    private void UpdateAnimation(State state)
    {
        animator.SetInteger(STATE, (int)state);
    }

}
