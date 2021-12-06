using System.Collections;
using UnityEngine;
using TMPro;

public class DialogueUI : MonoBehaviour
{
    [SerializeField] private GameObject dialogueUI;
    [SerializeField] private TMP_Text textLabel;
    [SerializeField] private DialogueList npcDialogue;

    private TypewriterEffect typewriterEffect;
    private bool mumblePuased = false; //Bool to check if the sound effect is paused.
    private string soundEffectName;

    private void Start()
    {
        typewriterEffect = GetComponent<TypewriterEffect>();
        CloseDialogueUI();
    }

    public void ShowDialogue(DialogueList dialogueList, string maleFemaleOld)
    {
        if (maleFemaleOld == "Male")
        {
            soundEffectName = "MaleMumble";
        }
        else if (maleFemaleOld == "Female")
        {
            soundEffectName = "FemaleMumble";
        }
        else if (maleFemaleOld == "Old") {
            soundEffectName = "OldMumble";
        }

        dialogueUI.SetActive(true);
        StartCoroutine(StepThroughDialogue(dialogueList));
    }

    private IEnumerator StepThroughDialogue(DialogueList dialogueList)
    {
        //yield return new WaitForSeconds(1);       // For testing purposes

        foreach (string dialogue in dialogueList.Dialogue)
        {
            //Only plays the sound effect if the person speaking is not Tony.
            if (dialogue.Substring(0, 4) != "Tony") {
                //If the sound effect is not paused, play ir from the beginning.
                if (mumblePuased == false)
                {
                    FindObjectOfType<SoundManager>().Play(soundEffectName);
                }
                //If it was paused, just resume it.
                else
                {
                    FindObjectOfType<SoundManager>().Resume(soundEffectName);
                }
            }
            yield return typewriterEffect.Run(dialogue, textLabel);
            //Pause the sound effect when the current dialogue box ends.
            FindObjectOfType<SoundManager>().Pause(soundEffectName);
            //Sets the bool to be true.
            mumblePuased = true;
            yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Space));
        }

        mumblePuased = false;
        CloseDialogueUI();
    }

    private void CloseDialogueUI()
    {
        dialogueUI.SetActive(false);
        textLabel.text = string.Empty;
    }
}
