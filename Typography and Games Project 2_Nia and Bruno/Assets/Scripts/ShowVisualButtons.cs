using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowVisualButtons : MonoBehaviour
{
    [SerializeField] private GameObject buttonToShow;
    [SerializeField] private GameObject buttonToHide;
    

    public void ShowTheButton()
    {
        buttonToShow.SetActive(true);

        buttonToHide.SetActive(false);
    }
}
