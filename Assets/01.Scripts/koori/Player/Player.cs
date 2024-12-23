using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] VoidEventChannelSO findPlayerEvent;
    [SerializeField] Vector2EventChannelSO playerPosEvent;
    [SerializeField] Vector2EventChannelSO attackEventChannel;
    [SerializeField] PlayerInputSO playerInput;

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
        playerPosEvent.RaiseEvent(transform.position);
    }

    private void FixedUpdate()
    {
        _mover.SetMovement(playerInput.InputDirection);
    }

    public void GameOver()
    {
        PlayerControl(false);
        GameManager.Instance.UIManager.GameOverPopup(true);
    }

    public void PlayerControl(bool value)
    {
        if (value)
            playerInput.Controls.Enable();
        else playerInput.Controls.Disable();
    }
}
