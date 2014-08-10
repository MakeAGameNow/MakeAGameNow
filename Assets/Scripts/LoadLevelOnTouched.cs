using UnityEngine;
using System.Collections;

public class LoadLevelOnTouched : MonoBehaviour
{
	public string levelName;

	void Touched()
	{
		Application.LoadLevel(levelName);
	}
}
