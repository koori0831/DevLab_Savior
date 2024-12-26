using UnityEngine;


[CreateAssetMenu(menuName = "Card/Curse/Window")]
public class WindowOnCard : CardSO
{
    [SerializeField] private MoveModerator enemyMoveMo;
    [SerializeField] private float minusSpeed = 0.8f;
    public override void OnEquip(Player player)
    {
        WindowMove.Move(Screen.mainWindowPosition);
        player.Bullet.windowMove = true;
        enemyMoveMo.MoveSpeed *= minusSpeed;
    }
}
