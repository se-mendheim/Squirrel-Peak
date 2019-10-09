using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class squirrel : MonoBehaviour
{
	public Rigidbody2D rbody;
	public MSM msm;
	public SpriteRenderer sr;
	bool flipSquirrel;
	int squirrelHealth;
	public float squirrelSpeed;
	// Start is called before the first frame update
	void Start()
	{
		rbody = GetComponent<Rigidbody2D>();
		sr = GetComponent<SpriteRenderer>();
		squirrelHealth = 2; //set squirrel health
		squirrelSpeed = 1.5f; //set squirrel speed
	}

	// Update is called once per frame
	void Update()
	{

		if (flipSquirrel)
		{
			rbody.velocity = new Vector2(-squirrelSpeed, -1.0f);
		}

		else
		{
			sr.flipX = true;
			rbody.velocity = new Vector2(squirrelSpeed, -1.0f);
		}
	}

	public void Flip()
	{
		flipSquirrel = true;

	}

	private void OnCollisionEnter2D(Collision2D collision)
	{

		//squirrel collides with tea bottle
		if (collision.gameObject.tag == "tea")
		{
			//depending on squirrel health, destroy squirrel and increment score
			if (squirrelHealth == 1)
			{
				Destroy(gameObject);
				msm.score += 50;
				msm.killSquirrel();
			}
			else
			{
				msm.score += 15;
				squirrelHealth--;
			}
		}

		//squirrel collides with player
		if (collision.gameObject.tag == "player")
		{
			Destroy(gameObject);
			msm.killSquirrel();
		}

		if (collision.gameObject.tag == "leftWall")
		{
			transform.position = new Vector3(9, 0, 0); //Turn the squirrel around
		}

		if (collision.gameObject.tag == "rightWall")
		{
			transform.position = new Vector3(-9, 0, 0); //Turn the squirrel around
		}

		//squirrel collides with squirrel
		if (collision.gameObject.tag == "squirrel")
		{
			Destroy(gameObject); //destroy the squirrels (they attacked each other)

			//decrement score by 100, but score can't go below 0
			if (!(msm.score >= 100))
			{
				msm.score = 0;
			}
			else
			{
				msm.score -= 50;
			}
			msm.killSquirrel();
		}
	}

	public void SetSquirrelSpeed(float speed)
	{
		squirrelSpeed = speed; //set the squirrel speed
	}


}