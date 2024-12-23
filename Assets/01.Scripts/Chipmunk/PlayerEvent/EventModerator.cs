using UnityEngine;
using UnityEngine.Events;

public abstract class EventModerator<T> : ScriptableObject where T : EventModerator<T>
{
    [Header("")]
    public UnityEvent<T> onEvent = new UnityEvent<T>();
    public void ExecuteEvent()
    {
        onEvent.Invoke(this as T);
        Excute();
    }
    protected abstract void Excute();
}
