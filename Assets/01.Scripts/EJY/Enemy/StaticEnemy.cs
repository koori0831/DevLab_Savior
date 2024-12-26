using System;
using System.Collections;
using UnityEngine;

public abstract class StaticEnemy : Enemy
{
    private CircleCollider2D _collider;

    protected override void Awake()
    {
        base.Awake();
        _collider = GetComponent<CircleCollider2D>();
    }

    public void SetCollider(bool value)
    {
        _collider.enabled = value;
    }
}
