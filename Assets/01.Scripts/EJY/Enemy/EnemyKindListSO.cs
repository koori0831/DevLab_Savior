using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EnemyKindListSO", menuName = "SO/Enemy/EnemyKindListSO")]
public class EnemyKindListSO : ScriptableObject
{
    public List<EnemyKindSO> enemyKindList = new();
}
