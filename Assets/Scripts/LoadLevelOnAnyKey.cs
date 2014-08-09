using UnityEngine;
using System.Collections;

public class LoadLevelOnAnyKey : MonoBehaviour
{
	public string levelName;

	// Update is called once per frame
	void Update ()
	{
		if(!GameManager.IsMobile())
		{
			if(Input.anyKeyDown)
			{
				Application.LoadLevel(levelName);
			}
		}
		else
		{
			foreach(Touch touch in Input.touches)
			{
				if(touch.phase == TouchPhase.Began)
				{
					Debug.Log("Touched in LoadLevelOnAnyKey");
					Debug.Log("Touch count: " + Input.touchCount);
					Application.LoadLevel(levelName);
				}
			}
		}
	}
}
