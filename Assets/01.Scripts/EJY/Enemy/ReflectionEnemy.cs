using UnityEngine;

public class ReflectionEnemy : DynamicEnemy
{
    [SerializeField] private LayerMask _whatIsWall;
    [SerializeField] private float _shotPower;

    private bool _isFirst = true;

    protected override void Contact()
    {
        if (_isFirst)
        {
            _isFirst = false;
            _moveModerator.Initialize(RigidCompo, (player.transform.position - transform.position).normalized);
            _moveModerator.ExecuteEvent();
        }
        else
        {
            Vector2 velocity = RigidCompo.linearVelocity;

            RaycastHit2D hit = Physics2D.Raycast(transform.position, velocity, 30, _whatIsWall);

            float dot = Vector2.Dot(-velocity, hit.normal);

            Vector2 reflection = velocity + ((2 * hit.normal) * dot);

            _moveModerator.Initialize(RigidCompo, reflection.normalized);
            _moveModerator.ExecuteEvent();

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

    public override void ResetItem()
    {
        base.ResetItem();
        _isFirst = true;
    }
}
