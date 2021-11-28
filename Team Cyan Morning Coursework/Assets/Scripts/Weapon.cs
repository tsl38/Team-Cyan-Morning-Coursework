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

	protected override void Start()
	{
		base.Start();
		spriteRenderer = GetComponent<SpriteRenderer>();
	}

	protected override void Update()
	{
		base.Update();

		if (Input.GetMouseButtonDown(0))
		{
			if (Time.time - lastSwing > cooldown)
			{
				lastSwing = Time.time;
				Swing();
			}
		}
		if(Input.GetMouseButtonUp(0)){
			lastSwing = Time.time;
			Swing();
		}
	}

	protected override void OnCollide(Collider2D coll)
	{

		if (coll.tag == "Fighter")
		{
			//Checks to make sure the collier is not player or head collider object on the player.
			if (coll.name == "Player" || coll.name == "Head Collider")
				return;
			Debug.Log(coll.name);
			//Create a new damage object, then we'll send it to the fighter we've hit
			Damage dmg = new Damage()
			{
				damageAmount = damagePoint,
				origin = transform.position,
				pushForce = pushForce
			};

			coll.SendMessage("ReceiveDamage", dmg);

		}
	}

	private void Swing()
	{
		animator.SetTrigger("Swing");
	}
}