using System.Collections;
using UnityEngine;
using TMPro;

public class DialogueUI : MonoBehaviour
{
    [SerializeField] private GameObject dialogueUI;
    [SerializeField] private TMP_Text textLabel;
    [SerializeField] private DialogueList testDialogue;

    private TypewriterEffect typewriterEffect;

    private void Start()
    {
        typewriterEffect = GetComponent<TypewriterEffect>();  //"The lady over there told me to go see you to get a potion of fire resistance\nThe lady over there told me to go see you to get a potion of fire resistance"
        CloseDialogueUI();
    }

    public void ShowDialogue(DialogueList dialogueList)
    {
        dialogueUI.SetActive(true);
        StartCoroutine(StepThroughDialogue(dialogueList));
    }

    private IEnumerator StepThroughDialogue(DialogueList dialogueList)
    {
        //yield return new WaitForSeconds(1);       // For testing purposes

        foreach (string dialogue in dialogueList.Dialogue)
        {
            yield return typewriterEffect.Run(dialogue, textLabel);
            yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Space));
        }

        CloseDialogueUI();
    }

    private void CloseDialogueUI()
    {
        dialogueUI.SetActive(false);
        textLabel.text = string.Empty;
    }
}
