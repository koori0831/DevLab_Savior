using UnityEngine;
using TMPro;
using UnityEngine.Events;

public class RegisterBtn : MonoBehaviour
{
    [SerializeField] private TMP_InputField inputField;
    public UnityEvent OnSuccess;
    [SerializeField]
    private string[] bannedWords =
    {
        "시발", "섹스", "병신", "ㅄ", "ㅅㅂ",
        "ㅆㅂ", "씨발", "새끼", "ㅅㄲ", "좆","보지","자지","짬지","ㅂㅈ","ㅈㅈ","ㅈ","장애","애미","운지","노무현","윤석열","부엉이바위","웃흥",
        
    };

    public void OnRegisterButtonClick()
    {
        string inputText = inputField.text.Trim();

        // 조건 확인: 입력 내용이 비어 있는 경우
        if (string.IsNullOrEmpty(inputText))
        {
            inputField.text = "내용을 입력하세요.";
            return;
        }

        // 조건 확인: 입력 내용이 10자를 넘는 경우
        if (inputText.Length > 10)
        {
            inputField.text = "10자 이하로 입력하세요.";
            return;
        }

        // 조건 확인: 욕설이 포함된 경우
        foreach (string word in bannedWords)
        {
            if (inputText.Contains(word))
            {
                inputField.text = "부적절한 단어가 포함되어 있습니다.";
                return;
            }
        }

        // 모든 조건을 만족한 경우 이벤트 실행
        ExecuteEvent();
    }
    public void OnRigisFail(){
         inputField.text = "등록에 실패했습니다";
    }
    private void ExecuteEvent()
    {
        OnSuccess.Invoke();
        
    }
}
