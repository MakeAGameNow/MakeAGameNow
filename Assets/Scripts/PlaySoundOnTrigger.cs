using UnityEngine;
using System.Collections;

public class PlaySoundOnTrigger : MonoBehaviour
{
	void OnTriggerEnter()
	{
		audio.Play();
	}
}
