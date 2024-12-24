using UnityEngine;

public class RangeEnemy : StaticEnemy
{
    [SerializeField] private float _shotPower;
    [SerializeField] private float _attackCoolTime;

    private float _currentAttackTime;

    protected override void Update()
    {
        if (_player == null)
            return;

        if (Time.time - _currentAttackTime > _attackCoolTime && _canHit)    
            Attack();
    }

    private void Attack()
    {
        _currentAttackTime = Time.time;

        EnemyBullet enemyBullet = PoolManager.Instance.Pop("EnemyBullet") as EnemyBullet;

        Vector2 dirToTarget = _player.transform.position - transform.position;

        enemyBullet.SetVelocityAndPosition(transform.position, dirToTarget.normalized * _shotPower);

        enemyBullet.transform.rotation = Quaternion.FromToRotation(Vector2.up,dirToTarget);
    }
}
