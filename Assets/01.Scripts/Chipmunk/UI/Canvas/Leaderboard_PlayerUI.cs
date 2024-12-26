using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Leaderboard_PlayerUI : MonoBehaviour
{
    [SerializeField] TMP_Text playerName;
    [SerializeField] TMP_Text playerScore;
    [SerializeField] TMP_Text playerID;
    [SerializeField] TMP_Text playerRank;
    public void SetPlayerUI(string name, string score, string id, int rank)
    {
        int time = int.Parse(score);
        playerName.text = name;
        playerScore.text = $"{time/60}분 {time%60}초";
        playerID.text = $"ID : {id}";
        playerRank.text = rank.ToString();
    }

}
