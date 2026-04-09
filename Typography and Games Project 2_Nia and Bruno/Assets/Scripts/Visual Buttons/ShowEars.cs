using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowEars : MonoBehaviour
{
    [SerializeField] private GameObject spriteToShow;
  
    [SerializeField] private GameObject buttonToHide;


    public void ShowTheEars()
    {
        spriteToShow.SetActive(true); //show eyes sprite

        buttonToHide.SetActive(false); //hide all visual inspect options
    }
}
