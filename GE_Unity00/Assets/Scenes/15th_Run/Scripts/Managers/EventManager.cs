using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public enum EventType
{
    START,
    CONTINUE,
    PASUE,
    STOP
}

public class EventManager
{
    public static readonly IDictionary<EventType, UnityEvent> dictionary = new Dictionary<EventType, UnityEvent>();

    public static void Subscribe(EventType eType, UnityAction uAction)
    {
        UnityEvent unityEvent = null;
        
        if (dictionary.TryGetValue(eType, out unityEvent))
        {
            unityEvent.AddListener(uAction);
        }
        else
        {
            unityEvent = new UnityEvent();
            unityEvent.AddListener(uAction);
            dictionary.Add(eType, unityEvent);
        }
    }

    public static void Unsubscribe(EventType eType, UnityAction uAction)
    {
        UnityEvent unityEvent = null;

        if (dictionary.TryGetValue(eType, out unityEvent))
        {
            unityEvent.RemoveListener(uAction);
        }
    }

    public static void Publish(EventType eType)
    {
        UnityEvent unityEvent = null;

        if (dictionary.TryGetValue(eType, out unityEvent))
        {
            unityEvent.Invoke();
        }
    }
}
