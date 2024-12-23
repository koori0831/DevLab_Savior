using TMPro;
using UnityEngine;

public class TimeUI : MonoBehaviour
{
    private TMP_Text _text;
    private float _sec;
    private int _min;

    private void Awake()
    {
        _text = GetComponent<TMP_Text>();
    }

    private void Update()
    {
        _sec += Time.deltaTime;
        if (_sec >= 60f)
        {
            _sec -= 60f; 
            _min++;
        }

        string minutes = _min.ToString("00");
        string seconds = Mathf.FloorToInt(_sec).ToString("00");

        _text.text = $"Time : {minutes} : {seconds}";
    }
}