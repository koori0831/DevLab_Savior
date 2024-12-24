using UnityEngine;

public class EnemyBullet : MonoBehaviour, IPoolable
{
    [SerializeField] private string _poolName = "EnemyBullet";
    [SerializeField] protected float _lifeTime;

    private float _currentLifeTime = 0;

    private bool _isDead = false;

    private Rigidbody2D _rigidCompo;
    private TrailRenderer _trailRendererCompo;

    public string PoolName => _poolName;

    public GameObject ObjectPrefab => gameObject;

    private void Awake()
    {
        _rigidCompo = GetComponent<Rigidbody2D>();
        _trailRendererCompo = GetComponentInChildren<TrailRenderer>();
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Player player))
        {
            player.GameOver();
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
