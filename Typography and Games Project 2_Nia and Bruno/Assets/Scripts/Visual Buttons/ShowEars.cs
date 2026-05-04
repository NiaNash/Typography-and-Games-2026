using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowEars : MonoBehaviour
{
    private GameManager gm;

    void Awake()
    {
        gm = FindObjectOfType<GameManager>();
    }

    public void ShowTheEars()
    {
        if (gm != null)
        {
            gm.ShowEars();
        }
    }
}