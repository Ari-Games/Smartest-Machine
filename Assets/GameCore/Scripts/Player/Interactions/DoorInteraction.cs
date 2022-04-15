using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorInteraction : MonoBehaviour
{
    private Raycaster raycaster;

    [SerializeField] private KeyCode action = KeyCode.E;

    private void Start()
    {
        raycaster = transform.root.GetComponentInChildren<Raycaster>();
    }

    private void Update()
    {
        if (!raycaster.Hited)
        {
            return;
        }
        var hitObj = raycaster.HitInfo.transform.parent;
        if (hitObj == null)
        {
            return;
        }

        if (!hitObj.CompareTag(Tags.Door))
        {
            return;
        }

        if (Input.GetKeyDown(action))
        {
            var door = hitObj.GetComponent<DoorController>();
            door.Action(transform.root.gameObject);
        }
    }
}
