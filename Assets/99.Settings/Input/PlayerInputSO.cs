using System;
using Chipmunk.Library;
using UnityEngine;
using UnityEngine.InputSystem;

[CreateAssetMenu(fileName = "PlayerInputSO", menuName = "SO/PlayerInputSO")]
public class PlayerInputSO : ScriptableSingleton<PlayerInputSO>, Controls.IPlayerActions
{
    public NotifyValue<bool> AttackEvent;

    public NotifyValue<Vector2> InputDirection { get; private set; } = new NotifyValue<Vector2>();

    public Controls Controls;
    protected override void OnEnable()
    {
        base.OnEnable();

        if (Controls == null)
        {
            Controls = new Controls();
            Controls.Player.SetCallbacks(this);
        }
        Controls.Player.Enable();
    }

    private void OnDisable()
    {
        Controls.Player.Disable();
    }
    public void OnAttack(InputAction.CallbackContext context)
    {
        if (context.performed)
            AttackEvent.Value = true;
        if (context.canceled)
            AttackEvent.Value = false;
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        InputDirection.Value = context.ReadValue<Vector2>();
    }
}
