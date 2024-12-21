using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] VoidEventChannelSO findPlayerEvent;
    [SerializeField] Vector2EventChannelSO playerPosEvent;
    [SerializeField] PlayerInputSO playerInput;

    private PlayerMover _mover;

    private void Awake()
    {
        findPlayerEvent.OnEventRaised += HandleFindPlayerEvent;
        _mover = GetComponent<PlayerMover>();
    }
    private void OnDestroy()
    {
        findPlayerEvent.OnEventRaised -= HandleFindPlayerEvent;
    }
    private void HandleFindPlayerEvent()
    {
        playerPosEvent.RaiseEvent(transform.position);
    }

    private void FixedUpdate()
    {
        _mover.SetMovement(playerInput.InputDirection);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameManager.Instance.CameraManager.ShakeCamera(0.1f, 0.1f);
    }
}
