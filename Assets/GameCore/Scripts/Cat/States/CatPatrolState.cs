using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatPatrolState : CatState
{
    private Transform targetPosition;

    public override void OnEnter()
    {
        base.OnEnter();

        targetPosition = CatPatrolPoints.Instance.GetRandom();

        AI.Animation.Current = CatAnimation.State.Walk;
    }

    public override void OnUpdate()
    {
        base.OnUpdate();
        if (targetPosition == null)
        {
            return;
        }

        if (AI.Movement.IsReachedPosition(targetPosition.position))
        {
            AI.ChangeState<CatSitState>();
            return;
        }
        AI.Movement.MoveToNavMeshPointNear(targetPosition.position);
    }
}
