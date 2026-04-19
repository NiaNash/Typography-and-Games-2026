using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergyControl : MonoBehaviour
{

    public GameObject Energy1, Energy2, Energy3;
    public static int energy;

    // Start is called before the first frame update
    void Start()
    {
        energy = 3;
        Energy1.gameObject.SetActive(true);
        Energy2.gameObject.SetActive(true);
        Energy3.gameObject.SetActive(true);

    }

    // Update is called once per frame
    void Update()
    {
        switch (energy)
        {
            case 3:
                Energy1.gameObject.SetActive(true);
                Energy2.gameObject.SetActive(true);
                Energy3.gameObject.SetActive(true);
                break;
            case 2:
                Energy1.gameObject.SetActive(true);
                Energy2.gameObject.SetActive(true);
                Energy3.gameObject.SetActive(false);
                break;
            case 1:
                Energy1.gameObject.SetActive(true);
                Energy2.gameObject.SetActive(false);
                Energy3.gameObject.SetActive(false);
                break;
            default:
                Energy1.gameObject.SetActive(false);
                Energy2.gameObject.SetActive(false);
                Energy3.gameObject.SetActive(false);
                break;

        }
    }
}
