using UnityEngine;
using System.Collections;

public class PlaySoundOnInput : MonoBehaviour
{

	// Use this for initialization
	void Start ()
	{
		audio.volume = 0.0f;
		audio.Play ();
	}
	
	// Update is called once per frame
	void Update ()
	{
		if(Input.GetAxis("Horizontal") != 0.0f || PseudoInput.Instance.leftPressed || PseudoInput.Instance.rightPressed)
		{
			audio.volume = 1.0f;
		}
		else
		{
			audio.volume = 0.0f;
		}
	}
}
