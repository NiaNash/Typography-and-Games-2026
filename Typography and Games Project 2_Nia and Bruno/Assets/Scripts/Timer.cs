using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{

    [SerializeField] private TextMeshProUGUI _text;

    [SerializeField] private float _timeRemaining;

    [SerializeField] private int _decimals;
    
    void Start()
    {
        
    }
    void Update()
    {
        if (_timeRemaining < 0) return;

        _timeRemaining -= Time.deltaTime;
        if (_timeRemaining < 0) _timeRemaining = 0;
        UpdateText();
    }

    private void UpdateText()
    {
        _text.text = _timeRemaining.ToString($"F{_decimals}");
    }
}
