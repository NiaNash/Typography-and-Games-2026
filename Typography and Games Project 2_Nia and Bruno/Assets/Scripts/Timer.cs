using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{

    [SerializeField] private TextMeshProUGUI _text;
    [SerializeField] private float _startTime = 30f; //round length
    [SerializeField] private int _decimals;

    private float _timeRemaining;
    private bool hasTriggered = false;

    void Start()
    {
        _timeRemaining = _startTime;
    }

    void Update()
    {
        if (_timeRemaining > 0)
        {
            _timeRemaining -= Time.deltaTime;

            if (_timeRemaining <= 0)
            {
                _timeRemaining = 0;
                TimeUp();
            }
        }

        UpdateText();
    }

    private void UpdateText()
    {
        _text.text = _timeRemaining.ToString($"F{_decimals}");
    }

    private void TimeUp()
    {
        if (hasTriggered) return;

        hasTriggered = true;

        Debug.Log("Time's up!");

        HeartsControl.health -= 1;

        if (HeartsControl.health < 0)
            HeartsControl.health = 0;

        FindObjectOfType<GameManager>().ResetRound();
        ResetTimer(); //used for rounds
    }

    //optional for rounds
    public void ResetTimer()
    {
        hasTriggered = false;
        _timeRemaining = _startTime; //make this the same value as default time
    }
}
