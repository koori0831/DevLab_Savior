using UnityEngine;

public class ReflectionEnemy : DynamicEnemy
{
    [SerializeField] private float _shotPower;

    private bool _isFirst = true;

    protected override void Contact()
    {
        if (_isFirst)
        {
            _isFirst = false;
            RigidCompo.linearVelocity = (player.transform.position - transform.position).normalized * _speed;
        }
        else
        {
            Attack();
        }
    }

    private void Attack()
    {
        EnemyBullet enemyBullet = PoolManager.Instance.Pop("EnemyBullet") as EnemyBullet;

        Vector2 dirToTarget = player.transform.position - transform.position;

        enemyBullet.SetVelocityAndPosition(transform.position, dirToTarget.normalized * _shotPower);

        enemyBullet.transform.rotation = Quaternion.FromToRotation(Vector2.up, dirToTarget);
    }
}
