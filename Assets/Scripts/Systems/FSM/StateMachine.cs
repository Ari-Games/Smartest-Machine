using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine : MonoBehaviour, IStateMachine
{
    private GameObject context;
    public GameObject Context
    {
        get
        {
            if (context == null)
            {
                context = transform.root.gameObject;
            }
            return context;
        }
    }

    public IState Current { get; set; }

    public event ChangeState OnChangeState = delegate { };

    protected readonly Dictionary<System.Type, IState> states = new Dictionary<System.Type, IState>();

    public void ChangeState<T>() where T : IState
    {
        if (Current != null)
        {
            Current.OnExit();
        }

        Current = GetState<T>();
        Current.OnEnter();
        OnChangeState(Current);
    }

    public T GetState<T>() where T : IState
    {
        if (states.TryGetValue(typeof(T), out var res))
        {
            return (T)res;
        }
        else
        {
            return default(T);
        }
    }

    public virtual void OnInit()
    {
    }

    public virtual void OnDispose()
    {
    }

    protected virtual void Awake()
    {
        OnInit();
    }

    protected virtual void OnDestroy()
    {
        OnDispose();
    }

    protected virtual void Update()
    {
        if (Current != null)
        {
            Current.OnUpdate();
        }
    }
}
