using UnityEngine;


[CreateAssetMenu(menuName = "Card/Curse/Window")]
public class WindowOnCard : CardSO
{
    [SerializeField] private MoveModerator enemyMoveMo;
    [SerializeField] private float minusSpeed = 0.8f;
    public override void OnEquip(Player player)
    {
        player.Bullet.windowMove = true;
        enemyMoveMo.MoveSpeed *= minusSpeed;
    }
}
