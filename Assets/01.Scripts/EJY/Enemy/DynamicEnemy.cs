using UnityEngine;
using UnityEngine.Events;

public class DynamicEnemy : Enemy
{
    [SerializeField] protected float _speed;

    private Vector2 _beforeVelocity;

    public UnityEvent OnReflectionEvent;

    protected override void Contact()
    {
        Vector2 dir = (Vector2)player.transform.position  - (Vector2)transform.position;

        RigidCompo.linearVelocity = dir.normalized * _speed;
    }

    protected override void StopGame(bool value)
    {
        if (value)
        {
            _beforeVelocity = RigidCompo.linearVelocity;
            RigidCompo.linearVelocity = Vector2.zero;
        }
        else
        {
            RigidCompo.linearVelocity = _beforeVelocity;
        }
    }

    protected override void OnDestroy()
    {
        base.OnDestroy();
        stopGameChannel.OnValueEvent -= StopGame;
    }
}
