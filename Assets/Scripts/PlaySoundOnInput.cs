using UnityEngine;
using System.Collections;

public class PlaySoundOnInput : MonoBehaviour
{

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update ()
	{
		//This moves our object left or right based on keyboardinput
		if(Input.GetAxis("Horizontal") != 0.0f || PseudoInput.Instance.leftPressed || PseudoInput.Instance.rightPressed)
		{
			if(!audio.isPlaying)
			{
				audio.Play();
			}
		}
		else
		{
			audio.Stop();
		}
	}
}
