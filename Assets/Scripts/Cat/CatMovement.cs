using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CatMovement : MonoBehaviour
{
    public static float SamplePointOnNavMesh = 1.5f;


    public float WalkSpeed = 1.5f;
    public float RunSpeed = 3f;

    public float AngularSpeed = 230f;
    public float Acceleration = 10f;

    private NavMeshAgent agent;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.speed = WalkSpeed;
        agent.angularSpeed = AngularSpeed;
        agent.acceleration = Acceleration;
    }

    public void SetRunning(bool running)
    {
        agent.speed = running ? RunSpeed : WalkSpeed;
    }

    public void SetStopped(bool stopped)
    {
        agent.isStopped = stopped;
        if (stopped)
        {
            agent.velocity = Vector3.zero;
        }
    }

    public bool HasPath(Vector3 from, Vector3 to)
    {
        NavMeshPath navMeshPath = new NavMeshPath();
        NavMesh.CalculatePath(from, to, agent.areaMask, navMeshPath);
        return navMeshPath.status == NavMeshPathStatus.PathComplete;
    }

    public void MoveTo(Vector3 position)
    {
        agent.isStopped = false;
        agent.SetDestination(position);
    }

    public bool MoveToNavMeshPointNear(Vector3 position)
    {
        var canMove = NavMesh.SamplePosition(position, out var hit, SamplePointOnNavMesh, agent.areaMask);
        if (canMove)
        {
            var finalPosition = hit.position;
            MoveTo(finalPosition);
        }
        return canMove;
    }

    public bool IsReachedPosition(Vector3 position)
    {
        return Vector3.Distance(transform.position, position) < agent.stoppingDistance;
    }
}
