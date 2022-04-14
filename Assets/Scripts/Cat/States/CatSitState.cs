using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatSitState : CatState
{
    private const float minTimeIdle = 3f;
    private const float maxTimeIdle = 5f;

    private float currentTime = 0;
    private float targetTime;
    public override void OnEnter()
    {
        base.OnEnter();
        currentTime = 0f;
        targetTime = Random.Range(minTimeIdle, maxTimeIdle);

        AI.Animation.Current = CatAnimation.State.Sit;
    }

    public override void OnUpdate()
    {
        base.OnUpdate();
        currentTime += Time.deltaTime;
        if (currentTime >= targetTime)
        {
            AI.ChangeState<CatPatrolState>();
            return;
        }
    }
}
