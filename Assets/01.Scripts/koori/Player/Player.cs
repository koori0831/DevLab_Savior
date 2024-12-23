using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] VoidEventChannelSO findPlayerEvent;
    [SerializeField] TransformEventChannel playerPosEvent;
    [SerializeField] Vector2EventChannelSO attackEventChannel;
    [SerializeField] BoolEventChannelSO gameOverEventChannel;
    [SerializeField] IntEventChannelSO levelUpEventChannel;
    [SerializeField] PlayerInputSO playerInput;

    [SerializeField] int expAdded = 5;

    [SerializeField] LayerMask expLayer;
    [SerializeField] float expDetectRange;

    public int Level { get; private set; }
    private int _exp;

    private PlayerMover _mover;

    [SerializeField] Rigidbody2D rigidBody;
    [SerializeField] Bullet bullet;
    [SerializeField] MoveModerator moveModerator;

    private void Awake()
    {
        PlayerControl(true);

        findPlayerEvent.OnEventRaised += HandleFindPlayerEvent;
        playerInput.AttackEvent.OnvalueChanged += HandleAttackEvent;
        _mover = GetComponent<PlayerMover>();

        playerInput.InputDirection.OnvalueChanged += OnMove;
    }

    private void HandleAttackEvent(bool prev, bool next)
    {
        Debug.Log(next);
        if (next)
            attackEventChannel.RaiseEvent(transform.position);
    }
    private void OnMove(Vector2 prev, Vector2 next)
    {
        moveModerator.Initialize(rigidBody, next);
        moveModerator.ExecuteEvent();
    }


    private void OnDestroy()
    {
        findPlayerEvent.OnEventRaised -= HandleFindPlayerEvent;
    }
    private void HandleFindPlayerEvent()
    {
        playerPosEvent.RaiseEvent(transform);
    }
    private void Update()
    {
        Collider2D exp = Physics2D.OverlapCircle(transform.position, expDetectRange, expLayer);
        if (exp != null)
        {
            Destroy(exp.gameObject);
            AddExp(expAdded);
        }
    }

    // private void FixedUpdate()
    // {
    //     _mover.SetMovement(playerInput.InputDirection);
    // }

    public void AddExp(int value)
    {
        _exp += value;

        for (; _exp >= 50; _exp -= 50)
        {
            Level++;
            levelUpEventChannel.RaiseEvent(Level);
        }
    }

    public void GameOver()
    {
        PlayerControl(false);
        GameManager.Instance.UIManager.GameOverPopup(true);
        gameOverEventChannel.RaiseEvent(true);
    }

    public void PlayerControl(bool value)
    {
        if (value)
            playerInput.Controls.Enable();
        else playerInput.Controls.Disable();
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, expDetectRange);
    }
}
