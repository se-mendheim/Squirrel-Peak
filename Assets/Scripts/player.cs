using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    Rigidbody2D rbody;
	public MSM msm;
	public bool grounded;
	public Tea fireTea;

	float coolDown;
	float speedHorizontal;
	float speedVertical;
	
	
    // Start is called before the first frame update
    void Start()
    {
        rbody = GetComponent<Rigidbody2D>();
        speedHorizontal = 0.0f;
		speedVertical = 0.0f;
		grounded = true;
		coolDown = 0.0f;
    }

	// Update is called once per frame
	void Update()
	{
		//speedHorizontal = 0.0f;
		//rbody.velocity = new Vector2(speedHorizontal, 0.0f);
		//speedVertical = 0.0f;
		
		//Spacebar - Player Jumps
		if (Input.GetKeyDown(KeyCode.Space) && grounded)
		{
			speedVertical = 6.0f;
			rbody.velocity = new Vector2(speedHorizontal, speedVertical);
		}
		
		//A - Move player left
		if (Input.GetKey(KeyCode.A) && grounded)
		{
			speedHorizontal = -4.0f;
			//speedVertical = 0.0f;
			rbody.velocity = new Vector2(speedHorizontal, speedVertical);
			
		}

		//D - Move player right
		if (Input.GetKey(KeyCode.D) && grounded)
		{
			speedHorizontal = 4.0f;
			//speedVertical = 0.0f;
			rbody.velocity = new Vector2(speedHorizontal, speedVertical);
			
		}

		//A - This will immediately stop the player
		//This is intentional because a slow down makes gameplay strange
		if (Input.GetKeyUp(KeyCode.A) && grounded)
		{
			speedHorizontal = 0.0f;
			//speedVertical = 0.0f;
			rbody.velocity = new Vector2(speedHorizontal, speedVertical);

		}

		//D - This will immmediately stop the player
		//This is intentional because a slow down makes gameplay strange
		if (Input.GetKeyUp(KeyCode.D) && grounded)
		{
			speedHorizontal = 0.0f;
			//speedVertical = 0.0f;
			rbody.velocity = new Vector2(speedHorizontal, speedVertical);

		}

		//Q - Shoots bottle to left of player
		if (Input.GetKeyDown(KeyCode.Q))
		{
			if (Time.time > coolDown)
			{
				fireTea.SetFireDirectionRight(false);
				GameObject teaBottle = (Instantiate(fireTea, transform.position + transform.right * -1.0f, Quaternion.identity)).gameObject;
				coolDown = 0.3f + Time.time;
			}
			

		}

		//E - Shoots bottle to right of player
		if (Input.GetKeyDown(KeyCode.E))
		{
			if (Time.time > coolDown)
			{
				fireTea.SetFireDirectionRight(true);
				GameObject teaBottle = (Instantiate(fireTea, transform.position + transform.right * 1.0f, Quaternion.identity)).gameObject;
				coolDown = 0.3f + Time.time;
			}
			
		}

	}

	private void OnCollisionEnter2D(Collision2D collision)
	{
		//player collides with a squirrel
		if (collision.gameObject.tag == "squirrel")
		{
			if (msm.playerHealth == 0)
			{
				KillCharacter(); //Kill character is player is out of health/lives
			}
			msm.playerHealth -= 1; //otherwise, decrement lives
		}

		//player collides with anything else
		if (collision.gameObject.tag == "floor" || collision.gameObject.tag == "leaves" || collision.gameObject.tag == "stick")
		{
			grounded = true;
			speedVertical = 0.0f;
		}
	}

	private void OnCollisionExit2D(Collision2D collision)
	{

		//Player is no longer in contact with static game sprites
		if (collision.gameObject.tag == "floor" || collision.gameObject.tag == "leaves" || collision.gameObject.tag == "stick")
		{
			grounded = false;
		}
	}

	public void KillCharacter()
	{
		Destroy(gameObject); //destroy the character
	}
}
