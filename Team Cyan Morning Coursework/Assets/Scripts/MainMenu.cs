using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    //Function to load the village scene.
    //Change this for transition screne then village scene load.
    public void StartGame() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    //Exits the game , back to Windows/Mac.
    public void ExitGame() {
        Application.Quit();
    }
}
