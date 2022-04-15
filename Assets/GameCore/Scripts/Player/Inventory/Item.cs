using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemType
{
    None = -1,
    Key = 0
}


public class Item : MonoBehaviour
{
    public ItemType Type;
    public string Name;

    private Rigidbody rb;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    public void AddToHand(Transform hand)
    {
        transform.parent = hand;
        transform.localPosition = Vector3.zero;
        rb.isKinematic = true;
    }

    public void DropFromHand()
    {
        transform.parent = null;
        rb.isKinematic = false;
    }

    public void Use()
    {
        transform.parent = null;
        Destroy(gameObject);
    }
}
