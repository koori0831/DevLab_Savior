using System;
using UnityEngine;

[CreateAssetMenu(fileName = "CollisionEventChannelSO", menuName = "SO/Events/CollisionEventChannelSO")]
public class CollisionEventChannelSO : ScriptableObject
{
    public Action<Collision2D> OnValueEvent;

    public void RaiseEvent(Collision2D value)
    {
        OnValueEvent?.Invoke(value);
    }
}
