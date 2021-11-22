using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : Collidable
{
    public string[] sceneNames;
    protected override void OnCollide(Collider2D boxCollider)
    {
        if (boxCollider.name == "Player")
        {
            // Save Player state
            GameObject.Find("Player").GetComponent<Player>().SavePlayer();
            // Switch to Dungeon 1 Scene
            string sceneName = sceneNames[1];
            UnityEngine.SceneManagement.SceneManager.LoadScene(sceneName);
            Debug.Log("Entered Scene: " + sceneName);
        }
    }
}