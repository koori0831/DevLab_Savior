using UnityEngine;
using static UnityEngine.EventSystems.EventTrigger;
using UnityEngine.UIElements;
using System;

public class PlayerMover : MonoBehaviour
{
    [SerializeField] private float _moveSpeed = 5f;
    private Vector2 _movement;

    public bool CanManualMove { get; set; } = true;
    public Vector2 Velocity => _rbCompo.linearVelocity;
    private Rigidbody2D _rbCompo;


    public event Action<Vector2> OnMoveVelocity;
    private float _moveSpeedMultiplier;

    private void Awake()
    {
        Initialize();
    }
    public void Initialize()
    {
        _rbCompo = GetComponent<Rigidbody2D>();

        _moveSpeedMultiplier = 1f;
    }
    public void SetMoveSpeedMultiplier(float value) => _moveSpeedMultiplier = value;

    public void AddForceToEntity(Vector2 force)
    {
        _rbCompo.AddForce(force, ForceMode2D.Impulse);
    }
    public void StopImmediately()
    {
        _rbCompo.linearVelocity = Vector2.zero;
    }
    public void SetMovement(Vector2 movement)
    {
        _movement = movement;
    }
    private void FixedUpdate()
    {
        MoveCharacter();
    }
    private void MoveCharacter()
    {
        if (CanManualMove)
        {
            _rbCompo.linearVelocity = _movement * _moveSpeed * _moveSpeedMultiplier;
        }

        OnMoveVelocity?.Invoke(_rbCompo.linearVelocity);
    }
}
