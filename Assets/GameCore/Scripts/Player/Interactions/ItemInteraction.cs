using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemInteraction : MonoBehaviour
{
    private Raycaster raycaster;
    private Inventory inventory;

    [SerializeField] private KeyCode action = KeyCode.E;

    private void Start()
    {
        raycaster = transform.root.GetComponentInChildren<Raycaster>();
        inventory = transform.root.GetComponent<Inventory>();
    }

    private void Update()
    {
        if (!raycaster.Hited)
        {
            return;
        }
        var hitObj = raycaster.HitInfo.transform;
        if (!hitObj.CompareTag(Tags.Item))
        {
            return;
        }

        var item = hitObj.GetComponent<Item>();

        if (Input.GetKeyDown(action))
        {
            inventory.AddItem(item);
        }
    }
}
