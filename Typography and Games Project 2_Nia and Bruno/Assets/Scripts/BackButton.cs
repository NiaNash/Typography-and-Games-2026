using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackButton : MonoBehaviour
{
    [SerializeField] private GameObject buttonToHide;
    [SerializeField] private GameObject buttonToShow;

    public void ShowTheButton() //when the button is pressed
    {
        buttonToHide.SetActive(false); //Hide Visual Inspection Buttons/canvas

        buttonToShow.SetActive(true); //Show Starting Canvas
    }
}
