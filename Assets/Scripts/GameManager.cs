using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour
{
	private bool gameOver = false;

	// Use this for initialization
	void Start () {
	
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
	}

	void OnGUI()
	{
		if(gameOver == true)
		{
			GUILayout.Label("Game Over!  Press any key to reset!");
		}
	}
}
