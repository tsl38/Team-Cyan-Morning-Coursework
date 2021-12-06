using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    //Boolean to control whether or not the game is paused.
    public static bool isGamePaused = false;

    //GameObjects for all the pause menu buttons as well as the panel that contains the background image.
    public GameObject pauseMenuButtons;
    public GameObject pauseMenuBackground;

    void Update()
    {
        //If the esc key is pressed
        if (Input.GetKeyDown(KeyCode.Escape) == true)
        {
            //if the game is paused, resume the game, otherwise, pause the game.
            if (isGamePaused == true)
            {
                //If the pause menu is active, call resume game.
                if (pauseMenuButtons.activeSelf == true)
                {
                    ResumeGame();
                }
            }
            //If the game is not paused, pause the game.
            else
            {
                PauseGame();
            }
        }
    }

    //Function that pauses the game.
    private void PauseGame()
    {
        //Sets all the buttons and the panel of the pause menu to be active, so the user can see them.
        pauseMenuButtons.SetActive(true);
        pauseMenuBackground.SetActive(true);
        //Game is paused, so set the boolean value to reflect that.
        isGamePaused = true;
        //Pause the scene! Time.timeScale = 0f means time is paused.
        Time.timeScale = 0f;
        //Puase the current background music and ambient sound of the level when the game is paused.
        FindObjectOfType<SoundManager>().PauseCurrent();
        //Pauses the voice of the dialogue.
        GameObject.Find("Canvas").GetComponent<DialogueUI>().PauseVoice();

        //Disable the audio source
        GameObject.Find("Player").GetComponent<AudioSource>().enabled = false;
        //Disables the weapon script for player.
        if (GameObject.Find("Player_Knife") != null)
        {
            GameObject.Find("Player_Knife").GetComponent<Weapon>().enabled = false;
        }
    }

    //Function that resumes the game.
    public void ResumeGame()
    {
        //plays the button sound effect.
        FindObjectOfType<SoundManager>().Play("MenuButtonPress");

        //Sets all the buttons and the panel of the pause menu to be in-active, so the user can't see them.
        pauseMenuButtons.SetActive(false);
        pauseMenuBackground.SetActive(false);
        //Game is not paused, so set the boolean value to reflect that.
        isGamePaused = false;
        //Resume the scene at normal speed! Time.timeScale = 1f means time is passing at a regular pace.
        Time.timeScale = 1f;
        //Resume the current background music and ambient sound of the level when the game is resumed.
        FindObjectOfType<SoundManager>().ResumeCurrent();
        //Resumes the dialogue voice, if the speaking character is not the player character.
        GameObject.Find("Canvas").GetComponent<DialogueUI>().ResumeVoice();

        //On resume, if no transition UI screen is active, re-enable all things that was disabled when the game was paused.
        if (GameObject.Find("Canvas").GetComponent<TransitionUI>().GetTransitionUI().activeSelf == false)
        {
            //Re-enables the player audio source.
            GameObject.Find("Player").GetComponent<AudioSource>().enabled = true;
            //Re-enables the weapon script for player.
            if (GameObject.Find("Player_Knife") != null)
            {
                GameObject.Find("Player_Knife").GetComponent<Weapon>().enabled = true;
            }
        }
    }

    //Function that quits the game application.
    public void PauseMenuQuitGame()
    {
        //Plays the button sound effect.
        FindObjectOfType<SoundManager>().Play("MenuButtonPress");

        Application.Quit();
    }
}
