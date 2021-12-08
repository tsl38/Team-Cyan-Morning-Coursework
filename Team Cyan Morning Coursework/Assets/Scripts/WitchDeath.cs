using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class WitchDeath : MonoBehaviour
{
    [SerializeField] private TMP_Text textLabel;
    [SerializeField] private DialogueList transDialogue;

    private void OnDestroy()
    {
        //Disables the player mover script until the transition screen is over.
        GameObject.Find("Player").GetComponent<Mover>().enabled = false;
        //Disables the weapon script for player.
        if (GameObject.Find("Player_Knife") != null)
        {
            GameObject.Find("Player_Knife").GetComponent<Weapon>().enabled = false;
        }
        //Display the transition screen.
        GameObject.Find("Canvas").GetComponent<TransitionUI>().ShowTransition(transDialogue, 0);
    }
}
