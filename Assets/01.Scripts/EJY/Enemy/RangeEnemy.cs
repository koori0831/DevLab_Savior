using System;
using UnityEngine;

public class RangeEnemy : StaticEnemy
{
    [SerializeField] private float _shotPower;
    [SerializeField] private float _attackCoolTime;

    private float _currentAttackTime = 0;

    protected override void Update()
    {
        if (player == null)
            return;

        if (isStop) return;

        _currentAttackTime += Time.deltaTime;

        if (_currentAttackTime > _attackCoolTime && canHit)
            Attack();
    }

    private void Attack()
    {
        _currentAttackTime = 0;

        EnemyBullet enemyBullet = PoolManager.Instance.Pop("EnemyBullet") as EnemyBullet;

        Vector2 dirToTarget = player.transform.position - transform.position;

        enemyBullet.SetVelocityAndPosition(transform.position, dirToTarget.normalized * _shotPower);

        enemyBullet.transform.rotation = Quaternion.FromToRotation(Vector2.up, dirToTarget);
    }
}
