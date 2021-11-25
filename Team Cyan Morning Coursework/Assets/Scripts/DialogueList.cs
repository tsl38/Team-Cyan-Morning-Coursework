using UnityEngine;

[CreateAssetMenu(menuName = "Dialogue/DialogueList")]

public class DialogueList : ScriptableObject
{
    [SerializeField] [TextArea] private string[] dialogue;

    public string[] Dialogue => dialogue;       // Make dialogue read-only
}
