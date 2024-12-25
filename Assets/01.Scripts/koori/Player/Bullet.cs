using System;
using System.Collections;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] Vector2EventChannelSO attackEventChannel;
    [SerializeField] BoolEventChannelSO StopEventChannel;
    [SerializeField] float speed;
    [SerializeField] CollisionEventChannelSO collisionEventChannel;

    public bool windowMove;
    private Vector2 _windowsPos;
    private int stopValue = 1;

    public Rigidbody2D rb { get; private set; }
    [SerializeField] private MoveModerator bulletMove;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        attackEventChannel.OnEventRaised += Move;
        StopEventChannel.OnValueEvent += Stop;

        WindowMove.Move(Screen.mainWindowPosition);
    }

    private void Stop(bool obj)
    {
        if (obj) rb.linearVelocity = Vector2.zero;
        stopValue = obj ? 1 : 0;
    }

    private void OnDestroy()
    {
        attackEventChannel.OnEventRaised -= Move;
        StopEventChannel.OnValueEvent -= Stop;
    }

    private void Update()
    {
        if (windowMove) 
            WindowMove.Move(_windowsPos);
    }

    private void Move(Vector2 playerPos)
    {
        Debug.Log("Move");  
        bulletMove.Initialize(rb, (playerPos - (Vector2)transform.position).normalized * stopValue);
        bulletMove.ExecuteEvent();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameManager.Instance.CameraManager.ShakeCamera(0.1f, 0.1f);

        _windowsPos = rb.linearVelocity.normalized * 5;

        collisionEventChannel.RaiseEvent(collision);
    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(collision.gameObject);
        }
    }
}
