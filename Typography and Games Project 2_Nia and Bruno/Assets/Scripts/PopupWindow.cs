using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI; // Needed for Image

public class PopupWindow : MonoBehaviour
{
    [Header("Image")]
    [SerializeField] private Image displayImage; // <-- This MUST exist

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

    // This is how you change the image
    public void SetImage(Sprite newSprite)
    {
        displayImage.sprite = newSprite;
    }
}