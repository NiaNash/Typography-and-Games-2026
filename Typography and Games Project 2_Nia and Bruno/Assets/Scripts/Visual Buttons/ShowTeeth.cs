using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowTeeth : MonoBehaviour
{
    [SerializeField] private GameObject spriteToShow;
  
    [SerializeField] private GameObject buttonToHide;


    public void ShowTheTeeth()
    {
        spriteToShow.SetActive(true); //show eyes sprite

        buttonToHide.SetActive(false); //hide all visual inspect options
    }
}
