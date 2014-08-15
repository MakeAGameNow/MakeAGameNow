using UnityEngine;
using System.Collections;

public class DestroyParticleWhenDone : MonoBehaviour
{
	// Update is called once per frame
	void Update ()
	{
		if(!particleSystem.isPlaying)
		{
			Destroy(gameObject);
		}
	}
}
