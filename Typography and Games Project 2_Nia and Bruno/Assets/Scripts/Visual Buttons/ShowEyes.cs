using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowEyes : MonoBehaviour
{
    private GameManager gm;

    void Awake()
    {
        gm = FindObjectOfType<GameManager>();
    }

    public void ShowTheEyes()
    {
        if (gm != null)
        {
            gm.ShowEyes();
        }
    }
}