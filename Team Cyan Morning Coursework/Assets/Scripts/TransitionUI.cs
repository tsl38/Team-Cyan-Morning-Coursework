using System.Collections;
using UnityEngine;
using TMPro;

public class TransitionUI : MonoBehaviour
{
    [SerializeField] private GameObject transitionUI;
    [SerializeField] private TMP_Text textLabel;
    [SerializeField] private DialogueList transDialogue;

    private TypewriterEffect typewriterEffect;

    private void Start()
    {
        typewriterEffect = GetComponent<TypewriterEffect>();
        CloseTransitionUI();
    }

    public void ShowTransition(DialogueList dialogueList, int pause)
    {
        transitionUI.SetActive(true);
        StartCoroutine(StepThroughDialogue(dialogueList , pause));
    }

    private IEnumerator StepThroughDialogue(DialogueList dialogueList, int pause)
    {
        //yield return new WaitForSeconds(1);       // For testing purposes

        foreach (string dialogue in dialogueList.Dialogue)
        {
            yield return typewriterEffect.Run(dialogue, textLabel);
            yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Space));
        }

        yield return new WaitForSeconds(pause);
        CloseTransitionUI();
    }

    private void CloseTransitionUI()
    {
        transitionUI.SetActive(false);
        textLabel.text = string.Empty;
        //Re-enable the mover.cs script on player.
        if (GameObject.Find("Player").GetComponent<Mover>().isActiveAndEnabled == false)
        {
            GameObject.Find("Player").GetComponent<Mover>().enabled = true;
        }

        //If the player has a weapon and the weapon script is disabled, re-enable it.
        if (GameObject.Find("Player_Knife") != null && GameObject.Find("Player_Knife").GetComponent<Weapon>().isActiveAndEnabled == false) {
            GameObject.Find("Player_Knife").GetComponent<Weapon>().enabled = true;
        }
    }

    //Returns the TransitionUI object.
    public GameObject GetTransitionUI() {
        return transitionUI;
    }
}
