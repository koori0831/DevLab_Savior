using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] VoidEventChannelSO findPlayerEvent;
    [SerializeField] Vector2EventChannelSO playerPosEvent;
    [SerializeField] Vector2EventChannelSO attackEventChannel;
    [SerializeField] PlayerInputSO playerInput;

    private PlayerMover _mover;
    private Bullet _bullet;

    private void Awake()
    {
        findPlayerEvent.OnEventRaised += HandleFindPlayerEvent;
        playerInput.AttackEvent += HandleAttackEvent;
        _mover = GetComponent<PlayerMover>();
        _bullet = GetComponent<Bullet>();
    }


    private void OnDestroy()
    {
        findPlayerEvent.OnEventRaised -= HandleFindPlayerEvent;
    }
    private void HandleAttackEvent()
    {
        attackEventChannel.RaiseEvent(transform.position);
    }
    private void HandleFindPlayerEvent()
    {
        playerPosEvent.RaiseEvent(transform.position);
    }

    private void FixedUpdate()
    {
        _mover.SetMovement(playerInput.InputDirection);
    }
}
