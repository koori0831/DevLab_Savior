using NUnit.Framework;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

public class CardManager : MonoBehaviour
{
    [SerializeField] private CardSOList cardListSO;
    [SerializeField] private CardContainer cardContainer;

    [SerializeField] private Card cardPrefab;
    [SerializeField] private List<Transform> spawnTrms;
    [SerializeField] private IntEventChannelSO levelUpChannel;
    [SerializeField] private BoolEventChannelSO chooseCardChannel;
    [SerializeField] private BoolEventChannelSO stopGameChannel;
    [SerializeField] private float spawnDelay;
    private WaitForSeconds _waitSpawnTime;


    private List<Card> _spawnCards = new List<Card>();
    private void Awake()
    {
        _waitSpawnTime = new WaitForSeconds(spawnDelay);
        levelUpChannel.OnValueEvent += LevelUpEventHandle;
        chooseCardChannel.OnValueEvent += ChooseCardEventHandle;
    }

    private void OnDestroy()
    {
        levelUpChannel.OnValueEvent -= LevelUpEventHandle;
        chooseCardChannel.OnValueEvent -= ChooseCardEventHandle;
    }
    private void ChooseCardEventHandle(bool obj)
    {
        if (!obj) return;

        StartCoroutine(DeleteCo());
    }

    private void LevelUpEventHandle(int level)
    {
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
        _spawnCards.Clear();

        stopGameChannel.RaiseEvent(true);

        foreach (var trm in spawnTrms)
        {
            CardSO cardSo = cardListSO.cardSOList[Random.Range(0, cardListSO.cardSOList.Count)];

            Card card = Instantiate(cardPrefab,transform);
            card.Initialize(cardSo,cardContainer);
            card.SpawnCardAction(trm);
            _spawnCards.Add(card);

            yield return _waitSpawnTime;
        }
    }
    private IEnumerator DeleteCo()
    {
        foreach (Card card in _spawnCards)
        {
            card.DeleteCardAction();
            yield return _waitSpawnTime;
        }
        stopGameChannel.RaiseEvent(false);
        _spawnCards.Clear();
    }
}
