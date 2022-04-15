using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MessagesLevelManager : MonoBehaviour
{
    [SerializeField] private Messages messages;
    [SerializeField] private KeyCode keyPassMessage = KeyCode.Space;

    private bool checkPassMessage = true;

    private bool canPassMessage = true;
    private float currentTime = 0;
    private float cooldowmPass = 0.5f;

    private int indexMessage = 0;

    private void Start()
    {
        var message = messages.Get(indexMessage);
        indexMessage++;
        SignalSystem<MessageViewSignal>.Pub(new MessageViewSignal() { Message = message });
    }

    private void Update()
    {
        InputHandler();
    }

    private void InputHandler()
    {
        currentTime += Time.deltaTime;
        if (currentTime >= cooldowmPass && !canPassMessage)
        {
            canPassMessage = true;
            currentTime = 0;
        }

        if (checkPassMessage && canPassMessage && Input.GetKeyDown(keyPassMessage))
        {
            canPassMessage = false;
            PassMessage();
        }
    }

    private void PassMessage()
    {
        if (messages.HasNextMessage(indexMessage))
        {
            SignalSystem<MessageViewSignal>.Pub(new MessageViewSignal() { Message = messages.Get(indexMessage) });
            indexMessage++;

        }
        else
        {
            checkPassMessage = false;
            SignalSystem<MessageViewSignal>.Pub(new MessageViewSignal() { IsView = false, Message = "" });
        }
    }
}
