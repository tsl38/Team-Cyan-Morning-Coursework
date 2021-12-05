using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : Collidable
{
	//Damage struct
	public int damagePoint = 1;
	public float pushForce = 2.0f;

	//Upgrate
	public int weaponLevel = 0;
	private SpriteRenderer spriteRenderer;

	//Swing
	private float cooldown = 0.5f;
	private float lastSwing;
	public Animator animator;

	//A vector3 to store the current orientation of the player. Default to be no direction.
	private Vector3 playerOrientation = new Vector3(0, 0, 0);

	protected override void Start()
	{
		base.Start();
		spriteRenderer = GetComponent<SpriteRenderer>();
	}

	protected override void Update()
	{
		base.Update();

		//Only attack if left click is pressed.
		if (Input.GetMouseButtonDown(0))
		{
			//If the current orientation is up, then attack up.
			if (playerOrientation.y > 0)
			{
				animator.SetInteger("UpOrDown", 1);
			}
			//If the current orientation is down, then attack down.
			else if (playerOrientation.y < 0)
			{
				animator.SetInteger("UpOrDown", -1);
			}
			//Else attack left or right.
			else
			{
				animator.SetInteger("UpOrDown", 0);
			}

			//Swing the weapon.
			if (Time.time - lastSwing > cooldown)
			{
				lastSwing = Time.time;
				Swing();
			}
		}

		if (Input.GetMouseButtonUp(0)){
			lastSwing = Time.time;
			Swing();
			//Plays the audio for sword swing.
			FindObjectOfType<SoundManager>().Play("SwordSwing");
		}
	}

	private void FixedUpdate() {
		//Gets the current orientation of the player.
		float x = Input.GetAxisRaw("Horizontal");
		float y = Input.GetAxisRaw("Vertical");
		//Only updates the current orientation vector if either left/right or up/down was pressed.
		if (x != 0 || y != 0) {
			//If only y is none zero, set the orientation vector.
			if(x == 0 && y != 0)
			{
				playerOrientation = new Vector3(0.0f, y, 0.0f);
			}
			//If x is none zero, set the orientation vector.
			else if (x != 0 && y == 0)
			{
				playerOrientation = new Vector3(x, 0.0f, 0.0f);
			}
		}
	}

	protected override void OnCollide(Collider2D coll)
	{

		if (coll.tag == "Fighter")
		{
			//Checks to make sure the collider is not player or head collider object on the player.
			if (coll.name == "Player" || coll.name == "Head Collider")
				return;
			//Create a new damage object, then we'll send it to the fighter we've hit
			Damage dmg = new Damage()
			{
				damageAmount = damagePoint,
				origin = transform.position,
				pushForce = pushForce
			};

			coll.SendMessage("ReceiveDamage", dmg);

			//Plays the audio for enemies getting hit by the player sword.
			GetComponent<AudioSource>().Play();

		}
		//If the collision is with a wall, play the SwordHitStone sound effect.
		else if (coll.tag == "StoneWall") {
			FindObjectOfType<SoundManager>().Play("SwordHitStone");
		}
	}

	private void Swing()
	{
		//Activate the trigger to play the swing animation.
		animator.SetTrigger("PlayerSwing");
	}
}