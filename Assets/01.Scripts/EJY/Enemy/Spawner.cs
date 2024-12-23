using System.Collections;
using Unity.Cinemachine;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private float _spawnCoolTime;

    private Camera _cam;

    private float _right;
    private float _left;
    private float _up;
    private float _down;

    private void Awake()
    {
        _cam = Camera.main;

        _right = _cam.ViewportToWorldPoint(Vector2.one).x;
        _left = _cam.ViewportToWorldPoint(Vector2.zero).x;
        _up = _cam.ViewportToWorldPoint(Vector2.one).y;
        _down = _cam.ViewportToWorldPoint(Vector2.zero).y;
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

        Enemy enemy = PoolManager.Instance.Pop("Enemy") as Enemy;
        enemy.SetPosition(position);

    }
}