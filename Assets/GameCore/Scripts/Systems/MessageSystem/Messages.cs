using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MessageViewSignal : ISignal
{
    public bool IsView = true;
    public string Message;
}

[CreateAssetMenu(fileName = "MessagesData", menuName = "GameData/MessagesData", order = 1)]
public class Messages : ScriptableObject
{
    [SerializeField] private List<string> data = new List<string>();

    public bool HasNextMessage(int index) => index < data.Count;

    public string Get(int index)
    { 
        if (!HasNextMessage(index))
        {
            return "";
        }
        var message = data[index];
        return message;
    }
}
