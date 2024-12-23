using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] VoidEventChannelSO findPlayerEvent;
    [SerializeField] TransformEventChannel playerPosEvent;
    [SerializeField] Vector2EventChannelSO attackEventChannel;
    [SerializeField] BoolEventChannelSO gameOverEventChannel;
    [SerializeField] PlayerInputSO playerInput;
    
    [SerializeField] int expAdded = 5;

    [SerializeField] LayerMask expLayer;
    [SerializeField] float expDetectRange;

    public int Level { get; private set; }
    private int _exp;

    private PlayerMover _mover;

    private void Awake()
    {
        PlayerControl(true);

        findPlayerEvent.OnEventRaised += HandleFindPlayerEvent;
        playerInput.AttackEvent += HandleAttackEvent;
        _mover = GetComponent<PlayerMover>();
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

    private void FixedUpdate()
    {
        _mover.SetMovement(playerInput.InputDirection);
    }

    public void AddExp(int value)
    {
        _exp += value;

        for (; _exp >= 50; _exp -= 50)
        {
            Level++;
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
