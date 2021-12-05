using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    //Function to load the village scene.
    public void StartGame() {
        //Plays the button sound effect.
        FindObjectOfType<SoundManager>().Play("MenuButtonPress");

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    //Exits the game , back to Windows/Mac.
    public void ExitGame() {
        //Plays the button sound effect.
        FindObjectOfType<SoundManager>().Play("MenuButtonPress");

        Application.Quit();
    }
}
