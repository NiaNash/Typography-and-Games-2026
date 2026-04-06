using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopupWindow : MonoBehaviour
{
    [Header("Auto Close Settings")]
    [SerializeField] private float autoCloseTime = 5f;

    private float timer;

    private void OnEnable()
    {
        timer = autoCloseTime;
    }

    private void Update()
    {
        timer -= Time.deltaTime;

        if (timer <= 0f)
        {
            ClosePopup();
        }
    }

    public void ClosePopup()
    {
        gameObject.SetActive(false);
    }
}

