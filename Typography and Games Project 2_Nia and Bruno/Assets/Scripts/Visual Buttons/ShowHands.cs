using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowHands : MonoBehaviour
{
    private GameManager gm;

    void Awake()
    {
        gm = FindObjectOfType<GameManager>();
    }

    public void ShowTheHands()
    {
        if (gm != null)
        {
            gm.ShowHands();
        }
    }
}