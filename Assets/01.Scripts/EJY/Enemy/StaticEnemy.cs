using System;
using System.Collections;
using UnityEngine;

public abstract class StaticEnemy : Enemy
{
    protected override void Awake()
    {
        base.Awake();
    }

    public void MoveToPos(Vector2 pos)
    {
        StartCoroutine(MoveToPosCoroutine(pos));
    }

    private IEnumerator MoveToPosCoroutine(Vector2 pos)
    {
        RigidCompo.MovePosition(pos);
        Debug.Log(RigidCompo.linearVelocity);

        _canHit = false;

        while (RigidCompo.linearVelocity != Vector2.zero)
        {
            yield return null;
        }

        _canHit = true;
    }
}
