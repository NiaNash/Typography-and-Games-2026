using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VisualInspectionButtonInteract : MonoBehaviour
{
   // public EnergyControl energyControl;
    public Button[] inspectionButtons;
    private bool[] hasBeenPressed;

   // [SerializeField] private GameObject energy1; //ref energy

    void Start()
    {
        hasBeenPressed = new bool[inspectionButtons.Length];
        for (int i = 0; i < inspectionButtons.Length; i++)
        {
            int index = i; // needed for closure
            inspectionButtons[i].onClick.AddListener(() => OnButtonPressed(index));
        }
    }

    void OnButtonPressed(int index)
    {
        if (!hasBeenPressed[index])
        {
            hasBeenPressed[index] = true;
            inspectionButtons[index].interactable = false;
            Debug.Log($"Button {index} pressed!");

            EnergyControl.energy -= 1;
        //    energy1.SetActive( false ); //make energy 1 disappear
        }
    }
}
