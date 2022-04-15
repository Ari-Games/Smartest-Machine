using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatState : IState
{
    public CatAI AI { get; private set; }
    public IStateMachine SM { get; set; }

    public virtual void OnEnter()
    {
        AI = (CatAI)SM;
    }
    public virtual void OnDispose()
    {
    }

    public virtual void OnExit()
    {
    }

    public virtual void OnInit()
    {
    }

    public virtual void OnUpdate()
    {
    }
}
