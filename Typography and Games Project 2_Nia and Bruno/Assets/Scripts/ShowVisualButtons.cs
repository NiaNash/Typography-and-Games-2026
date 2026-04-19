using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowVisualButtons : MonoBehaviour
{
    [SerializeField] private GameObject buttonToShow;
    [SerializeField] private GameObject buttonToHide;
 //   [SerializeField] private GameObject dialogueHide;
    

    public void ShowTheButton() //when the button is pressed
    {
        buttonToShow.SetActive(true); //show this Visual Inspection Canvas

        buttonToHide.SetActive(false); //hide starting Canvas

     //   dialogueHide.SetActive(false);//hide this Starting Dialogue Box
    }
}
