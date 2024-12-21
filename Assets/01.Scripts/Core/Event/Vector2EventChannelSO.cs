using System;
using UnityEngine;

[CreateAssetMenu(fileName = "Vector2EventChannelSO", menuName = "SO/Events/Vector2EventChannelSO")]
public class Vector2EventChannelSO : ScriptableObject
{
    public Action<Vector2> OnEventRaised;

    public void RaiseEvent(Vector2 value)
    {
        OnEventRaised?.Invoke(value);
    }
}
