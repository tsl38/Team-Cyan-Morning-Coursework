using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Transition_onCollision : Collidable
{
    [SerializeField] private DialogueList transDialogue;

    protected override void OnCollide(Collider2D boxCollider)
    {
        if (boxCollider.name == "Player")
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
            //Deletes the object that collides with the player, so the transition screen cannot be triggered again.
            Destroy(GameObject.Find("Transition 1"));

            //Plays the theme music of the level depending on the build index of the level.
            //I did not import the SceneManagement library because we do not need to actually manage any scenes in this script,
            //We just need the build index is all.
            int currentSceneIndex = UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex;
            if (currentSceneIndex == 1)
            {
                FindObjectOfType<SoundManager>().StopCurrent();
                FindObjectOfType<SoundManager>().Play("VillageTheme");
                FindObjectOfType<SoundManager>().Play("AmbientBirdSounds");
                FindObjectOfType<SoundManager>().currentTheme = "VillageTheme";
                FindObjectOfType<SoundManager>().currentAmbientSound = "AmbientBirdSounds";
            }
            else if (currentSceneIndex == 2) 
            {
                FindObjectOfType<SoundManager>().StopCurrent();
                FindObjectOfType<SoundManager>().Play("DungeonLevelOneTheme");
                FindObjectOfType<SoundManager>().Play("DungeonLevelOneAmbient");
                FindObjectOfType<SoundManager>().currentTheme = "DungeonLevelOneTheme";
                FindObjectOfType<SoundManager>().currentAmbientSound = "DungeonLevelOneAmbient";
            }
            else if (currentSceneIndex == 3)
            {
                FindObjectOfType<SoundManager>().StopCurrent();
                FindObjectOfType<SoundManager>().Play("DungeonFinalBossTheme");
                FindObjectOfType<SoundManager>().currentTheme = "DungeonFinalBossTheme";
            }
        }
    }
}
