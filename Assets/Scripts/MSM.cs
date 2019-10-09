using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MSM : MonoBehaviour
{
    public squirrel SquirrelObject;
	public player character;
    public bool playerIsAlive;
	public float timeLeft;
	public int numSquirrels;
	public Text LivesAndScore;
	public Text Timer;
	public int score;
	public int playerHealth;

	int switchSquirrel;
    
    // Start is called before the first frame update
    void Start()
    {
        playerIsAlive = true;
        timeLeft = 300;
        numSquirrels = 0;
		switchSquirrel = 1;
		playerHealth = 3;

		GameObject player = Instantiate(character, new Vector3(0, -3, 0), Quaternion.identity).gameObject;
		player playerMain = FindObjectOfType<player>();
		playerMain.msm = this;
	}

    // Update is called once per frame
    void Update()
    {
		if (Input.GetKeyDown(KeyCode.Escape)){
            Application.Quit();
        }

		LivesAndScore.text = "Lives: " + playerHealth + " || " + "Score: " + score;
		Timer.text = ((int)timeLeft).ToString();

		timeLeft -= Time.deltaTime;

		while (numSquirrels < 3)
		{
			if (switchSquirrel == 1)
			{
				SpawnSquirrel(-9, 0);
				switchSquirrel = 2;
			}
			else if (switchSquirrel == 2)
			{
				SpawnSquirrel(-9, -3);
				switchSquirrel = 3;
			}
			else if (switchSquirrel == 3)
			{
				SpawnSquirrel(9, 0);
				switchSquirrel = 4;
			}
			else
			{
				SpawnSquirrel(9, -3);
				switchSquirrel = 1;
			}
		}

		if (timeLeft > 0) {
			if (timeLeft > 250)
			{
				SquirrelObject.SetSquirrelSpeed(1.5f);
			}
			else if (timeLeft > 200)
			{
				SquirrelObject.SetSquirrelSpeed(2.0f);
			}
			else if (timeLeft > 100)
			{
				SquirrelObject.SetSquirrelSpeed(2.5f);
			}
			else if (timeLeft > 50)
			{
				SquirrelObject.SetSquirrelSpeed(3.0f);
			}
			else
			{
				SquirrelObject.SetSquirrelSpeed(6.0f);
			}
		}
		else
		{
			Time.timeScale = 0;
		}

		if (playerHealth <= 0)
		{
			Time.timeScale = 0;
		}

	}

    void SpawnSquirrel(int x, int y)
    {

        if (x == 9)
        {
            GameObject squirrel = Instantiate(SquirrelObject, new Vector3(x, y, 0), Quaternion.identity).gameObject;
			squirrel squirrelMain = FindObjectOfType<squirrel>();
			squirrelMain.msm = this;
			squirrelMain.Flip();
			numSquirrels++;
        }

        else
        {
            GameObject squirrel = Instantiate(SquirrelObject, new Vector3(x, y, 0), Quaternion.identity).gameObject;
            squirrel squirrelMain = FindObjectOfType<squirrel>();
            squirrelMain.msm = this;
            numSquirrels++;
        }
        
    }

	public void killSquirrel()
	{
		
		numSquirrels--;
	}
    

    public bool Orientation()
    {

        return false;
    }
}
