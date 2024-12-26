using System.Collections.Generic;
using TMPro;
using Unity.Services.Authentication;
using Unity.Services.Leaderboards;
using Unity.Services.Leaderboards.Models;
using UnityEngine;
using UnityEngine.Events;

public class Leaderboard_RegistUI : MonoBehaviour
{
    [SerializeField] TMP_Text scoreText;
    [SerializeField] TMP_Text leaderBoardScoreText;
    [SerializeField] TMP_InputField nameInput;
    [SerializeField] public UnityEvent onRegist;
    [SerializeField] public UnityEvent onRegistFail;
    int min;
    int sec;
    public async void DrawScore()
    {
        min = TimeUI.Instance._min;
        sec = Mathf.FloorToInt(TimeUI.Instance._sec);
        scoreText.text = $"{min}분 {sec}초 생존";

        LeaderboardScoresWithNotFoundPlayerIds value = await LeaderboardsService.Instance.GetScoresByPlayerIdsAsync("ranking", new List<string>() { AuthenticationService.Instance.PlayerId });
        int time = (int)value.Results[0].Score;
        leaderBoardScoreText.text = $"{time / 60}분 {time % 60}초";
    }
    [ContextMenu("RegistScore")]
    public void RegistScore()
    {
        try
        {
            int time = (min * 60) + sec;
            Leaderboard.Instance.AddValue(time, nameInput.text);
        }
        catch (System.Exception e)
        {
            Debug.LogError(e);
            onRegistFail.Invoke();
            return;
        }
        onRegist.Invoke();
    }
}
