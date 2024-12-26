using System;
using UnityEngine;
using UnityEngine.Events;

public abstract class EventModerator<T> : ScriptableObject where T : EventModerator<T>
{
    [Header("")]
    public Action<T> onEvent;
    public void ExecuteEvent()
    {
        onEvent?.Invoke(this as T);
        Excute();
    }
    protected abstract void Excute();
}
