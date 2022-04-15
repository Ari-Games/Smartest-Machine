using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemContextSignal : ISignal
{
    public bool IsLeft;
    public string Message;
}

public class InventoryContextView : MonoBehaviour
{
    public Text LeftInfo;
    public Text RightInfo;

    private void Start()
    {
        SignalSystem<ItemContextSignal>.Sub(OnItemContextSignalHandler);
    }

    private void OnDestroy()
    {
        SignalSystem<ItemContextSignal>.UnSub(OnItemContextSignalHandler);
    }

    private void OnItemContextSignalHandler(ItemContextSignal signal)
    {
        if (signal.IsLeft)
        {
            LeftInfo.text = signal.Message;
        }
        else
        {
            RightInfo.text = signal.Message;
        }
    }
}
