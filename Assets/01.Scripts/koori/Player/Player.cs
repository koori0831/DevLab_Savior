using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] VoidEventChannelSO findPlayerEvent;
    [SerializeField] Vector2EventChannelSO playerPosEvent;

    private void Awake()
    {
        findPlayerEvent.OnEventRaised += HandleFindPlayerEvent;
    }
    private void HandleFindPlayerEvent()
    {
        playerPosEvent.RaiseEvent(transform.position);
    }
}
