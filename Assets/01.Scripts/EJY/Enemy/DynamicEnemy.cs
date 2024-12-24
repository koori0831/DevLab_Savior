using UnityEngine;
using UnityEngine.Events;

public class DynamicEnemy : Enemy
{
    [SerializeField] private float _speed;

    public UnityEvent OnReflectionEvent;

    protected override void Contact()
    {
        Vector2 dir = (Vector2)_player.transform.position  - (Vector2)transform.position;

        RigidCompo.linearVelocity = dir.normalized * _speed;
    }
}
