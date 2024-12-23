using UnityEngine;

public class EnemyBullet : MonoBehaviour, IPoolable
{
    [SerializeField] private string _poolName = "EnemyBullet";

    private Rigidbody2D _rigidCompo;

    public string PoolName => _poolName;

    public GameObject ObjectPrefab => gameObject;

    private void Awake()
    {
        _rigidCompo = GetComponent<Rigidbody2D>();
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
    }

    public void ResetItem()
    {

    }
}
