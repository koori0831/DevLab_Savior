using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class Enemy : MonoBehaviour, IPoolable
{
    [SerializeField] private TransformEventChannel _playerPosEvent;
    [SerializeField] private VoidEventChannelSO _findPlayerEvent;

    [SerializeField] private float _speed;

    [SerializeField] private string _poolName;

    public UnityEvent OnReflectionEvent;
    public UnityEvent OnDeadEvent;

    public Rigidbody2D RigidCompo { get; private set; }

    public string PoolName => _poolName;

    public GameObject ObjectPrefab => gameObject;

    private Player _player;

    private bool _isDead = false;
    private void Awake()
    {
        RigidCompo = GetComponent<Rigidbody2D>();

        _playerPosEvent.OnEventRaised += SetTarget;

        _findPlayerEvent.RaiseEvent();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (_isDead == false)
        {
            OnReflectionEvent?.Invoke();
            DirectionToTarget(_player.transform.position);
        }
    }

    private void OnApplicationQuit()
    {
        _playerPosEvent.OnEventRaised -= SetTarget;
    }

    public void SetTarget(Transform player)
    {
        _player = player.GetComponent<Player>();
    }

    public void SetPosition(Vector2 position) => transform.position = position;

    public void DirectionToTarget(Vector2 target)
    {
        Vector2 dir = target - (Vector2)transform.position;

        RigidCompo.linearVelocity = dir.normalized * _speed;
    }

    public void SetDead()
    {
        _isDead = true;
        OnDeadEvent?.Invoke();
    }

    public void ResetItem()
    {
        _isDead = false;
    }
}
