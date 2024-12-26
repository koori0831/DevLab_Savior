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
        "�ù�", "����", "����", "��", "����",
        "����", "����", "����", "����", "��","����","����","«��","����","����","��","���","�ֹ�","����","�빫��","������","�ξ��̹���","����",
        
    };

    public void OnRegisterButtonClick()
    {
        string inputText = inputField.text.Trim();

        // ���� Ȯ��: �Է� ������ ��� �ִ� ���
        if (string.IsNullOrEmpty(inputText))
        {
            inputField.text = "������ �Է��ϼ���.";
            return;
        }

        // ���� Ȯ��: �Է� ������ 10�ڸ� �Ѵ� ���
        if (inputText.Length > 10)
        {
            inputField.text = "10�� ���Ϸ� �Է��ϼ���.";
            return;
        }

        // ���� Ȯ��: �弳�� ���Ե� ���
        foreach (string word in bannedWords)
        {
            if (inputText.Contains(word))
            {
                inputField.text = "�������� �ܾ ���ԵǾ� �ֽ��ϴ�.";
                return;
            }
        }

        // ��� ������ ������ ��� �̺�Ʈ ����
        ExecuteEvent();
    }
    public void OnRigisFail(){
         inputField.text = "��Ͽ� �����߽��ϴ�";
    }
    private void ExecuteEvent()
    {
        OnSuccess.Invoke();
        
    }
}
