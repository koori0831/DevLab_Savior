using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Card/Normal/EnemySpeed")]
public class EnemySpeedCard : CardSO
{
    [SerializeField] private List<MoveModerator> enemyMoveMo;
    [SerializeField] private float minusSpeed = 0.8f;
    public override void OnEquip(Player player)
    {
        enemyMoveMo.ForEach(m => { m.onEvent +=OnExecute; });
    }

    private void OnExecute(MoveModerator arg0)
    {
        arg0.MoveSpeed*= minusSpeed;
    }
}