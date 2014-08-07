using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour
{
	public static GameManager Instance;

	public float pointsPerUnitTravelled = 1.0f;
	public float gameSpeed = 10.0f;

	private float score = 0.0f;
	private static float highScore = 0.0f;
	private bool gameOver = false;

	// Use this for initialization
	void Start ()
	{
		Instance = this;
	}
	
	// Update is called once per frame
	void Update ()
	{
		if(GameObject.FindGameObjectWithTag("Player") == null)
		{
			gameOver = true;
		}

		if(gameOver)
		{
			if(Input.anyKeyDown)
			{
				Application.LoadLevel(Application.loadedLevel);
			}
		}

		if(!gameOver)
		{
			score += pointsPerUnitTravelled * gameSpeed * Time.deltaTime;
			if(score > highScore)
			{
					highScore = score;
			}
		}
	}

	void OnGUI()
	{
		int currentScore = (int)score;
		int currentHighScore = (int)highScore;
		GUILayout.Label("Score: " + currentScore.ToString());
		GUILayout.Label("Highscore: " + currentHighScore.ToString());
		if(gameOver == true)
		{
			GUILayout.Label("Game Over!  Press any key to reset!");
		}
	}
}
