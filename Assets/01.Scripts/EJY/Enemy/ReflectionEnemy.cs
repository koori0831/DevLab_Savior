using UnityEngine;

public class ReflectionEnemy : DynamicEnemy
{
    [SerializeField] private LayerMask _whatIsWall;
    [SerializeField] private float _shotPower;

    private bool _isFirst = true;
    [SerializeField] private Collider2D _collider;

    protected override void Contact()
    {
        if (_isFirst)
        {
            _isFirst = false;
            RigidCompo.linearVelocity = (player.transform.position - transform.position).normalized * _speed;
            _collider.enabled = true;
        }
        else
        {
            Attack();
        }

        Debug.Log("����");
    }

    private void Attack()
    {
        EnemyBullet enemyBullet = PoolManager.Instance.Pop("EnemyBullet") as EnemyBullet;

        Vector2 dirToTarget = player.transform.position - transform.position;

        enemyBullet.SetVelocityAndPosition(transform.position, dirToTarget.normalized * _shotPower);

        enemyBullet.transform.rotation = Quaternion.FromToRotation(Vector2.up, dirToTarget);
    }
}
