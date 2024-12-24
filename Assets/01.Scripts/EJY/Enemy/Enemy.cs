using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public abstract class Enemy : MonoBehaviour, IPoolable
{
    [SerializeField] protected BoolEventChannelSO stopGameChannel;
    [SerializeField] private BoolEventChannelSO _forcePush;
    [SerializeField] private TransformEventChannel _playerPosEvent;
    [SerializeField] private VoidEventChannelSO _findPlayerEvent;

    [SerializeField] private string _poolName;

    public Rigidbody2D RigidCompo { get; private set; }

    public UnityEvent OnDeadEvent;
    public string PoolName => _poolName;

    public GameObject ObjectPrefab => gameObject;

    protected Player player;

    protected bool canHit = true;
    protected bool canAttack = true;
    protected bool isDead = false;
    protected bool isStop = false;

    protected virtual void Awake()
    {
        RigidCompo = GetComponent<Rigidbody2D>();

        _playerPosEvent.OnEventRaised += SetTarget;
        _forcePush.OnValueEvent += ForcePush;
    }

    private void OnEnable()
    {
        if(player.IsUnityNull())
        _findPlayerEvent.RaiseEvent();
    }

    protected virtual void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (canHit == false) return;

        if (isDead == false)
        {
            if (collision.gameObject.layer != 8)
            {
                Contact();
            }
            else
            {
                Debug.Assert(canHit, "안맞아야하는데 죽었어");
                SetDead();
            }
        }

    }

    protected virtual void OnDestroy()
    {
        _playerPosEvent.OnEventRaised -= SetTarget;
        _forcePush.OnValueEvent -= ForcePush;
    }

    private void ForcePush(bool value)
    {
        Debug.Log(gameObject.activeSelf != value);
        if (gameObject.activeSelf != value)
            PoolManager.Instance.Push(this);

    }

    protected virtual void Contact()
    {

    }

    private void SetTarget(Transform player)
    {
        this.player = player.GetComponent<Player>();
    }

    public void SetPosition(Vector2 position) => transform.position = position;

    public virtual void SetDead()
    {
        isDead = true;
        OnDeadEvent?.Invoke();
    }

    public void SetAble(bool value)
    {
        canAttack = value;
        canHit = value;
    }

    public virtual void ResetItem()
    {
        isDead = false;
        canAttack = true;
        canHit = true;
    }
}
