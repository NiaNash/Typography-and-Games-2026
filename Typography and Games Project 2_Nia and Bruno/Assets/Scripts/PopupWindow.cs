using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopupWindow : MonoBehaviour
{
    [Header("Image")]
    [SerializeField] private Image displayImage;

    [Header("Auto Close Settings")]
    [SerializeField] private float autoCloseTime = 5f;

    [Header("Other Screens")]
    [SerializeField] private GameObject visualInspectionScreen; // drag your inactive canvas here

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
        gameObject.SetActive(false);                       // hide popup
        visualInspectionScreen.SetActive(true);            // show inspection screen
    }

    // Optional: change the popup image
    public void SetImage(Sprite newSprite)
    {
        displayImage.sprite = newSprite;
    }
}