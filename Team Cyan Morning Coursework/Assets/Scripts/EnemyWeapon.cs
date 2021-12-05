using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWeapon : Collidable
{
    public int damage;
    public float pushForce;
	public Animator animator;

    private Vector3 travelDirection = new Vector3(0, 0, 0);
	private Transform target;
	public float cooldown = 0.5f;
	private float lastSwing;
	private Renderer renderer;

	protected override void Start()
	{
		base.Start();
		target = GameObject.Find("Player").transform;
		renderer = GetComponent<Renderer>();
	}
	
	protected override void Update()
	{
		base.Update();

		//Only attack if animator enabled and within the distance the length of the weapon
		if (Vector3.Distance(target.position, transform.position) < 2* renderer.bounds.extents.magnitude && animator!= null)
		{
			//If the current orientation is up, then attack up.
			if (travelDirection.y > 0.1)
			{
				animator.SetInteger("EnemyUpOrDown", 1);
			}
			//If the current orientation is down, then attack down.
			else if (travelDirection.y < -0.1)
			{
				animator.SetInteger("EnemyUpOrDown", -1);
			}
			//Else attack left or right.
			else
			{
				animator.SetInteger("EnemyUpOrDown", 0);
			}

			//Swing the weapon.
			if (Time.time - lastSwing > cooldown)
			{
				lastSwing = Time.time;
				Swing();

				//Plays the enemy weapon swing, depending on weapon.
				if (gameObject.name == "Mace" || gameObject.name == "Long_Sword_1" || gameObject.name == "Elite_Swordd" || gameObject.name == "Medium_Sword" || gameObject.name == "large_Elite_Sword" || gameObject.name == "Wide_long_sword")
				{
					if (gameObject.name != "Mace")
					{
						FindObjectOfType<SoundManager>().Play("EnemySwordSwing1");
					}
					else
					{
						FindObjectOfType<SoundManager>().Play("EnemySwordSwing2");
					}
				}
			}
		}
	}

	private void FixedUpdate()
	{
		if (Vector3.Distance(target.position, transform.position) < 2 * renderer.bounds.extents.magnitude && animator != null)
		{
			travelDirection = target.position - transform.position;
		}
	}

	protected override void OnCollide(Collider2D coll)
    {
        if(coll.name =="Player" && coll.tag == "Fighter")
        {
            // create a new damage object before sending it to the player
            Damage dmg = new Damage()
            {
                damageAmount = damage,
                origin = transform.position,
                pushForce = pushForce
            };

            coll.SendMessage("ReceiveDamage", dmg);

			//Plays player getting hit sound effect.
			FindObjectOfType<SoundManager>().Play("GettingHit");
        }
    }

	private void Swing()
	{
		//Activate the trigger to play the swing animation.
		animator.SetTrigger("EnemySwing");
	}
}
