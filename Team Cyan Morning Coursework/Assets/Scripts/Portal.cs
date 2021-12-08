using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Portal : Collidable
{
    public bool bossDead;
    [SerializeField] private TMP_Text textLabel;
    [SerializeField] private DialogueList notYetDialogue;
    private bool dialogueShown = false;

    protected override void OnCollide(Collider2D boxCollider)
    {
        if (boxCollider.name == "Player")
        {
            if (bossDead)
            {
                // Save Player state
                GameObject.Find("Player").GetComponent<Player>().SavePlayer();

                // Load next scene
                int nextScene = SceneManager.GetActiveScene().buildIndex + 1;
                //If the nextScene index is larger than 3, return to the main menu.
                if (nextScene > 3)
                {
                    //Main menu scene is index 0.
                    nextScene = 0;
                    //Stop the current track and ambient sound, and play the main menu theme.
                    FindObjectOfType<SoundManager>().StopCurrent();
                    FindObjectOfType<SoundManager>().Play("MainMenuTheme");
                    FindObjectOfType<SoundManager>().currentTheme = "MainMenuTheme";
                }
                SceneManager.LoadScene(nextScene);
            }

            else if (!dialogueShown)
            {
                GameObject.Find("Canvas").GetComponent<TransitionUI>().ShowTransition(notYetDialogue, 0);
                dialogueShown = true;
            }
        }
    }
}