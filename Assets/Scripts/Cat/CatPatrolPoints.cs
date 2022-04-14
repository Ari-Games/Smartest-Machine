using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatPatrolPoints : MonoBehaviour
{
    public static CatPatrolPoints Instance;

    [SerializeField] private Transform[] points;

    private void Awake()
    {
        Instance = this;
    }

    private void OnDestroy()
    {
        Instance = null;
    }

    private void Start()
    {
        points = transform.Children();
    }

    public Transform GetRandom()
    {
        return points.Random();
    }
}
