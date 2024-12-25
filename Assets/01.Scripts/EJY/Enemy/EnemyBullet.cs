using System;
using UnityEngine;

public class EnemyBullet : MonoBehaviour, IPoolable
{
    [SerializeField] private string _poolName = "EnemyBullet";
    [SerializeField] protected float _lifeTime;

    [SerializeField] private BoolEventChannelSO stopGameChannel;
    [SerializeField] private BoolEventChannelSO _forcePush;

    private float _currentLifeTime = 0;

    private bool _isDead = false;

    private Rigidbody2D _rigidCompo;
    private TrailRenderer _trailRendererCompo;

    private Vector2 _beforeVelocity;

    public string PoolName => _poolName;

    public GameObject ObjectPrefab => gameObject;

    private void Awake()
    {
        _rigidCompo = GetComponent<Rigidbody2D>();
        _trailRendererCompo = GetComponentInChildren<TrailRenderer>();
        _forcePush.OnValueEvent += ForcePush;
        stopGameChannel.OnValueEvent += StopGame;
    }


    private void Update()
    {
        if(_isDead) return;

        _currentLifeTime += Time.deltaTime;

        if (_currentLifeTime > _lifeTime)
        {
            _isDead = true;
            PoolManager.Instance.Push(this);
        }
    }


    private void OnDestroy()
    {
        _forcePush.OnValueEvent -= ForcePush;
        stopGameChannel.OnValueEvent -= StopGame;
    }

    private void ForcePush(bool value)
    {
        if (gameObject.activeSelf != value)
            PoolManager.Instance.Push(this);
    }

    private void StopGame(bool value)
    {
        if (value)
        {
            _beforeVelocity = _rigidCompo.linearVelocity;
            _rigidCompo.linearVelocity = Vector2.zero;
        }
        else
        {
            _rigidCompo.linearVelocity = _beforeVelocity;
        }
    }

    public void SetVelocityAndPosition(Vector2 position,Vector2 velocity)
    {
        transform.position = position;
        _rigidCompo.linearVelocity = velocity;
        _trailRendererCompo.Clear();
    }

    public void ResetItem()
    {
        _isDead = false;
        _currentLifeTime = 0;

    }
}
