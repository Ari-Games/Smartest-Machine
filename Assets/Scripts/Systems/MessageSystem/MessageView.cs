using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MessageView : MonoBehaviour
{
    [SerializeField] private Text textView;

    private Transform[] childrens;

    private void Awake()
    {
        childrens = transform.Children();
        SignalSystem<MessageViewSignal>.Sub(OnMessageViewSignalHandler);
    }

    private void OnDestroy()
    {
        SignalSystem<MessageViewSignal>.UnSub(OnMessageViewSignalHandler);
    }

    private void OnMessageViewSignalHandler(MessageViewSignal signal)
    {
        childrens.Map(t => t.gameObject.SetActive(signal.IsView));
        textView.text = signal.Message;
    }
}
