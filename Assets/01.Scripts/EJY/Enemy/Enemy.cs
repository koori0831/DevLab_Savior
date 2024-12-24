using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public abstract class Enemy : MonoBehaviour, IPoolable
{
    [SerializeField] private TransformEventChannel _playerPosEvent;
    [SerializeField] private VoidEventChannelSO _findPlayerEvent;

    [SerializeField] private string _poolName;

    public Rigidbody2D RigidCompo { get; private set; }

    public UnityEvent OnDeadEvent;
    public string PoolName => _poolName;

    public GameObject ObjectPrefab => gameObject;

    protected Player _player;

    protected bool _canHit = true;
    protected bool _isDead = false;

    protected virtual void Awake()
    {
        RigidCompo = GetComponent<Rigidbody2D>();

        _playerPosEvent.OnEventRaised += SetTarget;

        _findPlayerEvent.RaiseEvent();
    }

    protected virtual void OnApplicationQuit()
    {
        _playerPosEvent.OnEventRaised -= SetTarget;
    }

    private void SetTarget(Transform player)
    {
        _player = player.GetComponent<Player>();
    }

    public void SetPosition(Vector2 position) => transform.position = position;

    public virtual void SetDead()
    {
        _isDead = true;
        OnDeadEvent?.Invoke();
    }

    public virtual void ResetItem()
    {
        _isDead = false;
        _canHit = true;
    }
}
