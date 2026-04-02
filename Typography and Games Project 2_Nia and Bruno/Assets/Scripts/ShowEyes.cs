using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowEyes : MonoBehaviour
{
    [SerializeField] private GameObject spriteToShow;
 //   [SerializeField] private GameObject buttonToShow;
    [SerializeField] private GameObject buttonToHide;


    public void ShowTheEyes()
    {
        spriteToShow.SetActive(true); //show eyes sprite

     //   buttonToShow.SetActive(true); //show "back" button

        buttonToHide.SetActive(false); //hide all visual inspect options
    }
}
