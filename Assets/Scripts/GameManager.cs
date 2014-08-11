using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameManager : MonoBehaviour
{
	public static GameManager Instance
	{
		get
		{
			if(_instance != null)
			{
				return _instance;
			}
			else
			{
				GameObject gameManager = new GameObject("GameManager");
				_instance = gameManager.AddComponent<GameManager>();
				return _instance;
			}
		}
	}

	private static GameManager _instance;

	public float pointsPerUnitTravelled = 1.0f;
	public float gameSpeed = 10.0f;
	public string titleScreenName = "TitleScreen";
	public string highScoresScreenName = "HighScores";

	[HideInInspector]
	public int previousScore = 0;

	private float score = 0.0f;
	private static float highScore = 0.0f;

	private List<int> highScores = new List<int>();

	private bool gameOver = false;
	private bool hasSaved = false;

	// Use this for initialization
	void Start ()
	{
		if(_instance != this)
		{
			if(_instance == null)
			{
				_instance = this;
			}
			else
			{
				Destroy(gameObject);
			}
		}
		LoadHighScore();
		DontDestroyOnLoad(gameObject);
	}
	
	// Update is called once per frame
	void Update ()
	{
		if(Application.loadedLevelName != titleScreenName &&
		   Application.loadedLevelName != highScoresScreenName)
		{
			if(GameObject.FindGameObjectWithTag("Player") == null)
			{
				gameOver = true;
			}

			if(gameOver)
			{
				if(!hasSaved)
				{
					SaveHighScore();
					previousScore = (int)score;
					hasSaved = true;
				}

				if(!IsMobile())
				{
					if(Input.anyKeyDown)
					{
						Application.LoadLevel(titleScreenName);
					}
				}
				else
				{
					foreach(Touch touch in Input.touches)
					{
						if(touch.phase == TouchPhase.Began)
						{
							Debug.Log("Touched in GameManager");
							Debug.Log("Touch count: " + Input.touchCount);
							Application.LoadLevel(titleScreenName);
						}
					}
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
		else
		{
			//Reset stuff for next game
			ResetGame();
		}
	}

	void ResetGame()
	{
		score = 0.0f;
		gameOver = false;
		hasSaved = false;
	}

	void SaveHighScore()
	{
		int highSlot = -1;

		for(int i = 0; i < highScores.Count; i++)
		{
			if(highScores[i] < score)
			{
				highSlot = i;
				break;
			}
		}

		if (highSlot != -1)
		{
			highScores.Insert(highSlot, (int)score);
		}
		else
		{
			highScores.Add((int)score);
		}

		//Save high score list
		for(int i = 0; i < highScores.Count; i++)
		{
			PlayerPrefs.SetInt("HighScore" + i.ToString(), highScores[i]);
		}

		PlayerPrefs.SetInt ("ScoreNumber", highScores.Count);

		PlayerPrefs.Save();
	}

	void LoadHighScore()
	{
		highScores.Clear();
		for(int i = 0; i < PlayerPrefs.GetInt("ScoreNumber"); i++)
		{
			highScores.Add(PlayerPrefs.GetInt("HighScore" + i.ToString()));
		}
	}

	void OnGUI()
	{
		if(Application.loadedLevelName != titleScreenName &&
		   Application.loadedLevelName != highScoresScreenName)
		{
			int currentScore = (int)score;
			int currentHighScore = (int)highScore;
			GUILayout.Label("Score: " + currentScore.ToString());
			GUILayout.Label("Highscore: " + currentHighScore.ToString());
			if(gameOver == true)
			{
				GUILayout.Label("Game Over!  Press any key to quit!");
			}
		}
	}

	public static bool IsMobile()
	{
		//if(Application.platform = RuntimePlatform.OSXEditor || Application.platform == RuntimePlatform.WindowsEditor || Application.platform == RuntimePlatform.LinuxPlayer || Application.platform == RuntimePlatform.MetroPlayerX64 || Application.platform == RuntimePlatform.MetroPlayerX86 || Application.platform == RuntimePlatform.WindowsPlayer 
		if(Application.platform == RuntimePlatform.IPhonePlayer ||
		    Application.platform == RuntimePlatform.Android ||
		    Application.platform == RuntimePlatform.BlackBerryPlayer ||
		    Application.platform == RuntimePlatform.MetroPlayerARM)
		{
			return true;
		}
		else
		{
			return false;
		}
	}
}
