using UnityEngine;


[CreateAssetMenu(menuName = "Card/Normal/KeepShield")]
public class KeepShieldCard : CardSO
{
    public override void OnEquip(Player player)
    {
        player.SetShield(true);
    }
}
