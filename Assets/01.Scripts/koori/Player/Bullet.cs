using System;
using System.Collections;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] Vector2EventChannelSO attackEventChannel;
    [SerializeField] float speed;
    [SerializeField] CollisionEventChannelSO collisionEventChannel;
    private Vector2 _windowsPos;

    public Rigidbody2D rb { get; private set; }
    [SerializeField] private MoveModerator bulletMove;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        attackEventChannel.OnEventRaised += Move;

        WindowMove.Move(Screen.mainWindowPosition);
    }
    private void OnDestroy()
    {
        attackEventChannel.OnEventRaised -= Move;
    }

    private void Update()
    {
        WindowMove.Move(_windowsPos);
    }

    private void Move(Vector2 playerPos)
    {
        Debug.Log("Move");  
        bulletMove.Initialize(rb, (playerPos - (Vector2)transform.position).normalized);
        bulletMove.ExecuteEvent();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameManager.Instance.CameraManager.ShakeCamera(0.1f, 0.1f);
        Debug.Log(collision.gameObject.tag);

        _windowsPos = rb.linearVelocity.normalized * 5;

        if (collision.gameObject.TryGetComponent(out Player player))
        {
            Debug.Log(player);
            player.GameOver();
        }

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
