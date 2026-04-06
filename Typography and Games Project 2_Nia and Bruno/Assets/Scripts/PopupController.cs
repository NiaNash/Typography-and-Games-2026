using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopupController : MonoBehaviour
{
 
    public PopupWindow popupWindow; // drag your popup here
    public Sprite mySprite;         // assign an image in inspector

    public void ShowPopup()
    {
        popupWindow.SetImage(mySprite);
        popupWindow.gameObject.SetActive(true);
    }
}

