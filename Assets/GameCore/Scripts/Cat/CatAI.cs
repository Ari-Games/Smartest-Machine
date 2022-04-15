using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class CatAI : StateMachine
{
    private static IEnumerable<System.Type> typesCache;

    public CatMovement Movement;
    public CatAnimation Animation;

    public override void OnInit()
    {
        base.OnInit();

        Movement = GetComponent<CatMovement>();
        Animation = GetComponentInChildren<CatAnimation>();

        var targetType = typeof(CatState);

        if (typesCache == null)
        {
            typesCache = targetType.Assembly.ExportedTypes.Where(t => targetType.IsAssignableFrom(t));
        }

        foreach (var type in typesCache)
        {
            if (type == targetType)
            {
                continue;
            }

            var instance = (IState)System.Activator.CreateInstance(type);
            instance.SM = this;
            states.Add(type, instance);
        }
        foreach (var instance in states.Values)
        {
            instance.OnInit();
        }

        ChangeState<CatIdleState>();
    }

    public override void OnDispose()
    {
        base.OnDispose();
        foreach (var instance in states.Values)
        {
            instance.OnDispose();
        }
        states.Clear();
    }

    protected override void Update()
    {
        try
        {
            (Current as CatState)?.OnUpdate();
        }
        catch (System.Exception e)
        {
            Debug.LogException(e);
        }
    }
}
