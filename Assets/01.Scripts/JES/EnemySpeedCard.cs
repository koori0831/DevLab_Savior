using UnityEngine;

[CreateAssetMenu(menuName = "Card/Normal/EnemySpeed")]
public class EnemySpeedCard : CardSO
{
    [SerializeField] private MoveModerator enemyMoveMo;
    [SerializeField] private float minusSpeed = 0.8f;
    public override void OnEquip(Player player)
    {
        enemyMoveMo.MoveSpeed *= minusSpeed;
    }
}