using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

public class NextScene : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
       // SceneManager.LoadScene("MainMenu");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadGameplayScreen()
    {
        Debug.Log("change scene");
        SceneManager.LoadScene("Gameplay Screen");
    }
}
