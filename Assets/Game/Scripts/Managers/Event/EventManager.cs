using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


#region ENUMS

public enum EventTypes
{
    LevelStart,
    GameStart,
    Win,
    Fail,
    KeepMove
}

#endregion

public class EventManager : MonoBehaviour
{
    #region PUBLIC PROPERTIES

    public Dictionary<EventTypes, UnityAction<EventArgs>> events = new Dictionary<EventTypes, UnityAction<EventArgs>>();

    #endregion

    #region PRIVATE PROPERTIES

    private UnityAction<EventArgs> onStationary;

    #endregion

    #region PUBLIC METHODS

    public void Initialize()
    {
        foreach (EventTypes foo in Enum.GetValues(typeof(EventTypes)))
        {
            EventHolder<EventArgs> eventHolder = new EventHolder<EventArgs>();
            events.Add(foo, eventHolder.OnEvent);
        }
    }

    public void Register(EventTypes eventType, UnityAction<EventArgs> callback)
    {
        events[eventType] += callback;
    }

    public void Unregister(EventTypes eventType, UnityAction<EventArgs> callback)
    {
        events[eventType] -= callback;
    }

    public void InvokeEvent(EventTypes eventType, EventArgs eventArgs = null)
    {
        events[eventType]?.Invoke(eventArgs);
    }

    #endregion
}