using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public Item ItemRightHand;
    public Item ItemLeftHand;

    public Transform RightHand;
    public Transform LeftHand;

    [SerializeField] private KeyCode dropAction = KeyCode.G;

    public bool HasItem(ItemType type)
    {
        return (ItemRightHand && ItemRightHand.Type == type) || (ItemLeftHand && ItemLeftHand.Type == type);
    }

    public void UseItem(ItemType type)
    {
        if (ItemRightHand && ItemRightHand.Type == type)
        {
            ItemRightHand.Use();
            ItemRightHand = null;
            SignalSystem<ItemContextSignal>.Pub(new ItemContextSignal() { IsLeft = false, Message = "" });
        }
        else if (ItemLeftHand && ItemLeftHand.Type == type)
        {
            ItemLeftHand.Use();
            ItemLeftHand = null;
            SignalSystem<ItemContextSignal>.Pub(new ItemContextSignal() { IsLeft = true, Message = "" });
        }
    }

    public void AddItem(Item item)
    {
        if (ItemRightHand == null)
        {
            ItemRightHand = item;
            item.AddToHand(RightHand);
            SignalSystem<ItemContextSignal>.Pub(new ItemContextSignal() { IsLeft = false, Message = item.Name });
        }
        else if (ItemLeftHand == null)
        {
            ItemLeftHand = item;
            item.AddToHand(LeftHand);
            SignalSystem<ItemContextSignal>.Pub(new ItemContextSignal() { IsLeft = true, Message = item.Name });
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(dropAction))
        {
            if (ItemLeftHand)
            {
                ItemLeftHand.DropFromHand();
                ItemLeftHand = null;
                SignalSystem<ItemContextSignal>.Pub(new ItemContextSignal() { IsLeft = true, Message = "" });
            }
            else if(ItemRightHand)
            {
                ItemRightHand.DropFromHand();
                ItemRightHand = null;
                SignalSystem<ItemContextSignal>.Pub(new ItemContextSignal() { IsLeft = false, Message = "" });
            }
        }
    }
}
