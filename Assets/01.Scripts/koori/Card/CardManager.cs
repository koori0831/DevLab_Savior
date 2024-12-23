using NUnit.Framework;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CardManager : MonoBehaviour
{
    [SerializeField] private Card cardPrefab;
    [SerializeField] private List<Transform> spawnTrms;
    [SerializeField] private IntEventChannelSO levelUpChannel;
    [SerializeField] private float spawnDelay;
    private WaitForSeconds _waitSpawnTime;
    private void Awake()
    {
        _waitSpawnTime = new WaitForSeconds(spawnDelay);
        levelUpChannel.OnValueEvent += LevelUpEventHandle;
    }

    private void LevelUpEventHandle(int level)
    {
        //레벨은 뭐 알아서 처리하시고
        //음 여기 뭐 시간 멈추고.. 등등 해야디
        StartCoroutine(SpawnCo());
    }

    private void Update()
    {
        if (Keyboard.current.qKey.wasPressedThisFrame)
        {
            LevelUpEventHandle(1);
        }
    }
    private IEnumerator SpawnCo()
    {
        foreach(var trm in spawnTrms)
        {
            Card card = Instantiate(cardPrefab,transform);
            card.SpawnCardAction(trm);
            yield return _waitSpawnTime;
        }
    }
}
