using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IState
{
    IStateMachine SM { get; set; }

    void OnInit();
    void OnDispose();
    void OnEnter();
    void OnExit();
    void OnUpdate();
}
