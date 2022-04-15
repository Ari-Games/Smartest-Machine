using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Raycaster : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private float distance = 4;
    [SerializeField] private float offset = 0.2f;

    public GameObject Target;
    public Vector3 TargetPosition;
    public bool Hited { get; private set; }
    public RaycastHit HitInfo;

    private Transform transformCached;

    private void Awake()
    {
        transformCached = transform;
    }

    private void FixedUpdate()
    {
        Hited = Physics.Raycast(transformCached.position + transformCached.forward * offset, transformCached.forward, out HitInfo, distance);
        if (!Hited)
        {
            Target = null;
            return;
        }

        TargetPosition = HitInfo.point;
        Target = HitInfo.transform.gameObject;
    }
}
