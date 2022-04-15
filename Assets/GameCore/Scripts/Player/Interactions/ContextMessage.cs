using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContextMessage : MonoBehaviour
{
    private Raycaster raycaster;

    [SerializeField] private string doorContextMessage = "Нажмите Е, чтобы взаимодействовать";
    [SerializeField] private string contextMessage = "Нажмите Е, чтобы подобрать";

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
        var hitObj = raycaster.HitInfo.transform;
        if (hitObj == null)
        {
            return;
        }

        if (hitObj.CompareTag(Tags.Door))
        {
            SignalSystem<MessageViewSignal>.Pub(new MessageViewSignal() { IsView = true, Message = doorContextMessage });
        }
        else if (hitObj.CompareTag(Tags.Item))
        {
            SignalSystem<MessageViewSignal>.Pub(new MessageViewSignal() { IsView = true, Message = contextMessage });
        }
        else
        {
            SignalSystem<MessageViewSignal>.Pub(new MessageViewSignal() { IsView = false, Message = "" });
        }
    }
}
