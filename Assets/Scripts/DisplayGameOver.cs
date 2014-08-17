using UnityEngine;
using System.Collections;

public class DisplayGameOver : MonoBehaviour
{

	// Update is called once per frame
	void Update ()
	{
		if(GameManager.Instance.gameOver == true)
		{
			renderer.enabled = true;
        }
	}
}
