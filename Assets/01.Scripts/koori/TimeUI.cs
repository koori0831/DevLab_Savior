using System;
using TMPro;
using UnityEngine;

public class TimeUI : MonoSingleton<TimeUI>
{
    [SerializeField] private BoolEventChannelSO stopEvent;
    private TMP_Text _text;
    public float _sec;
    public int _min;
    private bool _stop;
    protected override void Awake()
    {
        _text = GetComponent<TMP_Text>();
        stopEvent.OnValueEvent += (bool value) => { _stop = value; };
    }


    private void Update()
    {
        if(!_stop) 
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