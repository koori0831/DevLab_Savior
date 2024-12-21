using UnityEngine;

public class Enemy : MonoBehaviour, IPoolable
{
    [SerializeField] private string _poolName;
    public Rigidbody2D RigidCompo { get; private set; }

    public string PoolName => _poolName;

    public GameObject ObjectPrefab => gameObject;

    private void Awake()
    {
        RigidCompo = GetComponent<Rigidbody2D>();
    }

    public void SetTarget()
    {

    }

    public void SetDead()
    {

    }

    public void ResetItem()
    {

    }
}
