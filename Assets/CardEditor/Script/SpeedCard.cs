using System;
using UnityEngine;

[CreateAssetMenu(menuName = "Card/Normal/SpeedCard")]
public class SpeedCard : CardSO
{
    [SerializeField] MoveModerator moveModerator;
    [SerializeField] float additiveSpeed;
    public override void OnEquip(Player player)
    {
        moveModerator.onEvent += OnMoveEvent;
    }

    private void OnMoveEvent(MoveModerator arg0)
    {
        arg0.MoveSpeed += additiveSpeed;
    }
}
