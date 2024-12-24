using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Vector2 _enemySpawnArea;
    [SerializeField] private Vector2 _staticEnemyArea;
    [SerializeField] private float _spawnCoolTime;

    public List<GameObject> _enemyList = new();

    private List<IPoolable> _poolables;

    private float _right;
    private float _left;
    private float _up;
    private float _down;

    private int _enemiesCnt;

    private void Awake()
    {
        _right = _enemySpawnArea.x / 2;
        _left = -(_enemySpawnArea.x / 2);
        _up = _enemySpawnArea.y / 2;
        _down = -(_enemySpawnArea.y / 2);

        _poolables = _enemyList.Select(item => item.GetComponent<IPoolable>())
            .Where(component => component != null)
            .ToList();

        _enemiesCnt = _enemyList.Count;
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
        string enemyTypeName = _poolables[idx].PoolName;

        Enemy enemy = PoolManager.Instance.Pop(enemyTypeName) as Enemy;
        enemy.SetPosition(position);

        if (enemy.TryGetComponent(out StaticEnemy staticEnemy))
        {
            position.x = Random.Range(-(_staticEnemyArea.x / 2), _staticEnemyArea.x / 2);
            position.y = Random.Range(-(_staticEnemyArea.y / 2), _staticEnemyArea.y / 2);
            staticEnemy.MoveToPos(position);
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(transform.position, _enemySpawnArea);
        Gizmos.color = Color.green;
        Gizmos.DrawWireCube(transform.position, _staticEnemyArea);
        Gizmos.color = Color.white;
    }
}