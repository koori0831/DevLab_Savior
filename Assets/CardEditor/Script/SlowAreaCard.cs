using System.Collections;
using UnityEngine;

[CreateAssetMenu(menuName = "Card/SlowAreaCard")]
public class SlowAreaCard : CardSO
{
    [SerializeField] private SlowArea slowAreaPrefab;
    [SerializeField] private float slowAreaDuration = 5f;
    [SerializeField] private Bullet playerBullet;
    public override void OnEquip(Player player)
    {
        playerBullet = player.bullet;
        player.StartCoroutine(SpawnSlowArea());
    }
    private IEnumerator SpawnSlowArea()
    {
        while (true)
        {
            SlowArea slowArea = Instantiate(slowAreaPrefab);
            slowArea.transform.position = playerBullet.transform.position;
            slowArea.Initailize(slowAreaDuration);
            yield return new WaitForSeconds(5f);
        }
    }
}
