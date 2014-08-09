using UnityEngine;
using System.Collections;

public class PseudoInput : MonoBehaviour
{
	public static PseudoInput Instance
	{
		get
		{
			if(_instance != null)
			{
				return _instance;
			}
			else
			{
				GameObject gameManager = new GameObject("PseudoInput");
				_instance = gameManager.AddComponent<PseudoInput>();
				return _instance;
			}
		}
	}
	
	private static PseudoInput _instance;

	public bool leftPressed = false;
	public bool rightPressed = false;

	// Update is called once per frame
	void LateUpdate()
	{
		leftPressed = false;
		rightPressed = false;
	}
}
