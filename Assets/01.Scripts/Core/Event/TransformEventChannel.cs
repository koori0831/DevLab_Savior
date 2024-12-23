using System;
using UnityEngine;

[CreateAssetMenu(fileName = "TransformEventChannel", menuName = "SO/Events/TransformEventChannel")]
public class TransformEventChannel : ScriptableObject
{
    public Action<Transform> OnEventRaised;

    public void RaiseEvent(Transform value)
    {
        OnEventRaised?.Invoke(value);
    }
}
