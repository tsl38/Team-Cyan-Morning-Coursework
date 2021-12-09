using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueUI : MonoBehaviour
{
    [SerializeField] private GameObject dialogueUI;
    [SerializeField] private TMP_Text textLabel;
    [SerializeField] private DialogueList npcDialogue;

    private TypewriterEffect typewriterEffect;
    private bool mumblePuased = false; //Bool to check if the sound effect is paused.
    private string soundEffectName; //Name of the soudn effect been played.
    private string characterSpeaking; //Name of the speaking character.
    private string nameOfNPCGameObject; //Name of the NPC game object that the player is talking to.

    private void Start()
    {
        typewriterEffect = GetComponent<TypewriterEffect>();
        CloseDialogueUI();
    }

    public void ShowDialogue(DialogueList dialogueList, string maleFemaleOld, string nameOfGameObject)
    {
        if (maleFemaleOld == "Male")
        {
            soundEffectName = "MaleMumble";
        }
        else if (maleFemaleOld == "Female")
        {
            soundEffectName = "FemaleMumble";
        }
        else if (maleFemaleOld == "Old")
        {
            soundEffectName = "OldMumble";
        }

        dialogueUI.SetActive(true);
        //Sets the name of the NPC game object.
        nameOfNPCGameObject = nameOfGameObject;
        //Disable the NPC_Interact.cs script on that NPC game object, so that the player cannot spam F.
        if (GameObject.Find(nameOfNPCGameObject).GetComponent<NPC_Interact>() != null)
        {
            GameObject.Find(nameOfNPCGameObject).GetComponent<NPC_Interact>().enabled = false;
        }
        StartCoroutine(StepThroughDialogue(dialogueList));
    }

    private IEnumerator StepThroughDialogue(DialogueList dialogueList)
    {
        //yield return new WaitForSeconds(1);       // For testing purposes

        foreach (string dialogue in dialogueList.Dialogue)
        {
            //Stores the name of the speaking character.
            characterSpeaking = dialogue.Substring(0, 4);
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
                    mumblePuased = false;
                }
            }
            yield return typewriterEffect.Run(dialogue, textLabel);
            //Pause the sound effect when the current dialogue box ends.
            FindObjectOfType<SoundManager>().Pause(soundEffectName);
            //Sets the bool to be true.
            mumblePuased = true;
            yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Space));
        }

        //Resets these variables.
        mumblePuased = false;
        soundEffectName = null;
        CloseDialogueUI();
    }

    private void CloseDialogueUI()
    {
        dialogueUI.SetActive(false);
        textLabel.text = string.Empty;
        //If the name of the NPC object is not null, re-enable the NPC_Interact.cs script again, so that the player can interact with the NPC after all dialogue is complete.
        if (nameOfNPCGameObject != null)
        {
            if (GameObject.Find(nameOfNPCGameObject) != null)
            {
                if (GameObject.Find(nameOfNPCGameObject).GetComponent<NPC_Interact>() != null)
                {
                    GameObject.Find(nameOfNPCGameObject).GetComponent<NPC_Interact>().enabled = true;
                }
                nameOfNPCGameObject = null;
            }
        }
    }

    //Allows voices to be paused outside of this class.
    public void PauseVoice() {
        //Only pause if the name of the voice is not null.
        if (soundEffectName != null) {
            FindObjectOfType<SoundManager>().Pause(soundEffectName);
        }
    }

    //Allows the voices to be resumed outside of this class.
    public void ResumeVoice()
    {
        //Only resume if the name of the voice is not null.
        if (soundEffectName != null)
        {
            //Only resume if the character speaking is not Tony.
            if (characterSpeaking != "Tony" && mumblePuased == false)
            {
                FindObjectOfType<SoundManager>().Resume(soundEffectName);
            }
        }
    }
}
