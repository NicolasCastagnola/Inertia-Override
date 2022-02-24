using System;
using System.Collections.Generic;
using System.Linq;
public enum EventType { SaveData, LoadData, FetchData, OnGameInitialization, OnNewHighscoreSet, Deafeat, Victory, OnCheckpointSave, OnCheckpointLoaded }
public static class EventManager
{
    public delegate void EventReceiver(params object[] parameters);

    static Dictionary<EventType, EventReceiver> _events = new Dictionary<EventType, EventReceiver>();

    public static void Subscribe(EventType eventType, EventReceiver listener)
    {
        if (!_events.ContainsKey(eventType)) _events.Add(eventType, listener);
            
        else _events[eventType] += listener;
    }

    public static void UnSubscribe(EventType eventType, EventReceiver listener)
    {
        if (_events.ContainsKey(eventType))
        {
            _events[eventType] -= listener;

            if (_events[eventType] == null) _events.Remove(eventType);
        }
    }

    public static void TriggerEvent(EventType eventType, params object[] parameters)
    {
        if (_events.ContainsKey(eventType)) _events[eventType](parameters);
    }

    public static void Clear()
    {
        _events.Clear();
    }
}
