using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueAppear : MonoBehaviour
{
    [SerializeField] private GameObject dialogueToHide;
    [SerializeField] private GameObject dialogueToShow;

    public void ShowTheDialogue() //when the button is pressed
    {
        dialogueToHide.SetActive(false); //hide this dialogue

        dialogueToShow.SetActive(true); //SHow this dialogue
    }
}
