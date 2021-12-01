using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Portal : Collidable
{
    protected override void OnCollide(Collider2D boxCollider)
    {
        if (boxCollider.name == "Player")
        {
            // Save Player state
            GameObject.Find("Player").GetComponent<Player>().SavePlayer();
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}