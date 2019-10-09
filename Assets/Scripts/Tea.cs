using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tea : MonoBehaviour
{
	public player character; 
	public Rigidbody2D rbody;
	public bool directionRight = true; //controls directions bottle goes
	Tea teaBottle; 

	// Start is called before the first frame update
	void Start()
    {
		rbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
		if (directionRight == true)
		{
			rbody.velocity = new Vector2(7.0f, 0.0f);
		}
		else
		{
			rbody.velocity = new Vector2(-7.0f, 0.0f);
		}
		
    }

	private void OnCollisionEnter2D(Collision2D collision)
	{
		Destroy(gameObject);
	}


	//This method is used to set the direction of the bottle
	public void SetFireDirectionRight(bool dir)
	{
		directionRight = dir;
	}

}
