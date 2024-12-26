using System;
using UnityEngine;

[CreateAssetMenu(menuName = "SO/Card/SpawnObjectOnCollision")]
public class SpawnObjectOnCollisionCard : CardSO
{
    [SerializeField] CollisionEventChannelSO collisionEventChannel;
    [SerializeField] GameObject objectToSpawn;
    public override void OnEquip(Player player)
    {
        collisionEventChannel.OnValueEvent += OnCollisionEvent;
    }

    private void OnCollisionEvent(Collision2D d)
    {
        Debug.Log(d.otherCollider.name);
        Instantiate(objectToSpawn, d.contacts[0].point, Quaternion.identity);
        if(objectToSpawn.TryGetComponent(out IInitailizeable<Collision2D> initailizeable))
        {
            initailizeable.Initailize(d);
        }
    }
}
