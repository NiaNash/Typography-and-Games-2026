using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAppear : MonoBehaviour
{
    public GameObject objectToShow; //creates variable in inspector
    public float delay = 2f; //time in seconds

    void Start()
    {
        StartCoroutine(ShowAfterDelay())    ;
    }

    public void ActivateWithDelay()
    {
        StartCoroutine(ShowAfterDelay());
    }

    IEnumerator ShowAfterDelay()
    {
        yield return new WaitForSeconds(delay);
        objectToShow.SetActive(true); 
    }
}
