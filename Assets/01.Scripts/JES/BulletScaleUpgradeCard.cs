using DG.Tweening;
using UnityEngine;



[CreateAssetMenu(menuName = "Card/Normal/BulletScale")]
public class BulletScaleUpgradeCard : CardSO
{
    [SerializeField] private float upgradeScale = 1.25f;
    [SerializeField] private float transTime = 0.5f;
    public override void OnEquip(Player player)
    {
        Vector3 goalScale =player.BulletTrm.localScale * upgradeScale;
        player.BulletTrm.DOScale(goalScale, transTime);  
    }
}
