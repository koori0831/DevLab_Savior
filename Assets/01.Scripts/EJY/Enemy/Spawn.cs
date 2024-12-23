using System;
using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

public class Spawner : MonoBehaviour
{
    [SerializeField] private EnemyKindListSO _enemyKindList;

    [SerializeField] private float _spawnCoolTime;

    private Camera _cam;

    private float _right;
    private float _left;
    private float _up;
    private float _down;

    private int _enemiesCnt;

    private void Awake()
    {
        _cam = Camera.main;

        _right = _cam.ViewportToWorldPoint(Vector2.one).x;
        _left = _cam.ViewportToWorldPoint(Vector2.zero).x;
        _up = _cam.ViewportToWorldPoint(Vector2.one).y;
        _down = _cam.ViewportToWorldPoint(Vector2.zero).y;

        _enemiesCnt = _enemyKindList.enemyKindList.Count;
    }

    private void Start()
    {
        StartCoroutine(SpawnCoroutine());
    }

    private IEnumerator SpawnCoroutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(_spawnCoolTime);
            Spawn();
        }
    }

    public void Spawn()
    {
        bool xyFlag = (Random.value > 0.5f);
        bool zeroFlag = (Random.value > 0.5f);

        float x;
        float y;

        if (xyFlag)
        {
            x = Random.Range(_left, _right);

            if (zeroFlag)
                y = _down;
            else
                y = _up;
        }
        else
        {
            y = Random.Range(_down, _up);

            if (zeroFlag)
                x = _left;
            else
                x = _right;
        }

        Vector2 position = new Vector2(x, y);

        int idx = Random.Range(0, _enemiesCnt);
        string enemyTypeName = _enemyKindList.enemyKindList[idx].enemyName;

        Enemy enemy = PoolManager.Instance.Pop(enemyTypeName) as Enemy;
        enemy.SetPosition(position);

        if (enemy.TryGetComponent(out StaticEnemy staticEnemy))
        {
            position.x = Random.Range(_left + 2.25f, _right - 2.25f);
            position.y = Random.Range(_down + 2.25f, _up - 2.25f);
            staticEnemy.MoveToPos(position);
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(transform.position, new Vector2(_right - _left, _up - _down));
        Gizmos.color = Color.green;
        Gizmos.DrawWireCube(transform.position, new Vector2((_right - _left) - 4.5f, (_up - _down) - 4.5f));
        Gizmos.color = Color.white;
    }
}