using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameUtils : MonoBehaviour
{


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            QuitGame();
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
