using UnityEngine;


[CreateAssetMenu(menuName = "Card/Normal/Shield")]
public class ShieldCard : CardSO
{
    public override void OnEquip(Player player)
    {
        player.SetShield(false);   
    }
}
