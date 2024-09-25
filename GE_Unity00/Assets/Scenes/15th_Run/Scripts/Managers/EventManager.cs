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

    public static void Subscribe(EventType eType, UnityAction action)
    {
        UnityEvent unityEvent = new UnityEvent();
        unityEvent.AddListener(action);
    }

    public static void Cancel(EventType eType, UnityAction action)
    {

    }

    public static void Publish(EventType eType)
    {

    }

}
