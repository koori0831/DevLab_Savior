using UnityEngine;

public class ExpSpawner : MonoBehaviour
{
    [SerializeField] private GameObject _exp;
    public void DropExp(Transform owner)
    {
        GameObject exp = Instantiate(_exp, owner.position, Quaternion.identity);
    }
}
