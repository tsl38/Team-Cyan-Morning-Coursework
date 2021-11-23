using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fighter : MonoBehaviour
{
	//Public fields
	public int hitpoint = 10;
	public int maxHitpoint = 10;
	public float pushRecoverySpeed = 0.2f;

	//Immunity
	protected float immuneTime = 1.0f;
	protected float lastImmune;

	//Push
	protected Vector3 pushDirection;

	//All fighters can ReceiveDamage / Die
	protected virtual void ReceiveDamage(Damage dmg)
	{
		if (Time.time - lastImmune > immuneTime)
		{
			lastImmune = Time.time;
			hitpoint -= dmg.damageAmount;
			pushDirection = (transform.position - dmg.origin).normalized * dmg.pushForce;

			Debug.Log("YOU HAVE BEEN HIT");
			//GameManager.instance.ShowText(dmg.damageAmount.Tostring(), 15, Color.red, transform.position, Vector3.zero, 0.5f);
			if (hitpoint <= 0)
			{
				hitpoint = 0;
				Death();
			}
			
			//If the current gameObject this script is attached to is the player (By checking the object name, which should be unique), update the health list. so that the health bar UI will update.
			if (gameObject.name == "Player")
			{
				//Finds the Health_Bar_UI object in the UI canvas, and then finds the script attached to it to get the health list, and add the updated values to the list.
				GameObject.Find("Health_Bar_UI").GetComponent<Health_Bar_UI>().GetList().ChangeHealth(GameObject.Find("Player").GetComponent<Player>().hitpoint, GameObject.Find("Player").GetComponent<Player>().maxHitpoint);
			}
		}
	}

	protected virtual void Death()
    {

    }

}