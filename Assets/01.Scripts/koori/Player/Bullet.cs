using System;
using System.Collections;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] TransformEventChannel attackEventChannel;
    [SerializeField] BoolEventChannelSO StopEventChannel;
    [SerializeField] float speed;
    [SerializeField] CollisionEventChannelSO collisionEventChannel;

    public bool windowMove;
    private Vector2 _windowsPos;
    private bool isStop;
    private int stopValue = 1;

    public Rigidbody2D rb { get; private set; }
    [SerializeField] private MoveModerator bulletMove;
    [SerializeField] public Transform followTarget;
    [SerializeField] private float speedByDistance = 0.2f;
    private Coroutine _moveCoroutine;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        PlayerInputSO.Instance.AttackEvent.OnvalueChanged += OnAttack;
        StopEventChannel.OnValueEvent += Stop;
    }

    private void OnAttack(bool prev, bool next)
    {
        if (next)
            Follow(followTarget);
        else
            StopFollow();
    }


    private void Stop(bool obj)
    {
        if (obj) rb.linearVelocity = Vector2.zero;
        isStop = true;
    }

    private void OnDestroy()
    {
        PlayerInputSO.Instance.AttackEvent.OnvalueChanged -= OnAttack;
        StopEventChannel.OnValueEvent -= Stop;
    }

    private void Update()
    {
        if (windowMove)
            WindowMove.Move(_windowsPos);
    }

    private void Follow(Transform playerTrm)
    {
        StopFollow();
        _moveCoroutine = StartCoroutine(FollowCoroutine(playerTrm));
    }

    private IEnumerator FollowCoroutine(Transform playerTrm)
    {
        while (true)
        {
            if (isStop) yield return null;

            Vector2 playerPos = playerTrm.position;

            Vector2 moveVector = (playerPos - (Vector2)transform.position);
            bulletMove.Initialize(rb, moveVector, Mathf.Sqrt(moveVector.magnitude));
            bulletMove.ExecuteEvent();
            yield return null;
        }
    }


    private void StopFollow()
    {
        if (_moveCoroutine != null)
        {
            StopCoroutine(_moveCoroutine);
            _moveCoroutine = null;
        }
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
