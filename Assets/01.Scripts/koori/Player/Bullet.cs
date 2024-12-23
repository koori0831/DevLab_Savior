using System;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] Vector2EventChannelSO attackEventChannel;
    [SerializeField] float speed;

    private Rigidbody2D rb;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        attackEventChannel.OnEventRaised += Move;
    }

    private void Move(Vector2 playerPos)
    {
        rb.linearVelocity = (playerPos - (Vector2)transform.position).normalized * speed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameManager.Instance.CameraManager.ShakeCamera(0.1f, 0.1f);
        Debug.Log(collision.gameObject.tag);
        if (collision.gameObject.TryGetComponent(out Player player))
        {
            player.GameOver();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(collision.gameObject);
        }
    }
}
