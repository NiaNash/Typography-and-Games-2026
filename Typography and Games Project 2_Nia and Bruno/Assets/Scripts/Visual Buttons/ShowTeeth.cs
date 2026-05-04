using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowTeeth : MonoBehaviour
{
    private GameManager gm;

    void Awake()
    {
        gm = FindObjectOfType<GameManager>();
    }

    public void ShowTheTeeth()
    {
        if (gm != null)
        {
            gm.ShowTeeth();
        }
    }
}