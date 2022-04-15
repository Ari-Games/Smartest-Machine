using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public delegate void ChangeState(IState state);

public interface IStateMachine
{
    GameObject Context { get; }
    IState Current { get; set; }
    event ChangeState OnChangeState;
    void OnInit();
    void OnDispose();

    T GetState<T>() where T : IState;
    void ChangeState<T>() where T : IState;
}
