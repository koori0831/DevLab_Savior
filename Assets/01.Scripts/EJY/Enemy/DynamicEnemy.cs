using UnityEngine;
using UnityEngine.Events;

public class DynamicEnemy : Enemy
{
    [SerializeField] private float _speed;

    public UnityEvent OnReflectionEvent;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer != 8)
        {
            if (_isDead == false)
            {
                DirectionToTarget(_player.transform.position);
            }
        }
        else
        {
            SetDead();
        }
    }

    public void DirectionToTarget(Vector2 target)
    {
        Vector2 dir = target - (Vector2)transform.position;

        RigidCompo.linearVelocity = dir.normalized * _speed;
    }
}
