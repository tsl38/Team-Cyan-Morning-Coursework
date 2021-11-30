using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Transition_onEvent : MonoBehaviour
{
    public void DeathTransition(DialogueList deathDialogue)
    {
        GameObject.Find("Canvas").GetComponent<TransitionUI>().ShowTransition(deathDialogue, 3);
    }
}
