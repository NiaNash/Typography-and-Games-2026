using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowHands : MonoBehaviour
{
    [SerializeField] private GameObject spriteToShow;
  
  //  [SerializeField] private GameObject buttonToHide;


    public void ShowTheHands()
    {
        spriteToShow.SetActive(true); //show eyes sprite

      //  buttonToHide.SetActive(false); //hide all visual inspect options
    }
}
