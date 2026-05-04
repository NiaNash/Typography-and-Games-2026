using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public static DialogueManager Instance;

    public GameObject dialogueBox;
    public Text dialogueText;

    void Awake()
    {
        Instance = this;
    }

    public void ShowDialogueA()
    {
        dialogueBox.SetActive(true);
        dialogueText.text = "Approved. Proceed.";
    }

    public void ShowDialogueB()
    {
        dialogueBox.SetActive(true);
        dialogueText.text = "Denied. Incorrect identification.";
    }
}