using UnityEngine;

public class ExpSpawner : MonoBehaviour
{
    [SerializeField] private GameObject _exp;
    [SerializeField] private float expDropCount = 5;
    [SerializeField] private float expDropMinForce = 3;
    [SerializeField] private float expDropMaxForce = 5;
    public void DropExp(Transform owner)
    {
        for (int i = 0; i < expDropCount; i++)
        {
            GameObject exp = Instantiate(_exp, owner.position, Quaternion.identity);

            Vector2 randomVector = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f)).normalized * Random.Range(expDropMinForce, expDropMaxForce);
            exp.GetComponent<Rigidbody2D>().AddForce(randomVector);
        }
    }
}
