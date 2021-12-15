using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This script deploys the witch dialogue and sound effect when the condition of all current enemies on the map have been defeated
public class DeployWitch : MonoBehaviour
{
    public GameObject witch; 
    private GameObject enemies;
    [SerializeField] private GameObject dialogueUI;
    [SerializeField] private DialogueList witchDialogue;

    private void Start()
    {
        enemies = GameObject.Find("Enemies");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (enemies.transform.childCount == 0)
        {
            witch.SetActive(true);
            FindObjectOfType<SoundManager>().Play("WitchEvilLaugh");
            GameObject.Find("Canvas").GetComponent<DialogueUI>().ShowDialogue(witchDialogue, "Witch", gameObject.name);
            Destroy(GameObject.Find("DeployWitchObj"));
        }
    }
}
